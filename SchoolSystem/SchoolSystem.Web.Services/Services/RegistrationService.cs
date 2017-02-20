using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.Web.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRepository<IdentityRole> userRolesRepo;
        private readonly IRepository<Student> studentRepo;
        private readonly IRepository<Teacher> teacherRepo;
        private readonly Func<IUnitOfWork> unitOfWork;
        private readonly ISubjectManagementService subjectManagementService;

        public RegistrationService(
            IRepository<IdentityRole> userRolesRepo,
            ISubjectManagementService subjectManagementService,
            IRepository<Student> studentRepo,
            IRepository<Teacher> teacherRepo,
            Func<IUnitOfWork> unitOfWork)
        {
            Guard.WhenArgument(userRolesRepo, "userRolesRepo").IsNull().Throw();
            Guard.WhenArgument(subjectManagementService, "subjectManagementService").IsNull().Throw();
            Guard.WhenArgument(studentRepo, "studentRepo").IsNull().Throw();
            Guard.WhenArgument(teacherRepo, "teacherRepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.userRolesRepo = userRolesRepo;
            this.subjectManagementService = subjectManagementService;
            this.studentRepo = studentRepo;
            this.teacherRepo = teacherRepo;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<IdentityRole> GetAllUserRoles()
        {
            return this.userRolesRepo.GetAll();
        }

        public void RegisterTeacher(string teacherId, IEnumerable<int> subjectId)
        {
            Guard.WhenArgument(teacherId, "teacherId").IsNullOrEmpty().Throw();
            Guard.WhenArgument(subjectId, "subjectId").IsNull().Throw();

            using (var uow = this.unitOfWork())
            {
                this.teacherRepo.Add(new Teacher()
                {
                    Id = teacherId,
                });

                var creatingTeacher = uow.Commit();

                if (creatingTeacher)
                {
                    this.subjectManagementService.AddSubjectsToTeacher(teacherId, subjectId);
                }
            }
        }

        public void RegisterStudent(string studentId, int classOfStudentId)
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
