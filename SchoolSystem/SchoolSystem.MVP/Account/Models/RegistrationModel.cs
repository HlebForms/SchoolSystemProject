using System.Collections.Generic;

using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Data.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolSystem.MVP.Account.Models
{
    public class RegistrationModel
    {
        public IdentityResult Result { get; set; }

        public IEnumerable<IdentityRole> UserRoles { get; set; }

        public IEnumerable<ClassOfStudents> ClassOfStudents { get; set; }

        public IEnumerable<SubjectBasicInfo> Subjects { get; set; }
    }
}