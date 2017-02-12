using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models.CustomModels
{
    public class StudentMarks
    {
        public string SubjectName { get; set; }

        public IEnumerable<int> Marks { get; set; }

        public double Average
        {
            get
            {
                if (this.Marks == null)
                {
                    return 0;
                }

                return this.Marks.Average();
            }
        }
    }
}
