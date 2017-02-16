using SchoolSystem.Data.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.MVP.Admin.Models
{
    public class AssignSubjectToTeacherModel
    {
        public IEnumerable<TeacherBasicInfoModel> Teachers { get; set; }

        public IEnumerable<SubjectBasicInfoModel> SubjectsWithoutTeacher { get; set; }

        public bool IsAddingSuccessfull { get; internal set; }
    }
}