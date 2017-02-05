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
            if (subjectRepo == null)
            {
                throw new ArgumentNullException("subjectRepo");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            if (subjectClassOfStudentsRepo == null)
            {
                throw new ArgumentNullException("subjectClassOfStudentsRepo");
            }


            this.subjectRepo = subjectRepo;
            this.subjectClassOfStudentsRepo = subjectClassOfStudentsRepo;
            this.unitOfWork = unitOfWork;
        }

        public bool CreateSubject(string subjectName)
        {
            if (subjectName == null)
            {
                throw new ArgumentNullException("subjectName");
            }

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
                    Name = subjectName
                });

                uow.Commit();
                return true;
            }
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return this.subjectRepo.GetAll();
        }

        public IEnumerable<Subject> GetSubjectsForSpecificClass(int classId)
        {
            return this.subjectClassOfStudentsRepo
                .GetAll(x => x.ClassOfStudentsId == classId, x => x.Subject)
                .Where(x => x.Teachers.Count != 0);
        }
    }
}
