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
    public class ClassOfStudentsManagementService : IClassOfStudentsManagementService
    {
        // TODO subjects repo is not used (maybe remove it)
        private readonly IRepository<Subject> subjectsRepo;
        private readonly IRepository<ClassOfStudents> classOfStudentsRepo;
        private readonly IRepository<SubjectClassOfStudents> subjectClassOfStudnetsrepo;
        private readonly Func<IUnitOfWork> unitOfWork;

        public ClassOfStudentsManagementService(
                IRepository<Subject> subjectsRepo,
                IRepository<ClassOfStudents> classOfStudentsRepo,
                IRepository<SubjectClassOfStudents> subjectClassOfStudnetsrepo,
                Func<IUnitOfWork> unitOfWork)
        {
            Guard.WhenArgument(subjectsRepo, "subjectsRepo").IsNull().Throw();
            Guard.WhenArgument(classOfStudentsRepo, "classOfStudentsRepo").IsNull().Throw();
            Guard.WhenArgument(subjectClassOfStudnetsrepo, "subjectClassOfStudnetsrepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.subjectsRepo = subjectsRepo;
            this.classOfStudentsRepo = classOfStudentsRepo;
            this.subjectClassOfStudnetsrepo = subjectClassOfStudnetsrepo;
            this.unitOfWork = unitOfWork;
        }

        public bool AddClass(string name, IEnumerable<string> subjecIds)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();
            Guard.WhenArgument(subjecIds, "subjecIds").IsNull().Throw();

            var allClassesNames = this.classOfStudentsRepo.GetAll(null, x => x.Name);

            var subjects = new HashSet<Subject>();
            foreach (var subj in subjecIds)
            {
                var subjId = int.Parse(subj);
                var subject = this.subjectsRepo.GetFirst(x => x.Id == subjId);
                subjects.Add(subject);
            }

            if (allClassesNames.Any(x => x == name))
            {
                return false;
            }
            else
            {
                using (var uow = this.unitOfWork())
                {
                    var classOfStudents = new ClassOfStudents()
                    {
                        Name = name
                    };

                    // adding subjects for the class
                    var subjectsForTheClass = new HashSet<SubjectClassOfStudents>();

                    foreach (var subject in subjects)
                    {
                        subjectsForTheClass.Add(new SubjectClassOfStudents()
                        {
                            SubjectId = subject.Id,
                            ClassOfStudents = classOfStudents
                        });
                    }

                    classOfStudents.SubjectClassOfStudents = subjectsForTheClass;
                    this.classOfStudentsRepo.Add(classOfStudents);

                    return uow.Commit();
                }
            }
        }

        public IEnumerable<ClassOfStudents> GetAllClasses()
        {
            return this.classOfStudentsRepo.GetAll();
        }

        public IEnumerable<ClassOfStudents> GetAllClassesWithSpecifiedSubject(int subjectId)
        {
            return this.subjectClassOfStudnetsrepo.GetAll(x => x.SubjectId == subjectId, x => x.ClassOfStudents);
        }

        public void AddSubjectsToClass(int classId, int subjectId)
        {
            using (var uow = this.unitOfWork())
            {
                this.subjectClassOfStudnetsrepo.Add(new SubjectClassOfStudents()
                {
                    SubjectId = subjectId,
                    ClassOfStudentsId = classId
                });

                uow.Commit();
            }
        }
    }
}
