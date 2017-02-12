using Bytes2you.Validation;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolSystem.Data.Contracts;
using System;
using System.Collections.Generic;

using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.Web.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRepository<IdentityRole> userRolesRepo;
        private readonly IRepository<Subject> subjectsRepo;
        private readonly IRepository<Student> studentRepo;
        private readonly IRepository<Teacher> teacherRepo;
        private readonly Func<IUnitOfWork> unitOfWork;

        public RegistrationService(
            IRepository<IdentityRole> userRolesRepo,
            IRepository<Subject> subjectsRepo,
            IRepository<Student> studentRepo,
            IRepository<Teacher> teacherRepo,
            Func<IUnitOfWork> unitOfWork
            )
        {
            Guard.WhenArgument(userRolesRepo, "userRolesRepo").IsNull().Throw();
            Guard.WhenArgument(subjectsRepo, "subjectsRepo").IsNull().Throw();
            Guard.WhenArgument(studentRepo, "studentRepo").IsNull().Throw();
            Guard.WhenArgument(teacherRepo, "teacherRepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.userRolesRepo = userRolesRepo;
            this.subjectsRepo = subjectsRepo;
            this.studentRepo = studentRepo;
            this.teacherRepo = teacherRepo;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<IdentityRole> GetAllUserRoles()
        {
            return this.userRolesRepo.GetAll();
        }

        public void CreateTeacher(string teacherId, int subjectId)
        {
            Guard.WhenArgument(teacherId, "teacherId").IsNullOrEmpty().Throw();

            var subject = this.subjectsRepo.GetFirst(x => x.Id == subjectId);

            using (var uow = this.unitOfWork())
            {
                this.teacherRepo.Add(new Teacher()
                {
                    Id = teacherId,
                    Subjects = new HashSet<Subject>() { subject }
                });

                subject.TeacherId = teacherId;

                uow.Commit();
            }
        }
        public void CreateStudent(string studentId, int classOfStudentId)
        {
            Guard.WhenArgument(studentId, "studentId").IsNullOrEmpty().Throw();

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
    }
}
