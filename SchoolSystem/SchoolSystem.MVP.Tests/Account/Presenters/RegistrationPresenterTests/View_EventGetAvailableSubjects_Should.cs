using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.MVP.Account.Models;
using SchoolSystem.MVP.Account.Presenters;
using SchoolSystem.MVP.Account.Views;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Account.Presenters.RegistrationPresenterTests
{
    [TestFixture]
    public class View_EventGetAvailableSubjects_Should
    {
        [Test]
        public void BindAllSubjectsWithoutTeacher_ToModel_WhenArgumentsAreValid()
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

            var expectedSubjects = new List<SubjectBasicInfoModel>()
            {
                new SubjectBasicInfoModel(),
                new SubjectBasicInfoModel(),
                new SubjectBasicInfoModel()
            };

            mockedSubjectManagementService
                .Setup(x => x.GetAllSubjectsWithoutTeacher())
                .Returns(expectedSubjects);

            var registrationPresenter = new RegistrationPresenter(
                     mockedRegisterView.Object,
                     mockedRegistrationService.Object,
                     mockedSubjectManagementService.Object,
                     mockedClassOfStudentsManagementService.Object,
                     mockedAccountManagementService.Object,
                     mockedEmailSenderService.Object,
                     mockedPasswordService.Object);

            mockedRegisterView.Raise(x => x.EventGetAvailableSubjects += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(expectedSubjects, mockedRegisterView.Object.Model.Subjects);
        }
    }
}
