using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models
{
    public class Subject
    {
        private ICollection<SubjectStudent> studentSubj;
        private ICollection<Teacher> teachers;
        private ICollection<ClassOfStudents> classOfStudents;

        public Subject()
        {
            this.studentSubj = new HashSet<SubjectStudent>();
            this.teachers = new HashSet<Teacher>();
            this.classOfStudents = new HashSet<ClassOfStudents>();
        }

        public int Id { get; set; }

        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<SubjectStudent> StudentSubj
        {
            get { return this.studentSubj; }
            set { this.studentSubj = value; }
        }

        public virtual ICollection<Teacher> Teachers
        {
            get { return this.teachers; }

            set { this.teachers = value; }
        }

        public virtual ICollection<ClassOfStudents> ClassOfStudents
        {
            get { return this.classOfStudents; }
            set { this.classOfStudents = value; }
        }

        public bool IsDeleted { get; set; } = false;

    }
}
