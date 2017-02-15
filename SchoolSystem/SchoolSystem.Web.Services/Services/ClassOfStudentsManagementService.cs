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
        private readonly IRepository<ClassOfStudents> classOfStudentsRepo;
        private readonly IRepository<SubjectClassOfStudents> subjectClassOfStudnetsrepo;
        private readonly Func<IUnitOfWork> unitOfWork;

        public ClassOfStudentsManagementService(
                IRepository<Subject> subjectsRepo,
                IRepository<ClassOfStudents> classOfStudentsRepo,
                IRepository<SubjectClassOfStudents> subjectClassOfStudnetsrepo,
                Func<IUnitOfWork> unitOfWork)
        {
            Guard.WhenArgument(classOfStudentsRepo, "classOfStudentsRepo").IsNull().Throw();
            Guard.WhenArgument(subjectClassOfStudnetsrepo, "subjectClassOfStudnetsrepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.classOfStudentsRepo = classOfStudentsRepo;
            this.subjectClassOfStudnetsrepo = subjectClassOfStudnetsrepo;
            this.unitOfWork = unitOfWork;
        }

        public bool AddClass(string name, IEnumerable<string> subjecIds)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();
            Guard.WhenArgument(subjecIds, "subjecIds").IsNull().Throw();

            if (this.IsClassNameUnique(name))
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
                    foreach (var subject in subjecIds)
                    {
                        this.subjectClassOfStudnetsrepo.Add(new SubjectClassOfStudents()
                        {
                            SubjectId = int.Parse(subject),
                            ClassOfStudents = classOfStudents
                        });
                    }

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

        public bool AddSubjectsToClass(int classId, IEnumerable<int> subjectIds)
        {
            using (var uow = this.unitOfWork())
            {
                foreach (var subjectId in subjectIds)
                {
                    this.subjectClassOfStudnetsrepo.Add(new SubjectClassOfStudents()
                    {
                        SubjectId = subjectId,
                        ClassOfStudentsId = classId
                    });
                }

                return uow.Commit();
            }
        }

        private bool IsClassNameUnique(string name)
        {
            var allClassesNames = this.classOfStudentsRepo.GetAll(null, x => x.Name);

            return allClassesNames.Any(x => x == name);
        }
    }
}
