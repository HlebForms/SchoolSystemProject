using Microsoft.AspNet.Identity.EntityFramework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Web.Services
{
    public class UserRolesDataService : IUserRolesDataService
    {
        private readonly IRepository<IdentityRole> userRoles;

        public UserRolesDataService(IRepository<IdentityRole> userRoles)
        {
            this.userRoles = userRoles;
        }

        public IEnumerable<IdentityRole> GetAllUserRoles()
        {
           return this.userRoles.GetAll();
        }
    }
}
