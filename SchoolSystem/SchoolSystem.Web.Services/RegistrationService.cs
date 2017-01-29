using Microsoft.AspNet.Identity.EntityFramework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Web.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRepository<IdentityRole> userRolesRepo;
        private readonly IRepository<Subject> subjectsRepo;
        private readonly IRepository<ClassOfStudents> classOfStudentsRepo;
        private readonly IRepository<Student> studentRepo;
        private readonly IRepository<Teacher> teacherRepo;
        private readonly Func<IUnitOfWork> unitOfWork;

        public RegistrationService(
            IRepository<IdentityRole> userRolesRepo,
            IRepository<Subject> subjectsRepo,
            IRepository<ClassOfStudents> classOfStudentsRepo,
            IRepository<Student> studentRepo,
            IRepository<Teacher> teacherRepo,
            Func<IUnitOfWork> unitOfWork
            )
        {
            this.ValidateConstructorParameters(userRolesRepo, subjectsRepo, classOfStudentsRepo, studentRepo, teacherRepo, unitOfWork);

            this.userRolesRepo = userRolesRepo;
            this.subjectsRepo = subjectsRepo;
            this.classOfStudentsRepo = classOfStudentsRepo;
            this.studentRepo = studentRepo;
            this.teacherRepo = teacherRepo;
            this.unitOfWork = unitOfWork;
        }


        public IEnumerable<IdentityRole> GetAllUserRoles()
        {
            return this.userRolesRepo.GetAll();
        }

        public IEnumerable<ClassOfStudents> GetClassOfStudents()
        {
            return this.classOfStudentsRepo.GetAll();
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return this.subjectsRepo.GetAll();
        }

        public void CreateTeacher(string teacherId, int subjectId)
        {
            if (teacherId == null)
            {
                throw new ArgumentNullException("teacherId");
            }

            using (var uow = this.unitOfWork())
            {
                this.teacherRepo.Add(new Teacher()
                {
                    Id = teacherId,
                    SubjectId = subjectId
                });

                uow.Commit();
            }
        }
        public void CreateStudent(string studentId, int classOfStudentId)
        {

            if (studentId == null)
            {
                throw new ArgumentNullException("studentId");
            }

            using (var uow = this.unitOfWork())
            {
                this.studentRepo.Add(new Student()
                {
                    Id = studentId,
                    ClassOfStudentsId = classOfStudentId
                });

                uow.Commit();
            }
        }

        private void ValidateConstructorParameters(
            IRepository<IdentityRole> userRolesRepo,
            IRepository<Subject> subjectsRepo,
            IRepository<ClassOfStudents> classOfStudentsRepo,
            IRepository<Student> studentRepo,
            IRepository<Teacher> teacherRepo,
            Func<IUnitOfWork> unitOfWork)
        {
            if (userRolesRepo == null)
            {
                throw new ArgumentNullException("userRepo");
            }

            if (subjectsRepo == null)
            {
                throw new ArgumentNullException("subjectRepo");
            }

            if (classOfStudentsRepo == null)
            {
                throw new ArgumentNullException("classOfStudentsRepo");
            }

            if (studentRepo == null)
            {
                throw new ArgumentNullException("studentRepo");
            }

            if (teacherRepo == null)
            {
                throw new ArgumentNullException("teacherRepo");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }
        }
    }
}
