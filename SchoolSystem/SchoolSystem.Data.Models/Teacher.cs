using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models
{
    public class Teacher
    {
        [ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        public virtual Subject Subject { get; set; }

        public int SubjectId { get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}
