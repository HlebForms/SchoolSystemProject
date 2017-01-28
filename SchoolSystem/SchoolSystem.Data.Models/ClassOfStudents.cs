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

        public ClassOfStudents()
        {
            this.students = new HashSet<Student>();
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
    }
}
