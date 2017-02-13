using System;
using System.Collections.Generic;

using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;

using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

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
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, mockedUnitOfWork.Object);
            IEnumerable<string> subjectIds = new List<string>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                service.AddClass(null, subjectIds);
            });
        }

        [Test]
        public void ThrowArgumentException_WhenNameParamIsNuull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, mockedUnitOfWork.Object);

            IEnumerable<string> subjectIds = new List<string>();

            Assert.Throws<ArgumentException>(() =>
            {
                service.AddClass(string.Empty, subjectIds);
            });
        }

        [Test]
        public void ThrowArgumentException_WithMessageContatining_Name_WhenNameParamIsNuull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, mockedUnitOfWork.Object);
            IEnumerable<string> subjectIds = new List<string>();

            Assert.That(() =>
            {
                service.AddClass(string.Empty, subjectIds);
            }, Throws.ArgumentException.With.Message.Contain("name"));
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContatining_Name_WhenNameParamIsNuull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, mockedUnitOfWork.Object);
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

            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, mockedUnitOfWork.Object);

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
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, mockedUnitOfWork.Object);

            Assert.That(() =>
            {
                service.AddClass(NotNullString, null);
            }, Throws.ArgumentNullException.With.Message.Contain("subjecIds"));
        }

        [Test]
        public void Call_GetAllMethodFromClassOfStudentsRepo_Once()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            mockedUnitOfWork.Setup(x => x.Commit());
            mockedClassOfStudentsRepo.Setup(x => x.GetAll(null, y => y.Name)).Returns(new List<string>());

            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, () => mockedUnitOfWork.Object);

            service.AddClass(NotNullString, new List<string>());

            mockedClassOfStudentsRepo.Verify(x => x.GetAll(null, y => y.Name), Times.Once);
        }

        [Test]
        public void Return_False_WhenThereIsClassOfStudentsWithTheSameName()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            mockedUnitOfWork.Setup(x => x.Commit());

            string className = NotNullString;
            IEnumerable<string> classNames = new List<string>() { className };

            mockedClassOfStudentsRepo.Setup(x => x.GetAll(null, y => y.Name)).Returns(classNames);
            mockedSubjectsRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Subject, bool>>>())).Returns(new Subject());

            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, () => mockedUnitOfWork.Object);
            var nonEmptyList = new List<string>() { "2" };

            var result = service.AddClass(NotNullString, nonEmptyList);

            Assert.False(result);
        }

        [Test]
        public void Call_AddMethod_Once_FromClassOfStudentsRepoOnce()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            mockedUnitOfWork.Setup(x => x.Commit());

            IEnumerable<string> classNames = new List<string>() { };

            mockedClassOfStudentsRepo.Setup(x => x.GetAll(null, y => y.Name)).Returns(classNames);
            mockedClassOfStudentsRepo.Setup(x => x.Add(It.IsAny<ClassOfStudents>()));
            mockedSubjectsRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Subject, bool>>>())).Returns(new Subject());
            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, () => mockedUnitOfWork.Object);
            var nonEmptyList = new List<string>() { "2" };

            service.AddClass(NotNullString, nonEmptyList);

            mockedClassOfStudentsRepo.Verify(x => x.Add(It.IsAny<ClassOfStudents>()), Times.Once);
        }

        [Test]
        public void Call_CommitMethod_Once()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            mockedUnitOfWork.Setup(x => x.Commit());

            IEnumerable<string> classNames = new List<string>() { };

            mockedClassOfStudentsRepo.Setup(x => x.GetAll(null, y => y.Name)).Returns(classNames);
            mockedClassOfStudentsRepo.Setup(x => x.Add(It.IsAny<ClassOfStudents>()));
            mockedSubjectsRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Subject, bool>>>())).Returns(new Subject());
            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, () => mockedUnitOfWork.Object);
            var nonEmptyList = new List<string>() { "2" };

            service.AddClass(NotNullString, nonEmptyList);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Return_True_WhenThereIsClassOfStudentsWithTheSameName()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            mockedUnitOfWork.Setup(x => x.Commit()).Returns(true);

            IEnumerable<string> classNames = new List<string>();

            mockedClassOfStudentsRepo.Setup(x => x.GetAll(null, y => y.Name)).Returns(classNames);

            mockedSubjectsRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Subject, bool>>>())).Returns(new Subject());

            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, () => mockedUnitOfWork.Object);
            var nonEmptyList = new List<string>() { "2" };

            var result = service.AddClass(NotNullString, nonEmptyList);

            Assert.True(result);
        }
    }
}
