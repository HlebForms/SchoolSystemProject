using System;
using System.Collections.Generic;
using System.Linq;

using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Contracts;

using Bytes2you.Validation;
using SchoolSystem.Data.Models.CustomModels;

namespace SchoolSystem.Web.Services
{
    public class SubjectManagementService : ISubjectManagementService
    {
        private readonly IRepository<SubjectClassOfStudents> subjectClassOfStudentsRepo;
        private readonly IRepository<Subject> subjectRepo;
        private readonly Func<IUnitOfWork> unitOfWork;

        public SubjectManagementService(
            IRepository<Subject> subjectRepo,
            IRepository<SubjectClassOfStudents> subjectClassOfStudentsRepo,
            Func<IUnitOfWork> unitOfWork)
        {
            Guard.WhenArgument(subjectRepo, "subjectRepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();
            Guard.WhenArgument(subjectClassOfStudentsRepo, "subjectClassOfStudentsRepo").IsNull().Throw();

            this.subjectRepo = subjectRepo;
            this.subjectClassOfStudentsRepo = subjectClassOfStudentsRepo;
            this.unitOfWork = unitOfWork;
        }

        public bool CreateSubject(string subjectName, string subjectPictureUrl)
        {
            Guard.WhenArgument(subjectName, "subjectName").IsNullOrEmpty().Throw();
            Guard.WhenArgument(subjectPictureUrl, "subjectPictureUrl").IsNullOrEmpty().Throw();

            var allSubjectNames = this.subjectRepo.GetAll().Select(x => x.Name).ToList();

            if (allSubjectNames.Any(x => x == subjectName))
            {
                // there is subject with that name already
                return false;
            }

            using (var uow = this.unitOfWork())
            {
                this.subjectRepo.Add(new Subject()
                {
                    Name = subjectName,
                    ImageUrl = subjectPictureUrl
                });

                return uow.Commit();
            }
        }

        public IEnumerable<SubjectBasicInfo> GetAllSubjectsWithoutTeacher()
        {
            return this.subjectRepo.GetAll(x => x.Teacher == null,
                x => new SubjectBasicInfo()
                {
                    Id = x.Id,
                    Name = x.Name
                });
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return this.subjectRepo.GetAll();
        }

        public IEnumerable<Subject> GetAllSubjectsAlreadyAssignedToTheClass(int classId)
        {
            return this.subjectClassOfStudentsRepo
                .GetAll(x => x.ClassOfStudentsId == classId
                && x.Subject.TeacherId != null,
                x => x.Subject,
                x => x.Subject);
        }


        public IEnumerable<SubjectBasicInfo> GetSubjectsPerTeacher(string teacherName)
        {
            return this.subjectRepo.GetAll(x => x.Teacher.User.UserName == teacherName,
                    x => new SubjectBasicInfo
                    {
                        Id = x.Id,
                        Name = x.Name
                    },
                    x => x.Teacher,
                    x => x.Teacher.User); ;
        }

        public IEnumerable<SubjectBasicInfo> GetSubjectsNotYetAssignedToTheClass(int classId)
        {
            var alreadyAssignedSubjectsIds = this.subjectClassOfStudentsRepo
                 .GetAll(x => x.ClassOfStudentsId == classId
                 && x.Subject.TeacherId != null,
                 x => x.SubjectId,
                 x => x.Subject);

            if (alreadyAssignedSubjectsIds == null)
            {
                alreadyAssignedSubjectsIds = new List<int>();
            }

            var result = this.subjectRepo.GetAll(x =>
            !alreadyAssignedSubjectsIds.Contains(x.Id)
            && x.TeacherId != null,
            x => new SubjectBasicInfo()
            {
                Id = x.Id,
                Name = x.Name
            });

            return result;
        }

        public bool AddSubjectsToTeacher(string teacherId, IEnumerable<int> subjectIds)
        {
            Guard.WhenArgument(teacherId, "teacherId").IsNullOrEmpty().Throw();
            Guard.WhenArgument(subjectIds, "subjectIds").IsNullOrEmpty().Throw();

            var subjects = this.subjectRepo.GetAll(x => subjectIds.Contains(x.Id), x => x);

            if (subjects == null)
            {
                return false;
            }

            if (subjectIds.Count() != subjects.Count())
            {
                return false;
            }

            using (var uow = this.unitOfWork())
            {
                foreach (var subject in subjects)
                {
                    subject.TeacherId = teacherId;
                }

                return uow.Commit();
            }
        }
    }
}
