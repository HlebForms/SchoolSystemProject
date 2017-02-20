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

namespace SchoolSystem.Services.Tests.MarksManagementServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_SubjectStudentRepo_IsNull()
        {
            //var mockedSubjectStudentRepo = new Mock<IRepository<SubjectStudent>>();
            var mockedMarksRepo = new Mock<IRepository<Mark>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
                    new MarksManagementService(null, mockedMarksRepo.Object, mockedUnitOfWork.Object));

            Assert.That(ex.ParamName, Is.EqualTo("subjectStudenRepo"));
        }

        [Test]
        public void Throw_When_MarksRepo_IsNull()
        {
            var mockedSubjectStudentRepo = new Mock<IRepository<SubjectStudent>>();
            //var mockedMarksRepo = new Mock<IRepository<Mark>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
                    new MarksManagementService(mockedSubjectStudentRepo.Object, null, mockedUnitOfWork.Object));

            Assert.That(ex.ParamName, Is.EqualTo("marksRepo"));
        }

        [Test]
        public void Throw_When_UnitOfWork_IsNull()
        {
            var mockedSubjectStudentRepo = new Mock<IRepository<SubjectStudent>>();
            var mockedMarksRepo = new Mock<IRepository<Mark>>();
            // mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var ex = Assert.Throws<ArgumentNullException>(() =>
                    new MarksManagementService(mockedSubjectStudentRepo.Object, mockedMarksRepo.Object, null));

            Assert.That(ex.ParamName, Is.EqualTo("unitOfWork"));
        }
    }
}
