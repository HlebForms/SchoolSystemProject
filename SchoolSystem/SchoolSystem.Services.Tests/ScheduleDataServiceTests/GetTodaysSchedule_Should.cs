using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Services.Tests.ScheduleDataServiceTests
{
    [TestFixture]
    public class GetTodaysSchedule_Should
    {
        [Test]
        public void Throw_When_User_IsNotFound()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var scheduleService = new ScheduleDataService(
                      mockedSubjectRepo.Object,
                      mockedUserRepo.Object,
                      mockedTeacherRepo.Object,
                      mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                      mockedDaysOfWeekRepo.Object,
                      mockedStudentRepo.Object,
                      mockedUnitOfWork.Object);

            var user1 = new User() { Id = "random GUID 1", UserName = "user1" };
            var user2 = new User() { Id = "random GUID 2", UserName = "user2" };
            var user3 = new User() { Id = "random GUID 3", UserName = "user3" };

            var mockedUsers = new List<User>() { user1, user2, user3 };

            mockedUserRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>()))
                          .Returns((Expression<Func<User, bool>> predicate) =>
                          mockedUsers.FirstOrDefault(predicate.Compile()));
            mockedStudentRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Student, bool>>>()))
                             .Returns(new Student());
            mockedSubjectClassOfStudentsDaysOfWeekRepo.Setup(
                        x => x.GetAll(
                            It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>>>(),
                            It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, SubjectClassOfStudentsDaysOfWeek>>>()))
                       .Returns(new List<SubjectClassOfStudentsDaysOfWeek>());
            mockedTeacherRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Teacher, bool>>>()))
                             .Returns(new Teacher());


            var ex = Assert.Throws<ArgumentNullException>(() => scheduleService.GetTodaysSchedule(It.IsAny<DayOfWeek>(), "user4"));
            Assert.That(ex.ParamName, Is.EqualTo("user"));
        }

        [Test]
        public void Throw_When_UserClassOfStudents_IsNotFound()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var scheduleService = new ScheduleDataService(
                      mockedSubjectRepo.Object,
                      mockedUserRepo.Object,
                      mockedTeacherRepo.Object,
                      mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                      mockedDaysOfWeekRepo.Object,
                      mockedStudentRepo.Object,
                      mockedUnitOfWork.Object);

            var user1 = new User() { Id = "random GUID 1", UserName = "user1" };
            var user2 = new User() { Id = "random GUID 2", UserName = "user2" };
            var user3 = new User() { Id = "random GUID 3", UserName = "user3" };
            var classOfStudents1 = new ClassOfStudents() { Id = 1 };
            var classOfStudents2 = new ClassOfStudents() { Id = 2 };
            var classOfStudents3 = new ClassOfStudents() { Id = 3 };
            var student1 = new Student() { Id = user1.Id, ClassOfStudentsId = classOfStudents1.Id };
            var student2 = new Student() { Id = user2.Id, ClassOfStudentsId = classOfStudents1.Id };
            var mockedUsers = new List<User>() { user1, user2, user3 };
            var mockedStudents = new List<Student>() { student1, student2 };

            mockedUserRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>()))
                          .Returns((Expression<Func<User, bool>> predicate) =>
                          mockedUsers.FirstOrDefault(predicate.Compile()));

            mockedStudentRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Student, bool>>>()))
                             .Returns((Expression<Func<Student, bool>> predicate) =>
                             mockedStudents.FirstOrDefault(predicate.Compile()));

            mockedSubjectClassOfStudentsDaysOfWeekRepo.Setup(
                        x => x.GetAll(
                            It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>>>(),
                            It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, SubjectClassOfStudentsDaysOfWeek>>>()))
                       .Returns(new List<SubjectClassOfStudentsDaysOfWeek>());

            mockedTeacherRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Teacher, bool>>>()))
                             .Returns(new Teacher());

            var ex = Assert.Throws<ArgumentNullException>(
                () => scheduleService.GetTodaysSchedule(It.IsAny<DayOfWeek>(), "user3"));
            Assert.That(ex.ParamName, Is.EqualTo("userClassOfStudents"));
        }

        [Test]
        public void Throw_When_Teacher_IsNotFound()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var scheduleService = new ScheduleDataService(
                      mockedSubjectRepo.Object,
                      mockedUserRepo.Object,
                      mockedTeacherRepo.Object,
                      mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                      mockedDaysOfWeekRepo.Object,
                      mockedStudentRepo.Object,
                      mockedUnitOfWork.Object);

            var teacher1 = new Teacher() { SubjectId = 1, Id = "random GUID 1" };
            var teacher2 = new Teacher() { SubjectId = 2, Id = "random GUID 2" };
            var user1 = new User() { Id = "random GUID 1", UserName = "user1", Teacher = teacher1 };
            var user2 = new User() { Id = "random GUID 2", UserName = "user2", Teacher = teacher2 };
            var user3 = new User() { Id = "random GUID 3", UserName = "user3" };


            var student1 = new Student() { Id = user1.Id, User = user1, ClassOfStudentsId = 1 };
            var student2 = new Student() { Id = user2.Id, User = user2, ClassOfStudentsId = 2 };
            var student3 = new Student() { Id = user3.Id, User = user3, ClassOfStudentsId = 3 };
            var mockedStudents = new List<Student>() { student1, student2, student3 };

            var classOfStudents1 = new ClassOfStudents() { Id = 1, Students = mockedStudents };
            var classOfStudents2 = new ClassOfStudents() { Id = 2, Students = mockedStudents };
            var classOfStudents3 = new ClassOfStudents() { Id = 3, Students = mockedStudents };

            var mockedUsers = new List<User>() { user1, user2, user3 };
            var mockedTeachers = new List<Teacher>() { teacher1, teacher2 };
            var subjectClassOfStudents1 = new SubjectClassOfStudents() { ClassOfStudents = classOfStudents1, ClassOfStudentsId = 1 };
            var subjectClassOfStudents2 = new SubjectClassOfStudents() { ClassOfStudents = classOfStudents2, ClassOfStudentsId = 2 };
            var subjectClassOfStudents3 = new SubjectClassOfStudents() { ClassOfStudents = classOfStudents3, ClassOfStudentsId = 3 };
            var a = new SubjectClassOfStudentsDaysOfWeek() { ClassOfStudentsId = classOfStudents1.Id, DaysOfWeekId = 1, SubjectId = 1, SubjectClassOfStudents = subjectClassOfStudents1, DaysOfWeek = new DaysOfWeek() { Id = 1 } };
            var b = new SubjectClassOfStudentsDaysOfWeek() { ClassOfStudentsId = classOfStudents2.Id, DaysOfWeekId = 2, SubjectId = 2, SubjectClassOfStudents = subjectClassOfStudents2, DaysOfWeek = new DaysOfWeek() { Id = 2 } };
            var c = new SubjectClassOfStudentsDaysOfWeek() { ClassOfStudentsId = classOfStudents3.Id, DaysOfWeekId = 3, SubjectId = 3, SubjectClassOfStudents = subjectClassOfStudents3, DaysOfWeek = new DaysOfWeek() { Id = 3 } };
            var mockedSubjectClassOFstudentsDaysOfWeek =
                 new List<SubjectClassOfStudentsDaysOfWeek>() { a, b, c };

            mockedUserRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>()))
                          .Returns((Expression<Func<User, bool>> predicate) =>
                          mockedUsers.FirstOrDefault(predicate.Compile()));

            mockedStudentRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Student, bool>>>()))
                             .Returns((Expression<Func<Student, bool>> predicate) =>
                             mockedStudents.FirstOrDefault(predicate.Compile()));

            mockedSubjectClassOfStudentsDaysOfWeekRepo.Setup(
                        x => x.GetAll(
                            It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>>>(),
                            It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, SubjectClassOfStudentsDaysOfWeek>>>()))
                       .Returns((
                            Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>> predicate,
                            Expression<Func<SubjectClassOfStudentsDaysOfWeek, SubjectClassOfStudentsDaysOfWeek>> projection) =>
                        mockedSubjectClassOFstudentsDaysOfWeek.Where(predicate.Compile()).Select(projection.Compile()));

            mockedTeacherRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Teacher, bool>>>()))
                             .Returns((Expression<Func<Teacher, bool>> predicate) =>
                                   mockedTeachers.FirstOrDefault(predicate.Compile()));

            var ex = Assert.Throws<ArgumentNullException>(
                     () => scheduleService.GetTodaysSchedule(DayOfWeek.Wednesday, "user3"));
            Assert.That(ex.ParamName, Is.EqualTo("teacher"));
        }

        [Test]
        public void ReturnCorrectData_Overload1()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var scheduleService = new ScheduleDataService(
                      mockedSubjectRepo.Object,
                      mockedUserRepo.Object,
                      mockedTeacherRepo.Object,
                      mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                      mockedDaysOfWeekRepo.Object,
                      mockedStudentRepo.Object,
                      mockedUnitOfWork.Object);

            var teacher1 = new Teacher() { SubjectId = 1, Id = "random GUID 1", User = new User() { UserName = "test1" } };
            var teacher2 = new Teacher() { SubjectId = 2, Id = "random GUID 2", User = new User() { UserName = "test2" } };
            var teacher3 = new Teacher() { SubjectId = 3, Id = "random GUID 3", User = new User() { UserName = "test3" } };
            var user1 = new User() { Id = "random GUID 1", UserName = "user1", Teacher = teacher1 };
            var user2 = new User() { Id = "random GUID 2", UserName = "user2", Teacher = teacher2 };
            var user3 = new User() { Id = "random GUID 3", UserName = "user3", Teacher = teacher3 };


            var student1 = new Student() { Id = user1.Id, User = user1, ClassOfStudentsId = 1 };
            var student2 = new Student() { Id = user2.Id, User = user2, ClassOfStudentsId = 2 };
            var student3 = new Student() { Id = user3.Id, User = user3, ClassOfStudentsId = 3 };
            var mockedStudents = new List<Student>() { student1, student2, student3 };

            var classOfStudents1 = new ClassOfStudents() { Id = 1, Students = mockedStudents };
            var classOfStudents2 = new ClassOfStudents() { Id = 2, Students = mockedStudents };
            var classOfStudents3 = new ClassOfStudents() { Id = 3, Students = mockedStudents };

            var mockedUsers = new List<User>() { user1, user2, user3 };
            var mockedTeachers = new List<Teacher>() { teacher1, teacher2, teacher3 };
            var subjectClassOfStudents1 = new SubjectClassOfStudents() { ClassOfStudents = classOfStudents1, ClassOfStudentsId = 1, Subject = new Subject() { ImageUrl = "test url1", Name = "subj1" } };
            var a = new SubjectClassOfStudentsDaysOfWeek() { ClassOfStudentsId = classOfStudents1.Id, DaysOfWeekId = 3, SubjectId = 1, SubjectClassOfStudents = subjectClassOfStudents1, DaysOfWeek = new DaysOfWeek() { Id = 3 } };
            var b = new SubjectClassOfStudentsDaysOfWeek() { ClassOfStudentsId = classOfStudents1.Id, DaysOfWeekId = 3, SubjectId = 2, SubjectClassOfStudents = subjectClassOfStudents1, DaysOfWeek = new DaysOfWeek() { Id = 3 } };
            var c = new SubjectClassOfStudentsDaysOfWeek() { ClassOfStudentsId = classOfStudents1.Id, DaysOfWeekId = 3, SubjectId = 3, SubjectClassOfStudents = subjectClassOfStudents1, DaysOfWeek = new DaysOfWeek() { Id = 3 } };
            var mockedSubjectClassOFstudentsDaysOfWeek =
                 new List<SubjectClassOfStudentsDaysOfWeek>() { a, b, c };

            mockedUserRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>()))
                          .Returns((Expression<Func<User, bool>> predicate) =>
                          mockedUsers.FirstOrDefault(predicate.Compile()));

            mockedStudentRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Student, bool>>>()))
                             .Returns((Expression<Func<Student, bool>> predicate) =>
                             mockedStudents.FirstOrDefault(predicate.Compile()));

            mockedSubjectClassOfStudentsDaysOfWeekRepo.Setup(
                        x => x.GetAll(
                            It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>>>(),
                            It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, SubjectClassOfStudentsDaysOfWeek>>>()))
                       .Returns((
                            Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>> predicate,
                            Expression<Func<SubjectClassOfStudentsDaysOfWeek, SubjectClassOfStudentsDaysOfWeek>> projection) =>
                        mockedSubjectClassOFstudentsDaysOfWeek.Where(predicate.Compile()).Select(projection.Compile()));

            mockedTeacherRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Teacher, bool>>>()))
                             .Returns((Expression<Func<Teacher, bool>> predicate) =>
                                   mockedTeachers.FirstOrDefault(predicate.Compile()));

            var actual = scheduleService.GetTodaysSchedule(DayOfWeek.Wednesday, "user1");
            Assert.AreEqual(actual.Count(), 3);
        }

        [Test]
        public void ReturnCorrectData_Overload2()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var scheduleService = new ScheduleDataService(
                      mockedSubjectRepo.Object,
                      mockedUserRepo.Object,
                      mockedTeacherRepo.Object,
                      mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                      mockedDaysOfWeekRepo.Object,
                      mockedStudentRepo.Object,
                      mockedUnitOfWork.Object);

            var mockedSubjectClassOfStudentsDaysOfWeek = new SubjectClassOfStudentsDaysOfWeek()
            {
                DaysOfWeekId = 1,
                DaysOfWeek = new DaysOfWeek(),
                ClassOfStudentsId = 1,
                SubjectClassOfStudents = new SubjectClassOfStudents() { Subject = new Subject() },
                StartHour = DateTime.Now,
                EndHour = DateTime.Now
            };

            var actual = new List<SubjectClassOfStudentsDaysOfWeek>()
            {
                mockedSubjectClassOfStudentsDaysOfWeek,
                mockedSubjectClassOfStudentsDaysOfWeek,
                mockedSubjectClassOfStudentsDaysOfWeek
            };

            mockedSubjectClassOfStudentsDaysOfWeekRepo
            .Setup(x => x.GetAll(
                   It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>>>(),
                   It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, ManagingScheduleModel>>>())
             ).Returns(
                (Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>> predicate,
                 Expression<Func<SubjectClassOfStudentsDaysOfWeek, ManagingScheduleModel>> expression) =>
                actual.Where(predicate.Compile()).Select(expression.Compile()));

            var expected = scheduleService.GetTodaysSchedule(1, 1);

            Assert.AreEqual(actual.Count(), expected.Count());
        }

        [Test]
        public void Map_DataCorrectly_Overload2()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var scheduleService = new ScheduleDataService(
                      mockedSubjectRepo.Object,
                      mockedUserRepo.Object,
                      mockedTeacherRepo.Object,
                      mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                      mockedDaysOfWeekRepo.Object,
                      mockedStudentRepo.Object,
                      mockedUnitOfWork.Object);

            var mockedSubjectClassOfStudentsDaysOfWeek = new SubjectClassOfStudentsDaysOfWeek()
            {
                DaysOfWeekId = 1,
                DaysOfWeek = new DaysOfWeek(),
                ClassOfStudentsId = 1,
                SubjectClassOfStudents = new SubjectClassOfStudents() { Subject = new Subject() },
                StartHour = DateTime.Now,
                EndHour = DateTime.Now
            };

            var actual = new List<SubjectClassOfStudentsDaysOfWeek>()
            {
                mockedSubjectClassOfStudentsDaysOfWeek
            };

            mockedSubjectClassOfStudentsDaysOfWeekRepo
            .Setup(x => x.GetAll(
                   It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>>>(),
                   It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, ManagingScheduleModel>>>())
             ).Returns(
                (Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>> predicate,
                 Expression<Func<SubjectClassOfStudentsDaysOfWeek, ManagingScheduleModel>> expression) =>
                actual.Where(predicate.Compile()).Select(expression.Compile()));

            var expected = scheduleService.GetTodaysSchedule(1, 1).ToList();

            Assert.AreSame(actual[0].DaysOfWeek, expected[0].DaysOfWeek);
            Assert.AreEqual(actual[0].StartHour, expected[0].StartHour);
            Assert.AreEqual(actual[0].EndHour, expected[0].EndHour);
            Assert.AreSame(actual[0].SubjectClassOfStudents.Subject, expected[0].Subject);
        }

        [Test]
        public void Call_SubjectClassOfStudentsDaysOfWeekRepo_GetAllMethodOnce_Overload2()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var scheduleService = new ScheduleDataService(
                      mockedSubjectRepo.Object,
                      mockedUserRepo.Object,
                      mockedTeacherRepo.Object,
                      mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                      mockedDaysOfWeekRepo.Object,
                      mockedStudentRepo.Object,
                      mockedUnitOfWork.Object);

            scheduleService.GetTodaysSchedule(It.IsAny<int>(), It.IsAny<int>());

            mockedSubjectClassOfStudentsDaysOfWeekRepo.Verify(
                    x => x.GetAll(
                     It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>>>(),
                     It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, ManagingScheduleModel>>>()),
                     Times.Once);
        }
    }
}
