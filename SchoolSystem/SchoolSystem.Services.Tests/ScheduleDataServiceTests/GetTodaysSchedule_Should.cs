using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
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


            var ex = Assert.Throws<ArgumentNullException>(() => scheduleService.GetStudentScheduleForTheDay(It.IsAny<DayOfWeek>(), "user4"));
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
                () => scheduleService.GetStudentScheduleForTheDay(It.IsAny<DayOfWeek>(), "user3"));
            Assert.That(ex.ParamName, Is.EqualTo("userClassOfStudents"));
        }

        [Test]
        public void Throw_When_DaySchedule_IsNotFound()
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
            var student1 = new Student() { User = user1, ClassOfStudents = classOfStudents1 };
            var student2 = new Student() { User = user2, ClassOfStudents = classOfStudents2 };
            var student3 = new Student() { User = user3, ClassOfStudents = classOfStudents3 };
            var mockedUsers = new List<User>() { user1, user2, user3 };
            var mockedStudents = new List<Student>() { student1, student2, student3 };
            var mockedSubjectClassOFstudentsDaysOfWeek =
               new List<SubjectClassOfStudentsDaysOfWeek>() {
                    new SubjectClassOfStudentsDaysOfWeek() { ClassOfStudentsId = 1, DaysOfWeekId = 1 },
                    new SubjectClassOfStudentsDaysOfWeek() { ClassOfStudentsId = 2, DaysOfWeekId = 2 }
               };

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
                             .Returns(new Teacher());

            var ex = Assert.Throws<ArgumentNullException>(
                     () => scheduleService.GetStudentScheduleForTheDay(It.IsAny<DayOfWeek>(), "user3"));
            Assert.That(ex.ParamName, Is.EqualTo("userClassOfStudents"));
        }


    }
}
