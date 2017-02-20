using Microsoft.AspNet.Identity.EntityFramework;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;
using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Services.Tests.RegistrationServiceTests
{
    [TestFixture]
    public class RegisterTeacher_Should
    {
        [Test]
        public void Throw_When_TeacherId_IsEmpty()
        {
            var mockedUserRolesRepo = new Mock<IRepository<IdentityRole>>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var service = new RegistrationService(
                mockedUserRolesRepo.Object,
                mockedSubjectManagementService.Object,
                mockedStudentRepo.Object,
                mockedTeacherRepo.Object,
                mockedUnitOfWork.Object);

            var ex = Assert.Throws<ArgumentException>(
                () => service.RegisterTeacher(string.Empty, It.IsAny<IEnumerable<int>>()));

            Assert.That(ex.ParamName, Is.EqualTo("teacherId"));
        }

        [Test]
        public void Throw_When_TeacherId_Null()
        {
            var mockedUserRolesRepo = new Mock<IRepository<IdentityRole>>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var service = new RegistrationService(
                mockedUserRolesRepo.Object,
                mockedSubjectManagementService.Object,
                mockedStudentRepo.Object,
                mockedTeacherRepo.Object,
                mockedUnitOfWork.Object);

            var ex = Assert.Throws<ArgumentNullException>(
                () => service.RegisterTeacher(null, It.IsAny<IEnumerable<int>>()));

            Assert.That(ex.ParamName, Is.EqualTo("teacherId"));
        }

        [Test]
        public void Throw_When_SubjectId_Null()
        {
            var mockedUserRolesRepo = new Mock<IRepository<IdentityRole>>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var service = new RegistrationService(
                mockedUserRolesRepo.Object,
                mockedSubjectManagementService.Object,
                mockedStudentRepo.Object,
                mockedTeacherRepo.Object,
                mockedUnitOfWork.Object);

            var ex = Assert.Throws<ArgumentNullException>(
                () => service.RegisterTeacher("random string", null));

            Assert.That(ex.ParamName, Is.EqualTo("subjectId"));
        }

        [Test]
        public void Call_UnitOfWork_Commit_Method_Once()
        {
            var mockedUserRolesRepo = new Mock<IRepository<IdentityRole>>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new RegistrationService(
                mockedUserRolesRepo.Object,
                mockedSubjectManagementService.Object,
                mockedStudentRepo.Object,
                mockedTeacherRepo.Object,
                () => mockedUnitOfWork.Object);

            mockedTeacherRepo.Setup(x => x.Add(It.IsAny<Teacher>()));
            mockedSubjectManagementService.Setup(x => x.AddSubjectsToTeacher(It.IsAny<string>(), It.IsAny<IEnumerable<int>>()));

            service.RegisterTeacher("random string", new List<int>());

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Call_TeacherRepo_Add_Method_Once()
        {
            var mockedUserRolesRepo = new Mock<IRepository<IdentityRole>>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new RegistrationService(
                mockedUserRolesRepo.Object,
                mockedSubjectManagementService.Object,
                mockedStudentRepo.Object,
                mockedTeacherRepo.Object,
                () => mockedUnitOfWork.Object);

            mockedTeacherRepo.Setup(x => x.Add(It.IsAny<Teacher>()));
            mockedSubjectManagementService.Setup(x => x.AddSubjectsToTeacher(It.IsAny<string>(), It.IsAny<IEnumerable<int>>()));
            mockedUnitOfWork.Setup(x => x.Commit());

            service.RegisterTeacher("random string", new List<int>());

            mockedTeacherRepo.Verify(x => x.Add(It.IsAny<Teacher>()), Times.Once);
        }

        [Test]
        public void Call_SubjectManagementService_AddSubjectsToTeacher_Method_Once()
        {
            var mockedUserRolesRepo = new Mock<IRepository<IdentityRole>>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new RegistrationService(
                mockedUserRolesRepo.Object,
                mockedSubjectManagementService.Object,
                mockedStudentRepo.Object,
                mockedTeacherRepo.Object,
                () => mockedUnitOfWork.Object);

            mockedTeacherRepo.Setup(x => x.Add(It.IsAny<Teacher>()));
            mockedSubjectManagementService.Setup(x => x.AddSubjectsToTeacher(It.IsAny<string>(), It.IsAny<IEnumerable<int>>()));
            mockedUnitOfWork.Setup(x => x.Commit()).Returns(true);

            service.RegisterTeacher("random string", new List<int>());

            mockedSubjectManagementService
                .Verify(x => x.AddSubjectsToTeacher(It.IsAny<string>(), It.IsAny<IEnumerable<int>>()),
                    Times.Once);
        }
    }
}
