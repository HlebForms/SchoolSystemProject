using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Account.Models;
using SchoolSystem.MVP.Account.Presenters;
using SchoolSystem.MVP.Account.Views;
using SchoolSystem.MVP.Account.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Account.Presenters.RegistrationPresenterTests
{
    [TestFixture]
    public class RegisterUser_Should
    {
        [Test]
        public void SetResult_ToModel_WithCorrectMessage_WhenEmailOfTheUserIsNotUnique()
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

            var email = It.IsAny<string>();
            mockedAccountManagementService
                .Setup(x => x.IsEmailUnique(email))
                .Returns(false);

            var expectedResult = new IdentityResult("Има потребител с такъв имейл!");

            var registrationPresenter = new RegistrationPresenter(
                     mockedRegisterView.Object,
                     mockedRegistrationService.Object,
                     mockedSubjectManagementService.Object,
                     mockedClassOfStudentsManagementService.Object,
                     mockedAccountManagementService.Object,
                     mockedEmailSenderService.Object,
                     mockedPasswordService.Object);

            var args = new RegistrationPageEventArgs()
            {
                Email = email
            };

            mockedRegisterView.Raise(x => x.EventRegisterUser += null, args);

            CollectionAssert.AreEquivalent(expectedResult.Errors, mockedRegisterView.Object.Model.Result.Errors);
        }
    }
}
