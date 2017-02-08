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
            var culture = new System.Globalization.CultureInfo("bg-BG");

            context.DaysOfWeek.AddOrUpdate(new DaysOfWeek()
            {
                Id = 1,
                Name = culture.DateTimeFormat.GetDayName(DayOfWeek.Monday)
            });

            context.DaysOfWeek.AddOrUpdate(new DaysOfWeek()
            {
                Id = 2,
                Name = culture.DateTimeFormat.GetDayName(DayOfWeek.Tuesday)
            });

            context.DaysOfWeek.AddOrUpdate(new DaysOfWeek()
            {
                Id = 3,
                Name = culture.DateTimeFormat.GetDayName(DayOfWeek.Wednesday)
            });

            context.DaysOfWeek.AddOrUpdate(new DaysOfWeek()
            {
                Id = 4,
                Name = culture.DateTimeFormat.GetDayName(DayOfWeek.Thursday)
            });

            context.DaysOfWeek.AddOrUpdate(new DaysOfWeek()
            {
                Id = 5,
                Name = culture.DateTimeFormat.GetDayName(DayOfWeek.Friday)
            });

            context.DaysOfWeek.AddOrUpdate(new DaysOfWeek()
            {
                Id = 6,
                Name = culture.DateTimeFormat.GetDayName(DayOfWeek.Saturday)
            });

            context.DaysOfWeek.AddOrUpdate(new DaysOfWeek()
            {
                Id = 7,
                Name = culture.DateTimeFormat.GetDayName(DayOfWeek.Sunday)
            });

            context.SaveChanges();
        }

        private void ClassOfStudentsSeeder(SchoolSystemDbContext context)
        {

            context.ClassOfStudents.AddOrUpdate(new ClassOfStudents()
            {
                Id = 1,
                Name = "7 А",
                SubjectClassOfStudents = new HashSet<SubjectClassOfStudents>()
                {
                    new SubjectClassOfStudents() { SubjectId = 1, ClassOfStudentsId = 1 },
                    new SubjectClassOfStudents() { SubjectId = 2, ClassOfStudentsId = 1 },
                    new SubjectClassOfStudents() { SubjectId = 3, ClassOfStudentsId = 1 },
                    new SubjectClassOfStudents() { SubjectId = 10, ClassOfStudentsId = 1 },
                    new SubjectClassOfStudents() { SubjectId = 11, ClassOfStudentsId = 1 },
                    new SubjectClassOfStudents() { SubjectId = 12, ClassOfStudentsId = 1 }
                }
            });

            context.SaveChanges();
        }

        private void SubjectSeeder(SchoolSystemDbContext context)
        {
            context.Subjects.AddOrUpdate(new Subject()
            {
                Id = 1,
                Name = "Български",
                ImageUrl = "~/Images/subject_images/subject1.png"
            });

            context.Subjects.AddOrUpdate(new Subject()
            {
                Id = 2,
                Name = "Литература",
                ImageUrl = "~/Images/subject_images/subject2.png"
            });

            context.Subjects.AddOrUpdate(new Subject()
            {
                Id = 3,
                Name = "Математика",
                ImageUrl = "~/Images/subject_images/subject3.png"
            });

            context.Subjects.AddOrUpdate(new Subject()
            {
                Id = 4,
                Name = "Биология",
                ImageUrl = "~/Images/subject_images/subject4.png"
            });

            context.Subjects.AddOrUpdate(new Subject()
            {
                Id = 5,
                Name = "Физика",
                ImageUrl = "~/Images/subject_images/subject5.png"
            });

            context.Subjects.AddOrUpdate(new Subject()
            {
                Id = 6,
                Name = "Химия",
                ImageUrl = "~/Images/subject_images/subject6.png"
            });

            context.Subjects.AddOrUpdate(new Subject()
            {
                Id = 7,
                Name = "Музика",
                ImageUrl = "~/Images/subject_images/subject7.png"
            });

            context.Subjects.AddOrUpdate(new Subject()
            {
                Id = 8,
                Name = "Рисуване",
                ImageUrl = "~/Images/subject_images/subject8.png"
            });

            context.Subjects.AddOrUpdate(new Subject()
            {
                Id = 9,
                Name = "Информатика",
                ImageUrl = "~/Images/subject_images/subject12.png"
            });

            context.Subjects.AddOrUpdate(new Subject()
            {
                Id = 10,
                Name = "География",
                ImageUrl = "~/Images/subject_images/subject16.png"
            });

            context.Subjects.AddOrUpdate(new Subject()
            {
                Id = 11,
                Name = "Физкултура",
                ImageUrl = "~/Images/subject_images/subject23.png"
            });

            context.Subjects.AddOrUpdate(new Subject()
            {
                Id = 12,
                Name = "История",
                ImageUrl = "~/Images/subject_images/subject24.png"
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
                var adminUser = new User
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    AvatarPictureUrl = "~/Images/avatars/modified-avatar.png"
                };

                userManager.Create(adminUser, "admin123");
                userManager.AddToRole(adminUser.Id, UserType.Admin);
            }

            //if (!context.Users.Any(u => u.UserName == "teacher@teacher.com"))
            //{
            //    var teacherUser = new User { UserName = "teacher@teacher.com" };


            //    userManager.Create(teacherUser, "teacher123");
            //    userManager.AddToRole(teacherUser.Id, UserType.Teacher);
            //    context.Teachers.AddOrUpdate(new Teacher()
            //    {
            //        Id = teacherUser.Id,
            //        SubjectId = 1,
            //    });

            //    context.SaveChanges();
            //}


            //if (!context.Users.Any(u => u.UserName == "student@student.com"))
            //{
            //    var studentUser = new User { UserName = "student@student.com" };

            //    userManager.Create(studentUser, "student123");
            //    userManager.AddToRole(studentUser.Id, UserType.Student);

            //    context.Students.AddOrUpdate(new Student()
            //    {
            //        Id = studentUser.Id,
            //        ClassOfStudentsId = 1,

            //    });
            //}
        }
    }
}
