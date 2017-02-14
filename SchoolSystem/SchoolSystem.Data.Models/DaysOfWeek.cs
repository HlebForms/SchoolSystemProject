using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<SubjectClassOfStudentsDaysOfWeek> SubjectClassOfStudentsDaysOfWeek
        {
            get { return this.subjectClassOfStudentsDaysOfWeek; }

            set { this.subjectClassOfStudentsDaysOfWeek = value; }
        }
    }
}
