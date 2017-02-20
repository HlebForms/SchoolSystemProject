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
                   It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, ManagingScheduleModel>>>(),
                   It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, object>>[]>()))
                .Returns((Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>> predicate,
                          Expression<Func<SubjectClassOfStudentsDaysOfWeek, ManagingScheduleModel>> expression,
                          Expression<Func<SubjectClassOfStudentsDaysOfWeek, object>>[] include) =>
                    actual.Where(predicate.Compile()).Select(expression.Compile()));

            var expected = scheduleService.GetSchedulePerDay(1, 1);

            Assert.AreEqual(actual.Count(), expected.Count());
            CollectionAssert.AreNotEquivalent(expected, actual);
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
                   It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, ManagingScheduleModel>>>(),
                   It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, object>>[]>()))
            .Returns((Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>> predicate,
                      Expression<Func<SubjectClassOfStudentsDaysOfWeek, ManagingScheduleModel>> expression,
                      Expression<Func<SubjectClassOfStudentsDaysOfWeek, object>>[] include) =>
                actual.Where(predicate.Compile()).Select(expression.Compile()));

            var expected = scheduleService.GetSchedulePerDay(1, 1).ToList();

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

            scheduleService.GetSchedulePerDay(It.IsAny<int>(), It.IsAny<int>());

            mockedSubjectClassOfStudentsDaysOfWeekRepo.Verify(
                    x => x.GetAll(
                     It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>>>(),
                     It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, ManagingScheduleModel>>>(),
                     It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, object>>[]>()),
                     Times.Once);
        }
    }
}
