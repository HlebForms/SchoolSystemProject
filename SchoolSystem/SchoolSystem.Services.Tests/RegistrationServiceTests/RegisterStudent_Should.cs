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
   public class RegisterStudent_Should
    {
        [Test]
        public void Throw_When_StudentId_IsEmpty()
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
                () => service.RegisterStudent(string.Empty, It.IsAny<int>()));

            Assert.That(ex.ParamName, Is.EqualTo("studentId"));
        }

        [Test]
        public void Throw_When_StudentId_IsNull()
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
                () => service.RegisterStudent(null, It.IsAny<int>()));

            Assert.That(ex.ParamName, Is.EqualTo("studentId"));
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

            mockedStudentRepo.Setup(x => x.Add(It.IsAny<Student>()));

            service.RegisterStudent("random string", 0);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Call_StudentRepo_Add_Method_Once()
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

            mockedStudentRepo.Setup(x => x.Add(It.IsAny<Student>()));

            service.RegisterStudent("random string", 0);

            mockedStudentRepo.Verify(x => x.Add(It.IsAny<Student>()), Times.Once);
        }
    }
}
