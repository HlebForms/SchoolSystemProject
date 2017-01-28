using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models
{
    public class Subject
    {
        private ICollection<SubjectStudent> studentSubj;
        private ICollection<Teacher> teachers;

        public Subject()
        {
            this.studentSubj = new HashSet<SubjectStudent>();
            this.teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<SubjectStudent> StudentSubj
        {
            get { return this.studentSubj; }
            set { this.studentSubj = value; }
        }

        public ICollection<Teacher> Teachers
        {
            get { return this.teachers; }

            set { this.teachers = value; }
        }
    }
}
