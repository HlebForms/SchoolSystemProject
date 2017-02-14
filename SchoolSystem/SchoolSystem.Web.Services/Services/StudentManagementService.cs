using System.Collections.Generic;

using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;

using Bytes2you.Validation;

namespace SchoolSystem.Web.Services
{
    public class StudentManagementService : IStudentManagementService
    {
        private readonly IRepository<Student> studentsRepo;

        public StudentManagementService(IRepository<Student> studentsRepo)
        {
            Guard.WhenArgument(studentsRepo, "studentsRepo").IsNull().Throw();

            this.studentsRepo = studentsRepo;
        }

        public IEnumerable<StudentInfo> GetAllStudentsFromClass(int classId)
        {
            return this.studentsRepo
                .GetAll(x => x.ClassOfStudentsId == classId,
                x => new StudentInfo()
                {
                    Id = x.Id,
                    Fullname = x.User.FirstName + x.User.LastName
                });
        }
    }
}
