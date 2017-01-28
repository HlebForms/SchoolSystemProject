namespace SchoolSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SchoolSystem.Data.SchoolSystemDbContext>
    {
        private const string AdminRole = "Admin";
        private const string TeacherRole = "Teacher";
        private const string StudentRole = "Student";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SchoolSystem.Data.SchoolSystemDbContext context)
        {
            this.RolesSeeder(context);
            this.UsersSeeder(context);
        }

        private void RolesSeeder(SchoolSystemDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleAdmin = new IdentityRole() { Name = AdminRole };
            var roleTeacher = new IdentityRole() { Name = TeacherRole };
            var roleStudent = new IdentityRole() { Name = StudentRole };

            if (!context.Roles.Any(role => role.Name == AdminRole))
            {
                roleManager.Create(roleAdmin);
            }

            if (!context.Roles.Any(role => role.Name == TeacherRole))
            {
                roleManager.Create(roleTeacher);
            }

            if (!context.Roles.Any(role => role.Name == StudentRole))
            {
                roleManager.Create(roleStudent);
            }
        }

        private void UsersSeeder(SchoolSystemDbContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var adminUser = new User { UserName = "admin@admin.com" };

                userManager.Create(adminUser, "admin");
                userManager.AddToRole(adminUser.Id, AdminRole);
            }

            if (!context.Users.Any(u => u.UserName == "teacher@teacher.com"))
            {
                var teacherUser = new User { UserName = "teacher@teacher.com" };

                userManager.Create(teacherUser, "teacher");
                userManager.AddToRole(teacherUser.Id, TeacherRole);
            }

            if (!context.Users.Any(u => u.UserName == "student@student.com"))
            {
                var studentUser = new User { UserName = "student@student.com" };

                userManager.Create(studentUser, "student");
                userManager.AddToRole(studentUser.Id, StudentRole);
            }
        }
    }
}
