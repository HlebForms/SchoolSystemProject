using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Data.Models
{
    public class Teacher
    {
        private ICollection<Subject> subjects;

        public Teacher()
        {
            this.subjects = new HashSet<Subject>();
        }

        [ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Subject> Subjects
        {
            get { return this.subjects; }
            set { this.subjects = value; }
        }

        public bool IsDeleted { get; set; } = false;
    }
}
