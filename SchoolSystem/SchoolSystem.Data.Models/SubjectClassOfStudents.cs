using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Data.Models
{
    public class SubjectClassOfStudents
    {
        private ICollection<SubjectClassOfStudentsDaysOfWeek> subjectClassOfStudentsDaysOfWeek;

        public SubjectClassOfStudents()
        {
            this.subjectClassOfStudentsDaysOfWeek = new HashSet<SubjectClassOfStudentsDaysOfWeek>();
        }


        [Key, Column(Order = 0)]
        public int SubjectId { get; set; }

        [Key, Column(Order = 1)]
        public int ClassOfStudentsId { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual ClassOfStudents ClassOfStudents { get; set; }

        public virtual ICollection<SubjectClassOfStudentsDaysOfWeek> SubjectClassOfStudentsDaysOfWeek
        {
            get { return this.subjectClassOfStudentsDaysOfWeek; }

            set { this.subjectClassOfStudentsDaysOfWeek = value; }
        }

    }
}
