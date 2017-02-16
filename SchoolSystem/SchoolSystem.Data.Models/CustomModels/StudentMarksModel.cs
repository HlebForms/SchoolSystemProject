using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Data.Models.CustomModels
{
    public class StudentMarksModel
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
