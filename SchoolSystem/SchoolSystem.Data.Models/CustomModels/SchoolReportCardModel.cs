using System.Collections.Generic;

namespace SchoolSystem.Data.Models.CustomModels
{
    public class SchoolReportCardModel
    {
        public string StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> Grades { get; set; }
    }
}
