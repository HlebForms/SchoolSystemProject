using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Data.Models
{
    public class Newsfeed
    {
        public int Id { get; set; }

        [MinLength(5)]
        [MaxLength(200)]
        public string Content { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsImportant { get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}
