using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using System.Collections.Generic;

namespace SchoolSystem.WebForms.CustomControls.Teacher.Models
{
    public class ManagingMarksModel
    {
        public IEnumerable<ClassOfStudents> StudentClasses { get;  set; }

        public IEnumerable<SubjectBasicInfo> Subjects { get; set; }

        public IEnumerable<SchoolReportCard> SchoolReportCard { get; set; }

        public IEnumerable<StudentInfo> Students { get;  set; }

        public IEnumerable<Mark> Marks { get; set; }
    }
}