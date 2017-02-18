using System.Collections.Generic;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;

namespace SchoolSystem.MVP.Teacher.Models
{
    public class ManagingMarksModel
    {
        public IEnumerable<ClassOfStudents> StudentClasses { get;  set; }

        public IEnumerable<SubjectBasicInfoModel> Subjects { get; set; }

        public IEnumerable<SchoolReportCardModel> SchoolReportCard { get; set; }

        public IEnumerable<StudentInfoModel> Students { get;  set; }

        public IEnumerable<Mark> Marks { get; set; }
    }
}