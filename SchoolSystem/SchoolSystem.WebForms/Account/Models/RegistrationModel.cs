using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using System.Collections.Generic;

namespace SchoolSystem.WebForms.Account.Models
{
    public class RegistrationModel
    {
        public IdentityResult Result { get; set; }

        public IEnumerable<IdentityRole> UserRoles { get; set; }

        public IEnumerable<ClassOfStudents> ClassOfStudents { get; set; }

        public IEnumerable<SubjectBasicInfo> Subjects { get; set; }

    }
}