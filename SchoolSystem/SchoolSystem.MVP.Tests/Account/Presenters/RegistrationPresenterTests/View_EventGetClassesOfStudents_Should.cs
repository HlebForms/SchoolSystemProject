using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Models;
using SchoolSystem.MVP.Account.Models;
using SchoolSystem.MVP.Account.Presenters;
using SchoolSystem.MVP.Account.Views;
using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.MVP.Tests.Account.Presenters.RegistrationPresenterTests
{
    [TestFixture]
    public class View_EventGetClassesOfStudents_Should
    {
        [Test]
        public void BindClassOfStudents_ToModel_WhenArgumentsAreValid()
        {
            var mockedRegisterView = new Mock<IRegisterView>();
            var mockedRegistrationService = new Mock<IRegistrationService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedAccountManagementService = new Mock<IAccountManagementService>();
            var mockedEmailSenderService = new Mock<IEmailSenderService>();
            var mockedPasswordService = new Mock<IPasswordGeneratorService>();

            mockedRegisterView
                .SetupGet(x => x.Model)
                .Returns(new RegistrationModel());

            var expectedClassOfStudents = new List<ClassOfStudents>()
            {
                new ClassOfStudents(),
                new ClassOfStudents(),
                new ClassOfStudents()
            };

            mockedClassOfStudentsManagementService
                .Setup(x => x.GetAllClasses())
                .Returns(expectedClassOfStudents);

            var registrationPresenter = new RegistrationPresenter(
                     mockedRegisterView.Object,
                     mockedRegistrationService.Object,
                     mockedSubjectManagementService.Object,
                     mockedClassOfStudentsManagementService.Object,
                     mockedAccountManagementService.Object,
                     mockedEmailSenderService.Object,
                     mockedPasswordService.Object);

            mockedRegisterView.Raise(x => x.EventGetClassesOfStudents += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(expectedClassOfStudents, mockedRegisterView.Object.Model.ClassOfStudents);
        }
    }
}
