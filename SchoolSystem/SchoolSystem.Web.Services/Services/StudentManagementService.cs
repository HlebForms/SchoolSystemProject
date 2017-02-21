using System.Collections.Generic;
using Bytes2you.Validation;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Web.Services.Contracts;

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

        public IEnumerable<StudentInfoModel> GetAllStudentsFromClass(int classId)
        {
            var result = this.studentsRepo
                .GetAll(x => x.ClassOfStudentsId == classId,
                x => new StudentInfoModel()
                {
                    Id = x.Id,
                    Fullname = x.User.FirstName + x.User.LastName
                },
                i => i.User);

            return result;
        }
    }
}
