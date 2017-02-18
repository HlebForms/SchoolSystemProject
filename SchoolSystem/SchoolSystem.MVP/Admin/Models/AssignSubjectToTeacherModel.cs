using System.Collections.Generic;
using SchoolSystem.Data.Models.CustomModels;

namespace SchoolSystem.MVP.Admin.Models
{
    public class AssignSubjectToTeacherModel
    {
        public IEnumerable<TeacherBasicInfoModel> Teachers { get; set; }

        public IEnumerable<SubjectBasicInfoModel> SubjectsWithoutTeacher { get; set; }

        public bool IsAddingSuccessfull { get; internal set; }
    }
}