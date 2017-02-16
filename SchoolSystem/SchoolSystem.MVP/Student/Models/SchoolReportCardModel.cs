using System.Collections.Generic;

using SchoolSystem.Data.Models.CustomModels;

namespace SchoolSystem.MVP.Student.Models
{
    public class SchoolReportCardModel
    {
        public IEnumerable<StudentMarksModel> StudentMarks { get; set; }
    }
}