using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models
{
    public class SubjectStudent
    {
        [Key, Column(Order = 0)]
        public string StudentId { get; set; }

        [Key, Column(Order = 1)]
        public int SubjectId { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }

        public int Mark { get; set; }
    }
}
