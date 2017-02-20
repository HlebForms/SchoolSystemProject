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
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_userRolesRepo_IsNull()
        {
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
                        new RegistrationService(
                            null,
                            mockedSubjectManagementService.Object,
                            mockedStudentRepo.Object,
                            mockedTeacherRepo.Object,
                            mockedUnitOfWork.Object));

            Assert.That(ex.ParamName, Is.EqualTo("userRolesRepo"));
        }

        [Test]
        public void Throw_When_subjectManagementService_IsNull()
        {
            var mockedUserRolesRepo = new Mock<IRepository<IdentityRole>>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
                        new RegistrationService(
                            mockedUserRolesRepo.Object,
                            null,
                            mockedStudentRepo.Object,
                            mockedTeacherRepo.Object,
                            mockedUnitOfWork.Object));

            Assert.That(ex.ParamName, Is.EqualTo("subjectManagementService"));
        }

        [Test]
        public void Throw_When_studentRepo_IsNull()
        {
            var mockedUserRolesRepo = new Mock<IRepository<IdentityRole>>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
                        new RegistrationService(
                            mockedUserRolesRepo.Object,
                            mockedSubjectManagementService.Object,
                            null,
                            mockedTeacherRepo.Object,
                            mockedUnitOfWork.Object));

            Assert.That(ex.ParamName, Is.EqualTo("studentRepo"));
        }

        [Test]
        public void Throw_When_teacherRepo_IsNull()
        {
            var mockedUserRolesRepo = new Mock<IRepository<IdentityRole>>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
                        new RegistrationService(
                            mockedUserRolesRepo.Object,
                            mockedSubjectManagementService.Object,
                            mockedStudentRepo.Object,
                            null,
                            mockedUnitOfWork.Object));

            Assert.That(ex.ParamName, Is.EqualTo("teacherRepo"));
        }

        [Test]
        public void Throw_When_unitOfWork_IsNull()
        {
            var mockedUserRolesRepo = new Mock<IRepository<IdentityRole>>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
                        new RegistrationService(
                            mockedUserRolesRepo.Object,
                            mockedSubjectManagementService.Object,
                            mockedStudentRepo.Object,
                            mockedTeacherRepo.Object,
                            null));

            Assert.That(ex.ParamName, Is.EqualTo("unitOfWork"));
        }
    }
}
