using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Account.Models;
using SchoolSystem.MVP.Account.Presenters;
using SchoolSystem.MVP.Account.Views;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Account.Presenters.RegistrationPresenterTests
{
    [TestFixture]
    public class View_EventGetUserRoles_Should
    {
        [Test]
        public void BindUserRoles_ToModel_WhenArumentsAreValid()
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

            var expectedRoles = new List<IdentityRole>()
            {
                new IdentityRole(),
                new IdentityRole(),
                new IdentityRole()
            };

            mockedRegistrationService
                .Setup(x => x.GetAllUserRoles())
                .Returns(expectedRoles);

            var registrationPresenter = new RegistrationPresenter(
                     mockedRegisterView.Object,
                     mockedRegistrationService.Object,
                     mockedSubjectManagementService.Object,
                     mockedClassOfStudentsManagementService.Object,
                     mockedAccountManagementService.Object,
                     mockedEmailSenderService.Object,
                     mockedPasswordService.Object);

            mockedRegisterView.Raise(x => x.EventGetUserRoles += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(expectedRoles, mockedRegisterView.Object.Model.UserRoles);
        }
    }
}
