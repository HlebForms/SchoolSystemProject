using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;

namespace SchoolSystem.Services.Tests.ClassOfStudentsManagemtServiceTests
{
    [TestFixture]
    public class GetAllClasses_Should
    {
        [Test]
        public void CallGetAllMethodFromClassesrepoOnce()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            var service = new ClassOfStudentsManagementService(mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, mockedUnitOfWork.Object);

            service.GetAllClasses();

            mockedClassOfStudentsRepo.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void GetExpectedCollection_FromTheRepo()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            IEnumerable<ClassOfStudents> expected = new List<ClassOfStudents>();
            mockedClassOfStudentsRepo.Setup(x => x.GetAll()).Returns(expected);
            var service = new ClassOfStudentsManagementService(mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, mockedUnitOfWork.Object);

            var result = service.GetAllClasses();

            Assert.AreSame(expected, result);
        }
    }
}
