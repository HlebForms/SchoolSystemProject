using System.Collections.Generic;

using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;

namespace SchoolSystem.WebForms.CustomControls.Admin.Models
{
    public class AssignSubjectsToClassOfStudentsModel
    {
        public IEnumerable<SubjectBasicInfo> AvailableSubjects { get; set; }

        public IEnumerable<ClassOfStudents> ClassOfStudents { get; set; }

        public bool IsAddingSubjectsSuccesfull { get; set; }
    }
}