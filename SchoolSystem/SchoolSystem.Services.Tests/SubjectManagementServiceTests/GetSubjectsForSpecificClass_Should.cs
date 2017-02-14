using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Services.Tests.SubjectManagementServiceTests
{
    [TestFixture]
    public class GetSubjectsForSpecificClass_Should
    {
        [Test]
        public void CallGetAllWithIdOfTheClass_Once()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;

            IEnumerable<Subject> allSubjects = new List<Subject>();

            mockedSubjClassRepo.Setup(x =>
            x.GetAll(It.IsAny<Expression<Func<SubjectClassOfStudents, bool>>>(), It.IsAny<Expression<Func<SubjectClassOfStudents, Subject>>>()))
            .Returns(allSubjects);

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow);

            subjectsManagementService
                .GetAllSubjectsAlreadyAssignedToTheClass(It.IsAny<int>());

            mockedSubjClassRepo.Verify(
                x => x.GetAll(
                It.IsAny<Expression<Func<SubjectClassOfStudents, bool>>>(),
                It.IsAny<Expression<Func<SubjectClassOfStudents, Subject>>>(),
                It.IsAny<Expression<Func<SubjectClassOfStudents, object>>>()),
                Times.Once);
        }
    }
}
