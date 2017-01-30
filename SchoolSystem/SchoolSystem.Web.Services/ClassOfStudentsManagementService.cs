using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool AddClass(string name, IEnumerable<Subject> subjects)
        {
            var allClassNames = this.classOfStudentsRepo.GetAll().Select(c => c.Name);

            if (allClassNames.Any(x => x == name))
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

        public void AddSubjectsToClass()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return this.subjectsRepo.GetAll();
        }
    }
}
