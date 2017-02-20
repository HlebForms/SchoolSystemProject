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
    public class GetAllMarks_Should
    {
        [Test]
        public void Call_MarksRepo_GetAll_Method_Once()
        {
            var mockedSubjectStudentRepo = new Mock<IRepository<SubjectStudent>>();
            var mockedMarksRepo = new Mock<IRepository<Mark>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new MarksManagementService(
                          mockedSubjectStudentRepo.Object,
                          mockedMarksRepo.Object,
                          () => mockedUnitOfWork.Object);

            service.GetAllMarks();

            mockedMarksRepo.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
