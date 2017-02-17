using System.Collections.Generic;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;

namespace SchoolSystem.MVP.Account.Models
{
    public class RegistrationModel
    {
        public IdentityResult Result { get; set; }

        public IEnumerable<IdentityRole> UserRoles { get; set; }

        public IEnumerable<ClassOfStudents> ClassOfStudents { get; set; }

        public IEnumerable<SubjectBasicInfoModel> Subjects { get; set; }
    }
}