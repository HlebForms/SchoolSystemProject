using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
