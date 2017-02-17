using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Services.Tests.ScheduleDataServiceTests
{
    [TestFixture]
    public class GetAllDaysOfWeek_Should
    {
        [Test]
        public void ReturnAllDaysOfWeek()
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

            IEnumerable<DaysOfWeek> actual = new List<DaysOfWeek>()
            {
                new DaysOfWeek(),
                new DaysOfWeek(),
                new DaysOfWeek()
            };

            mockedDaysOfWeekRepo.Setup(x => x.GetAll()).Returns(actual);

            var expected = scheduleService.GetAllDaysOfWeek();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void Call_daysOfWeekRepoGetAll_MethodOnce()
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

            scheduleService.GetAllDaysOfWeek();

            mockedDaysOfWeekRepo.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
