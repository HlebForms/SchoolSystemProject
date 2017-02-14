using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Data.Models
{
    public class Subject
    {
        private ICollection<SubjectStudent> studentSubj;
        //private ICollection<Teacher> teachers;
        private ICollection<SubjectClassOfStudents> subjecClassOfStudents;

        public Subject()
        {
            this.studentSubj = new HashSet<SubjectStudent>();
            //this.teachers = new HashSet<Teacher>();
            this.subjecClassOfStudents = new HashSet<SubjectClassOfStudents>();
        }

        public int Id { get; set; }

        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<SubjectStudent> StudentSubj
        {
            get { return this.studentSubj; }
            set { this.studentSubj = value; }
        }

        public string TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }
        //public virtual ICollection<Teacher> Teachers
        //{
        //    get { return this.teachers; }

        //    set { this.teachers = value; }
        //}       

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<SubjectClassOfStudents> SubjecClassOfStudents
        {
            get { return this.subjecClassOfStudents; }

            set { this.subjecClassOfStudents = value; }
        }
    }
}
