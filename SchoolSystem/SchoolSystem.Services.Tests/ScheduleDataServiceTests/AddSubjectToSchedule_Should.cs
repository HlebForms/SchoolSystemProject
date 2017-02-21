using System;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;

namespace SchoolSystem.Services.Tests.ScheduleDataServiceTests
{
    [TestFixture]
    public class AddSubjectToSchedule_Should
    {
        [Test]
        public void CallAddMethod_FromSubjectClassOfStudentDaysOfWeekRepo_Once_AndReturnTrue_WhenDataIsValid()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            mockedUnitOfWork.Setup(x => x.Commit()).Returns(true);

            var scheduleService = new ScheduleDataService(
                      mockedSubjectRepo.Object,
                      mockedUserRepo.Object,
                      mockedTeacherRepo.Object,
                      mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                      mockedDaysOfWeekRepo.Object,
                      mockedStudentRepo.Object,
                     () => mockedUnitOfWork.Object);

            var resultOfAdding = scheduleService.AddSubjectToSchedule(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>());

            mockedSubjectClassOfStudentsDaysOfWeekRepo.Verify(x => x.Add(It.IsAny<SubjectClassOfStudentsDaysOfWeek>()), Times.Once);
            Assert.True(resultOfAdding);
        }

        [Test]
        public void CallAddMethod_FromSubjectClassOfStudentDaysOfWeekRepo_Once_AndReturnFalse_WhenDataIsNotValid()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            mockedUnitOfWork.Setup(x => x.Commit()).Returns(false);

            var scheduleService = new ScheduleDataService(
                      mockedSubjectRepo.Object,
                      mockedUserRepo.Object,
                      mockedTeacherRepo.Object,
                      mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                      mockedDaysOfWeekRepo.Object,
                      mockedStudentRepo.Object,
                     () => mockedUnitOfWork.Object);

            var resultOfAdding = scheduleService.AddSubjectToSchedule(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>());

            mockedSubjectClassOfStudentsDaysOfWeekRepo.Verify(x => x.Add(It.IsAny<SubjectClassOfStudentsDaysOfWeek>()), Times.Once);
            Assert.False(resultOfAdding);
        }

        [Test]
        public void CallAddMethod_FromSubjectClassOfStudentDaysOfWeekRepo_Once_AndReturnFalse_WhenExceptionIsThrown()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            mockedUnitOfWork.Setup(x => x.Commit()).Throws(new Exception());

            var scheduleService = new ScheduleDataService(
                      mockedSubjectRepo.Object,
                      mockedUserRepo.Object,
                      mockedTeacherRepo.Object,
                      mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                      mockedDaysOfWeekRepo.Object,
                      mockedStudentRepo.Object,
                     () => mockedUnitOfWork.Object);

            var resultOfAdding = scheduleService.AddSubjectToSchedule(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>());

            mockedSubjectClassOfStudentsDaysOfWeekRepo.Verify(x => x.Add(It.IsAny<SubjectClassOfStudentsDaysOfWeek>()), Times.Once);
            Assert.False(resultOfAdding);
        }
    }
}
