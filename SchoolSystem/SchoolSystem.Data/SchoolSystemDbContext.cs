using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolSystem.Data
{
    public class SchoolSystemDbContext : IdentityDbContext<User>, ISchoolSystemDBContext
    {
        public SchoolSystemDbContext()
            : base("SchoolSystemDB", throwIfV1Schema: false)
        {
        }

        public static SchoolSystemDbContext Create()
        {
            return new SchoolSystemDbContext();
        }

        public IDbSet<Teacher> Teachers { get; set; }

        public IDbSet<Mark> Marks { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Newsfeed> NewsFeed { get; set; }

        public IDbSet<Subject> Subjects { get; set; }

        public IDbSet<ClassOfStudents> ClassOfStudents { get; set; }

        public IDbSet<SubjectClassOfStudents> SubjectClassOfStudents { get; set; }

        public IDbSet<SubjectStudent> SubjectStudent { get; set; }

        public IDbSet<DaysOfWeek> DaysOfWeek { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
        }
    }
}
