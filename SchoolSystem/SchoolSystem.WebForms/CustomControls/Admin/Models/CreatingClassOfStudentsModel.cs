using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using System.Collections.Generic;

namespace SchoolSystem.WebForms.CustomControls.Admin.Models
{
    public class CreatingClassOfStudentsModel
    {
        public IEnumerable<SubjectBasicInfo> Subjects { get; set; }

        public bool IsSuccesfull { get; set; }
    }
}