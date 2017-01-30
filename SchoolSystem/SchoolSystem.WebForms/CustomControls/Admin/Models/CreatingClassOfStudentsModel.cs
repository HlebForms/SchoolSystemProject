using SchoolSystem.Data.Models;
using System.Collections.Generic;

namespace SchoolSystem.WebForms.CustomControls.Admin.Models
{
    public class CreatingClassOfStudentsModel
    {
        public IEnumerable<Subject> Subjects { get; set; }

        public bool IsSuccesfull { get; set; }
    }
}