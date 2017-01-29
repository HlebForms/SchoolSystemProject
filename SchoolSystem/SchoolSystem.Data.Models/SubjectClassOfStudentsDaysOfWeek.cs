using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models
{
    public class SubjectClassOfStudentsDaysOfWeek
    {
        [Key, Column(Order = 0) ,ForeignKey("DaysOfWeek")]
        public int DaysOfWeekId { get; set; }

        [Key, Column(Order = 1), ForeignKey("SubjectClassOfStudents")]
        public int SubjectId { get; set; }

        [Key, Column(Order = 2), ForeignKey("SubjectClassOfStudents")]
        public int ClassOfStudentsId { get; set; }

        public virtual DaysOfWeek DaysOfWeek { get; set; }

        public virtual SubjectClassOfStudents SubjectClassOfStudents { get; set; }

        public DateTime StartHour { get; set; }

        public DateTime EndHour { get; set; }
    }
}
