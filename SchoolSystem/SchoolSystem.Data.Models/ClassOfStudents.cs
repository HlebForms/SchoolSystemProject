using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models
{
    public class ClassOfStudents
    {
        private ICollection<Student> students;

        public ClassOfStudents()
        {
            this.students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
