using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models
{
    public class SubjectClassOfStudents
    {
        [Key, Column(Order = 0)]
        public int SubjectId { get; set; }

        [Key, Column(Order = 1)]
        public int ClassOfStudentsId { get; set; }

        public int Proba { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual ClassOfStudents ClassOfStudents { get; set; }

    }
}
