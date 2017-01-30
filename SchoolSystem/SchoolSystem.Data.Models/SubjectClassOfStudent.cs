using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models
{
    public class SubjectClassOfStudent
    {
        [Key, Column(Order = 0)]
        public int ClassOfStudentId { get; set; }

        [Key, Column(Order = 1)]
        public int SubjectId { get; set; }

        public virtual ClassOfStudent ClassOfStudent { get; set; }

        public virtual Subject Subject { get; set; }

        public bool IsDeleted { get; set; }
    }
}
