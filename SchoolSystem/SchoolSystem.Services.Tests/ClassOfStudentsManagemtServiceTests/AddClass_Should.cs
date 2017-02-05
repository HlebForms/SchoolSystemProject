using System;
using System.Collections.Generic;

using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;

using Moq;
using NUnit.Framework;

namespace SchoolSystem.Services.Tests.ClassOfStudentsManagemtServiceTests
{
    [TestFixture]
    public class AddClass_Should
    {
        private const string NotNullString = "notNull";

        [Test]
        public void ThrowArgumentNullException_WhenNameParamIsNuull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedUnitOfWork.Object);
            IEnumerable<string> subjectIds = new List<string>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                service.AddClass(null, subjectIds);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContatining_Name_WhenNameParamIsNuull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedUnitOfWork.Object);
            IEnumerable<string> subjectIds = new List<string>();

            Assert.That(() =>
            {
                service.AddClass(null, subjectIds);
            }, Throws.ArgumentNullException.With.Message.Contain("name"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenSubjectIdsParamIsNuull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedUnitOfWork.Object);

            Assert.Throws<ArgumentNullException>(() =>
            {
                service.AddClass(NotNullString, null);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContaining_Subjects_WhenSubjectIdsParamIsNuull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedUnitOfWork.Object);

            Assert.That(() =>
            {
                service.AddClass(NotNullString, null);
            }, Throws.ArgumentNullException.With.Message.Contain("subjects"));
        }
    }
}
