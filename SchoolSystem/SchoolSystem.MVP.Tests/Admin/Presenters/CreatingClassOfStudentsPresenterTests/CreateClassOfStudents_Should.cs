using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.CreatingClassOfStudentsPresenterTests
{
    [TestFixture]
    public class CreateClassOfStudents_Should
    {
        [Test]
        public void Set_Model_IsSuccesfull_Property_Correctly()
        {
            var mockedView = new Mock<ICreatingClassOfStudentsView>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var model = new CreatingClassOfStudentsModel();
            var args = new CreatingClassOfStudentsEventArgs();

            var expected = true;

            mockedView.SetupGet(x => x.Model).Returns(model);
            mockedClassOfStudentsManagementService
                .Setup(x => x.AddClass(It.IsAny<string>(), It.IsAny<List<string>>()))
                .Returns(expected);

            var presenter = new CreatingClassOfStudentsPresenter(
                mockedView.Object,
                mockedClassOfStudentsManagementService.Object,
                mockedSubjectManagementService.Object);

            mockedView.Raise(x => x.EventCreateClassOfStudents += null, args);

            Assert.AreEqual(expected, mockedView.Object.Model.IsSuccesfull);
        }
    }
}
