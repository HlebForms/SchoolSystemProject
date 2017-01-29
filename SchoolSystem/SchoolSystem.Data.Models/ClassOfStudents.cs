using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models
{
    public class ClassOfStudents
    {
        private ICollection<Student> students;
        private ICollection<Subject> subjects;

        public ClassOfStudents()
        {
            this.students = new HashSet<Student>();
            this.subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }

        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Subject> Subjects
        {
            get { return this.subjects; }

            set { this.subjects = value; }
        }

        public bool IsDeleted { get; set; } = false;

    }
}
