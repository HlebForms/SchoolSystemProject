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
    public class Constructor_Should
    {
        [Test]
        public void ThrowNullRefferenceException_When_subjectRepoIsNull()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new ScheduleDataService(
                    null,
                    mockedUserRepo.Object,
                    mockedTeacherRepo.Object,
                    mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                    mockedDaysOfWeekRepo.Object,
                    mockedStudentRepo.Object,
                    mockedUnitOfWork.Object);
            });
            Assert.That(ex.ParamName, Is.EqualTo("subjectRepo"));
        }

        [Test]
        public void ThrowNullRefferenceException_When_userRepoIsNull()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
             {
                 new ScheduleDataService(
                         mockedSubjectRepo.Object,
                        null,
                         mockedTeacherRepo.Object,
                         mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                         mockedDaysOfWeekRepo.Object,
                         mockedStudentRepo.Object,
                         mockedUnitOfWork.Object);
             });
            Assert.That(ex.ParamName, Is.EqualTo("userRepo"));
        }

        [Test]
        public void ThrowNullRefferenceException_When_teacherRepoIsNull()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new ScheduleDataService(
                        mockedSubjectRepo.Object,
                        mockedUserRepo.Object,
                        null,
                        mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                        mockedDaysOfWeekRepo.Object,
                        mockedStudentRepo.Object,
                        mockedUnitOfWork.Object);
            });
            Assert.That(ex.ParamName, Is.EqualTo("teacherRepo"));
        }

        [Test]
        public void ThrowNullRefferenceException_When_subjectClassOfStudentsDaysOfWeekRepoIsNull()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new ScheduleDataService(
                        mockedSubjectRepo.Object,
                        mockedUserRepo.Object,
                        mockedTeacherRepo.Object,
                        null,
                        mockedDaysOfWeekRepo.Object,
                        mockedStudentRepo.Object,
                        mockedUnitOfWork.Object);
            });
            Assert.That(ex.ParamName, Is.EqualTo("subjectClassOfStudentsDaysOfWeekRepo"));
        }

        [Test]
        public void ThrowNullRefferenceException_When_daysOfWeekRepoIsNull()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new ScheduleDataService(
                        mockedSubjectRepo.Object,
                        mockedUserRepo.Object,
                        mockedTeacherRepo.Object,
                        mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                        null,
                        mockedStudentRepo.Object,
                        mockedUnitOfWork.Object);
            });
            Assert.That(ex.ParamName, Is.EqualTo("daysOfWeekRepo"));
        }

        [Test]
        public void ThrowNullRefferenceException_When_studentRepoIsNull()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new ScheduleDataService(
                        mockedSubjectRepo.Object,
                        mockedUserRepo.Object,
                        mockedTeacherRepo.Object,
                        mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                        mockedDaysOfWeekRepo.Object,
                        null,
                        mockedUnitOfWork.Object);
            });
            Assert.That(ex.ParamName, Is.EqualTo("studentRepo"));
        }

        [Test]
        public void ThrowNullRefferenceException_When_unitOfWorkIsNull()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedSubjectClassOfStudentsDaysOfWeekRepo = new Mock<IRepository<SubjectClassOfStudentsDaysOfWeek>>();
            var mockedDaysOfWeekRepo = new Mock<IRepository<DaysOfWeek>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new ScheduleDataService(
                        mockedSubjectRepo.Object,
                        mockedUserRepo.Object,
                        mockedTeacherRepo.Object,
                        mockedSubjectClassOfStudentsDaysOfWeekRepo.Object,
                        mockedDaysOfWeekRepo.Object,
                        mockedStudentRepo.Object,
                        null);
            });
            Assert.That(ex.ParamName, Is.EqualTo("unitOfWork"));
        }

    }
}
