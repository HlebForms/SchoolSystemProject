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
    public class GetAllSubjects_Should
    {
        [Test]
        public void CallGetAllMethodOfSubjectsRepo()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            mockedSubjectsRepo.Setup(x => x.GetAll());
            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, mockedUnitOfWork.Object);

            var result = service.GetAllSubjects();

            mockedSubjectsRepo.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void ReturnTheAppropriateColection()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            IEnumerable<Subject> subjects = new List<Subject>();

            mockedSubjectsRepo.Setup(x => x.GetAll()).Returns(subjects);
            var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, mockedUnitOfWork.Object);
            var result = service.GetAllSubjects();

            Assert.AreSame(subjects, result);
        }
    }
}
