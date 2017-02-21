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
    public class RemoveSubjectFromSchedule_Should
    {
        [Test]
        public void CallDeleteMethodFromSubjectClassOfStudentsDaysOfWeekRepoOnce_AndCommitMethodFromUoWOnce_WhenItemFoundIsNotNull()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var expected = new SubjectClassOfStudentsDaysOfWeek();
            mockedSubjectClassOfStudentsDaysOfWeekRepo
                .Setup(x => x.GetFirst(It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>>>()))
                .Returns(expected);

            mockedSubjectClassOfStudentsDaysOfWeekRepo.Setup(x => x.Delete(It.IsAny<SubjectClassOfStudentsDaysOfWeek>()));

            var scheduleService = new ScheduleDataService(
                          mockedSubjectRepo.Object,
                          mockedUserRepo.Object,
                          mockedTeacherRepo.Object,
                          mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                          mockedDaysOfWeekRepo.Object,
                          mockedStudentRepo.Object,
                         () => mockedUnitOfWork.Object);

            scheduleService.RemoveSubjectFromSchedule(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>());
            mockedSubjectClassOfStudentsDaysOfWeekRepo.Verify(x => x.Delete(expected), Times.Once);
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void NotCallDeleteMethodFromSubjectClassOfStudentsDaysOfWeekRepo_AndCommitMethodFromUoWN_WhenItemFoundIsNull()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            SubjectClassOfStudentsDaysOfWeek expected = null;
            mockedSubjectClassOfStudentsDaysOfWeekRepo
              .Setup(x => x.GetFirst(It.IsAny<Expression<Func<SubjectClassOfStudentsDaysOfWeek, bool>>>()))
              .Returns(expected);

            var scheduleService = new ScheduleDataService(
                      mockedSubjectRepo.Object,
                      mockedUserRepo.Object,
                      mockedTeacherRepo.Object,
                      mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                      mockedDaysOfWeekRepo.Object,
                      mockedStudentRepo.Object,
                     () => mockedUnitOfWork.Object);

            scheduleService.RemoveSubjectFromSchedule(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>());
            mockedSubjectClassOfStudentsDaysOfWeekRepo.Verify(x => x.Delete(It.IsAny<SubjectClassOfStudentsDaysOfWeek>()), Times.Never);
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Never);
        }
    }
}
