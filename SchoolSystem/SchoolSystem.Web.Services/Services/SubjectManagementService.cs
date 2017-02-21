using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Web.Services.Contracts;

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

        public IEnumerable<SubjectBasicInfoModel> GetAllSubjectsWithoutTeacher()
        {
            return this.subjectRepo.GetAll(x => x.TeacherId == null,
                x => new SubjectBasicInfoModel()
                {
                    Id = x.Id,
                    Name = x.Name
                });
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return this.subjectRepo.GetAll();
        }

        public IEnumerable<SubjectBasicInfoModel> GetAllSubjectsWithTeacher()
        {
            return this.subjectRepo
              .GetAll(x => x.TeacherId != null,
              x => new SubjectBasicInfoModel()
              {
                  Id = x.Id,
                  Name = x.Name
              });

        }

        public IEnumerable<Subject> GetAllSubjectsAlreadyAssignedToTheClass(int classId)
        {
            return this.subjectClassOfStudentsRepo
                .GetAll(x => x.ClassOfStudentsId == classId
                && x.Subject.TeacherId != null,
                s => s.Subject,
                i => i.Subject);
        }

        public IEnumerable<SubjectBasicInfoModel> GetSubjectsPerTeacher(string teacherName)
        {
            return this.subjectRepo.GetAll(x => x.Teacher.User.UserName == teacherName,
                    x => new SubjectBasicInfoModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    },
                    s => s.Teacher,
                    i => i.Teacher.User);
        }

        public IEnumerable<SubjectBasicInfoModel> GetSubjectsNotYetAssignedToTheClass(int classId)
        {
            var alreadyAssignedSubjectsIds = this.subjectClassOfStudentsRepo
                 .GetAll(x => x.ClassOfStudentsId == classId,
                 s => s.SubjectId);

            var result = this.subjectRepo.GetAll(x =>
            !alreadyAssignedSubjectsIds.Contains(x.Id)
            && x.TeacherId != null,
            s => new SubjectBasicInfoModel()
            {
                Id = s.Id,
                Name = s.Name
            });

            return result;
        }

        public bool AddSubjectsToTeacher(string teacherId, IEnumerable<int> subjectIds)
        {
            Guard.WhenArgument(teacherId, "teacherId").IsNullOrEmpty().Throw();
            Guard.WhenArgument(subjectIds, "subjectIds").IsNull().Throw();

            var subjects = this.subjectRepo.GetAll(x => subjectIds.Contains(x.Id) && x.TeacherId == null, x => x);

            if (subjects.Count() == 0)
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
