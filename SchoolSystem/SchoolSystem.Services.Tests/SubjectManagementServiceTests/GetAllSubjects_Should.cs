using System.Collections.Generic;

using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;
using Moq;

using NUnit.Framework;

namespace SchoolSystem.Services.Tests.SubjectManagementServiceTests
{
    [TestFixture]
    public class GetAllSubjects_Should
    {
        [Test]
        public void CallGettAllMethodFromSubjectRepo_Once()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;
            IEnumerable<Subject> allSubjects = new List<Subject>();
            mockedSubjectRepo.Setup(x => x.GetAll()).Returns(allSubjects);

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow);

            var result = subjectsManagementService.GetAllSubjects();

            mockedSubjectRepo.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void GetExpectedCollection_FromTheRepo()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;
            IEnumerable<Subject> allSubjects = new List<Subject>();
            mockedSubjectRepo.Setup(x => x.GetAll()).Returns(allSubjects);

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow);

            var result = subjectsManagementService.GetAllSubjects();

            Assert.AreSame(allSubjects, result);
        }
    }
}
