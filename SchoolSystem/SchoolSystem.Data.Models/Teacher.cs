using System.ComponentModel.DataAnnotations.Schema;

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
