namespace SchoolSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Common;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SchoolSystem.Data.SchoolSystemDbContext>
    {
        //private const string AdminRole = "Admin";
        //private const string TeacherRole = "Teacher";
        //private const string StudentRole = "Student";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SchoolSystemDbContext context)
        {
            this.RolesSeeder(context);
            this.SubjectSeeder(context);
            this.ClassOfStudentsSeeder(context);
            this.UsersSeeder(context);
            this.DaysOfWeekSeeder(context);
        }

        private void DaysOfWeekSeeder(SchoolSystemDbContext context)
        {
            context.DaysOfWeek.Add(new DaysOfWeek()
            {
                Name = "Понеделник"
            });

            context.DaysOfWeek.Add(new DaysOfWeek()
            {
                Name = "Вторник"
            });

            context.DaysOfWeek.Add(new DaysOfWeek()
            {
                Name = "Сряда"
            });

            context.DaysOfWeek.Add(new DaysOfWeek()
            {
                Name = "Четвъртък"
            });

            context.DaysOfWeek.Add(new DaysOfWeek()
            {
                Name = "Петък"
            });

            context.SaveChanges();
        }

        private void ClassOfStudentsSeeder(SchoolSystemDbContext context)
        {

            context.ClassOfStudents.AddOrUpdate(new ClassOfStudents()
            {
                Id = 1,
                Name = "12а",
                SubjectClassOfStudents = new HashSet<SubjectClassOfStudents>()
                {
                    new SubjectClassOfStudents() { SubjectId = 1, ClassOfStudentsId = 1 }
                }
            });

            context.SaveChanges();
        }

        private void SubjectSeeder(SchoolSystemDbContext context)
        {
            context.Subjects.AddOrUpdate(new Subject()
            {
                Id = 1,
                Name = "Математика",
            });

            context.Subjects.AddOrUpdate(new Subject()
            {
                Id = 2,
                Name = "ИТ"
            });

            context.SaveChanges();
        }

        private void RolesSeeder(SchoolSystemDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleAdmin = new IdentityRole() { Name = UserType.Admin };
            var roleTeacher = new IdentityRole() { Name = UserType.Teacher };
            var roleStudent = new IdentityRole() { Name = UserType.Student };

            if (!context.Roles.Any(role => role.Name == UserType.Admin))
            {
                roleManager.Create(roleAdmin);
            }

            if (!context.Roles.Any(role => role.Name == UserType.Teacher))
            {
                roleManager.Create(roleTeacher);
            }

            if (!context.Roles.Any(role => role.Name == UserType.Student))
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

                userManager.Create(adminUser, "admin123");
                userManager.AddToRole(adminUser.Id, UserType.Admin);
            }

            if (!context.Users.Any(u => u.UserName == "teacher@teacher.com"))
            {
                var teacherUser = new User { UserName = "teacher@teacher.com" };


                userManager.Create(teacherUser, "teacher123");
                userManager.AddToRole(teacherUser.Id, UserType.Teacher);
                context.Teachers.AddOrUpdate(new Teacher()
                {
                    Id = teacherUser.Id,
                    SubjectId = 1,
                });

                context.SaveChanges();
            }


            if (!context.Users.Any(u => u.UserName == "student@student.com"))
            {
                var studentUser = new User { UserName = "student@student.com" };

                userManager.Create(studentUser, "student123");
                userManager.AddToRole(studentUser.Id, UserType.Student);

                context.Students.AddOrUpdate(new Student()
                {
                    Id = studentUser.Id,
                    ClassOfStudentsId = 1,

                });
            }
        }
    }
}
