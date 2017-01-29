using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models
{
    public class DaysOfWeek
    {
        private ICollection<SubjectClassOfStudentsDaysOfWeek> subjectClassOfStudentsDaysOfWeek;

        public DaysOfWeek()
        {
            this.subjectClassOfStudentsDaysOfWeek = new HashSet<SubjectClassOfStudentsDaysOfWeek>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<SubjectClassOfStudentsDaysOfWeek> SubjectClassOfStudentsDaysOfWeek
        {
            get { return this.subjectClassOfStudentsDaysOfWeek; }

            set { this.subjectClassOfStudentsDaysOfWeek = value; }
        }
    }
}
