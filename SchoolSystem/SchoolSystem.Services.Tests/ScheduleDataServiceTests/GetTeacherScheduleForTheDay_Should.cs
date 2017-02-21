using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Web.Services;

namespace SchoolSystem.Services.Tests.ScheduleDataServiceTests
{
    [TestFixture]
    public class GetTeacherScheduleForTheDay_Should
    {
        [Test]
        public void ThrowArgumentException_WithMessageContaining_Username_WhenUserNameIsNull()
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

            Assert.That(
                () => scheduleService.GetTeacherScheduleForTheDay(It.IsAny<DayOfWeek>(), null),
                Throws.ArgumentNullException.With.Message.Contain("username"));
        }

        [Test]
        public void Throw_ArgumentException_WithMessageContaining_Username_WhenUserNameIsEmptyString()
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

            Assert.That(
                () => scheduleService.GetTeacherScheduleForTheDay(It.IsAny<DayOfWeek>(), string.Empty),
                Throws.ArgumentException.With.Message.Contain("username"));
        }

        [Test]
        public void Return_EmptyCollection_AndCallGetFirstMethodFromUserRepoOnce_WhenUserFoundIsNull()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            User expectedReturnFromRepo = null;
            mockedUserRepo
                .Setup(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(expectedReturnFromRepo);

            var scheduleService = new ScheduleDataService(
                      mockedSubjectRepo.Object,
                      mockedUserRepo.Object,
                      mockedTeacherRepo.Object,
                      mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                      mockedDaysOfWeekRepo.Object,
                      mockedStudentRepo.Object,
                      mockedUnitOfWork.Object);

            var result = scheduleService.GetTeacherScheduleForTheDay(It.IsIn<DayOfWeek>(), "NotNullUserName");

            mockedUserRepo.Verify(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
            mockedStudentRepo.Verify(x => x.GetFirst(It.IsAny<Expression<Func<Student, bool>>>()), Times.Never);
            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void Return_EmptyCollection_WhenTeacherDoesNotHaveAssignedProgram()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            mockedUserRepo
               .Setup(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>()))
               .Returns(new User());

            mockedSubjectRepo
                .Setup(x => x.GetAll(It.IsAny<Expression<Func<Subject, bool>>>(), It.IsAny<Expression<Func<Subject, int>>>()))
                .Returns(new List<int>());

            var scheduleService = new ScheduleDataService(
                      mockedSubjectRepo.Object,
                      mockedUserRepo.Object,
                      mockedTeacherRepo.Object,
                      mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                      mockedDaysOfWeekRepo.Object,
                      mockedStudentRepo.Object,
                      mockedUnitOfWork.Object);

            var result = scheduleService.GetTeacherScheduleForTheDay(It.IsIn<DayOfWeek>(), "NotNullUserName");

            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void ReturnCorrectlyMappedData()
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

            var teacherName = "Pesho";
            var user = new User()
            {
                UserName = teacherName
            };

            mockedUserRepo
                .Setup(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(user);

            var classOfStudnetsName = "ClassOfStudentsName";
            var classOfStudents = new ClassOfStudents()
            {
                Id = 1,
                Name = classOfStudnetsName
            };

            var subjectId = 1;
            var subjectIds = new List<int>() { subjectId };
            mockedSubjectRepo
                .Setup(x => x.GetAll(It.IsAny<Expression<Func<Subject, bool>>>(), It.IsAny<Expression<Func<Subject, int>>>()))
                .Returns(subjectIds);

            DayOfWeek dayOfWeek = DayOfWeek.Monday;
            var day = new DaysOfWeek() { Id = 1, Name = dayOfWeek.ToString() };

            var startHour = It.IsAny<DateTime>();
            var endHour = It.IsAny<DateTime>();

            var subjectName = "test";

            var teacher = new Teacher()
            {
                User = user
            };

            var subject = new Subject()
            {
                Name = subjectName,
                Teacher = teacher,
                Id = subjectId,
                ImageUrl = "UrlToTheImage"
            };

            var subjectsClassOfStudnets = new SubjectClassOfStudents()
            {
                ClassOfStudentsId = 1,
                Subject = subject,
                ClassOfStudents = classOfStudents
            };

            var data = new List<SubjectClassOfStudentsDaysOfWeek>()
            {
                new SubjectClassOfStudentsDaysOfWeek()
                {
                    SubjectClassOfStudents = subjectsClassOfStudnets,
                    StartHour = startHour,
                    EndHour = endHour,
                    ClassOfStudentsId = 1,
                    DaysOfWeekId = 1,
                    SubjectId = 1,
                    DaysOfWeek = day
                }
            };

            IEnumerable<ScheduleModel> expectedResult = null;
            mockedSubjectClassOfStudentsDaysOfWeekRepo
                .Setup(
                x => x.GetAll(
                It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>>>(),
                It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, ScheduleModel>>>(),
                It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, object>>[]>()))
            .Returns((Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>> predicate,
                      Expression<Func<SubjectClassOfStudentsDaysOfWeek, ScheduleModel>> expression,
                      Expression<Func<SubjectClassOfStudentsDaysOfWeek, object>>[] include) =>
            {
                expectedResult = data.Where(predicate.Compile()).Select(expression.Compile()).ToList();
                return expectedResult;
            });

            // ACT
            var result = scheduleService.GetTeacherScheduleForTheDay(dayOfWeek, teacherName).ToList();

            CollectionAssert.AreEquivalent(expectedResult, result);
        }
    }
}