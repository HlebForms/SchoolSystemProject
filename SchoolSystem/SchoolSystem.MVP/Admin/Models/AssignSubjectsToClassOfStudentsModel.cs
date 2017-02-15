using System.Collections.Generic;

using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;

namespace SchoolSystem.MVP.Admin.Models
{
    public class AssignSubjectsToClassOfStudentsModel
    {
        public IEnumerable<SubjectBasicInfoModel> AvailableSubjects { get; set; }

        public IEnumerable<ClassOfStudents> ClassOfStudents { get; set; }

        public bool IsAddingSubjectsSuccesfull { get; set; }
    }
}