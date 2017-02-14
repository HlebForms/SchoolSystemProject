using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using Bytes2you.Validation;

namespace SchoolSystem.Web.Services
{
    public class TeacherManagementService : ITeacherManagementService
    {
        private readonly IRepository<Teacher> teachersRepo;

        public TeacherManagementService(IRepository<Teacher> teachersRepo)
        {
            Guard.WhenArgument(teachersRepo, "teachersRepo").IsNull().Throw();

            this.teachersRepo = teachersRepo;
        }

        public IEnumerable<TeacherBasicInfo> GetAllTeachers()
        {
            return this.teachersRepo.GetAll(null,
                x => new TeacherBasicInfo()
                {
                    Id = x.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    UserName = x.User.UserName
                },
            x => x.User);

        }
    }
}
