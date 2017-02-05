using System;
using System.Collections.Generic;
using System.Linq;

using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Contracts;

namespace SchoolSystem.Web.Services
{
    public class ClassOfStudentsManagementService : IClassOfStudentsManagementService
    {
        private readonly IRepository<Subject> subjectsRepo;
        private readonly IRepository<ClassOfStudents> classOfStudentsRepo;
        private readonly Func<IUnitOfWork> unitOfWork;

        public ClassOfStudentsManagementService(IRepository<Subject> subjectsRepo,
               IRepository<ClassOfStudents> classOfStudentsRepo, Func<IUnitOfWork> unitOfWork)
        {
            if (subjectsRepo == null)
            {
                throw new ArgumentNullException("subjectsRepo");
            }

            if (classOfStudentsRepo == null)
            {
                throw new ArgumentNullException("classOfStudentsRepo");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            this.subjectsRepo = subjectsRepo;
            this.classOfStudentsRepo = classOfStudentsRepo;
            this.unitOfWork = unitOfWork;
        }

        public void AddSubjectsToClass()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return this.subjectsRepo.GetAll();
        }

        public bool AddClass(string name, IEnumerable<string> subjecIds)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (subjecIds == null)
            {
                throw new ArgumentNullException("subjects");
            }

            var allClassesNames = this.classOfStudentsRepo.GetAll(null, x => x.Name).ToList();

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
                    uow.Commit();
                    return true;
                }
            }
        }

        public IEnumerable<ClassOfStudents> GetAllClasses()
        {
            return this.classOfStudentsRepo.GetAll();
        }
    }
}
