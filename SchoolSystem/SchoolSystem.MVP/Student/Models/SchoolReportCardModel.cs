using SchoolSystem.Data.Models.CustomModels;
using System.Collections.Generic;

namespace SchoolSystem.MVP.Student.Models
{
    public class SchoolReportCardModel
    {
        public IEnumerable<StudentMarksModel> StudentMarks { get; set; }
    }
}