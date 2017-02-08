using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolSystem.Data.Models;
using System.Collections.Generic;

namespace SchoolSystem.WebForms.Account.Models
{
    public class RegistrationModel
    {
        public IdentityResult Result { get; set; }

        public IEnumerable<IdentityRole> UserRoles { get; set; }

        public IEnumerable<ClassOfStudents> ClassOfStudents { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }

    }
}