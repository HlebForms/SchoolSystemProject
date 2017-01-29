using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models
{
    public class Student
    {
        private ICollection<SubjectStudent> studentSubj;
        //private ICollection<SubjectClassOfStudents> subjecClassOfStudents;
        public Student()
        {
            this.studentSubj = new HashSet<SubjectStudent>();
            //this.subjecClassOfStudents = new HashSet<SubjectClassOfStudents>();
        }

        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        public int ClassOfStudentsId { get; set; }

        public virtual ClassOfStudents ClassOfStudents { get; set; }

        public virtual ICollection<SubjectStudent> StudentSubj
        {
            get { return this.studentSubj; }
            set { this.studentSubj = value; }
        }

        public bool IsDeleted { get; set; } = false;

        //public virtual ICollection<SubjectClassOfStudents> SubjecClassOfStudents
        //{
        //    get { return this.subjecClassOfStudents; }

        //    set { this.subjecClassOfStudents = value; }
        //}
    }
}
