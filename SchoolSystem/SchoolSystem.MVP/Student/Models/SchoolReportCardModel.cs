using SchoolSystem.Data.Models.CustomModels;
using System.Collections.Generic;

namespace SchoolSystem.MVP.Student.Models
{
    public class SchoolReportCardModel
    {
        public IEnumerable<StudentMarks> StudentMarks { get; set; }
    }
}