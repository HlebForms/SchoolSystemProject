using SchoolSystem.Data.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Admin.Models
{
    public class AssignSubjectToTeacherModel
    {
        public IEnumerable<TeacherBasicInfo> Teachers { get; set; }

        public IEnumerable<SubjectBasicInfo> SubjectsWithoutTeacher { get; set; }
        public bool IsAddingSuccessfull { get; internal set; }
    }
}