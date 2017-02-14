using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Data.Models
{
    public class SubjectStudent
    {
        [Key, Column(Order = 0)]
        public string StudentId { get; set; }

        [Key, Column(Order = 1)]
        public int SubjectId { get; set; }

        [Key, Column(Order = 2)]
        public int MarkId { get; set; }

        public int Count { get; set; }

        public virtual Mark Mark { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
