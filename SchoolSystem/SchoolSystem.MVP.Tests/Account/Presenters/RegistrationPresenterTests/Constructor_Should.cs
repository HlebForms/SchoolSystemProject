using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Account.Presenters;
using SchoolSystem.MVP.Account.Views;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Account.Presenters.RegistrationPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void NotThrow_WhenAllArgumentsAreValid()
        {
            var mockedRegisterView = new Mock<IRegisterView>();
            var mockedRegistrationService = new Mock<IRegistrationService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedAccountManagementService = new Mock<IAccountManagementService>();
            var mockedEmailSenderService = new Mock<IEmailSenderService>();
            var mockedPasswordService = new Mock<IPasswordGeneratorService>();

            Assert.DoesNotThrow(
                () => new RegistrationPresenter(
                    mockedRegisterView.Object,
                    mockedRegistrationService.Object,
                    mockedSubjectManagementService.Object,
                    mockedClassOfStudentsManagementService.Object,
                    mockedAccountManagementService.Object,
                    mockedEmailSenderService.Object,
                    mockedPasswordService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContainsRegistrationService_WhenRegistrationServiceIsNull()
        {
            var mockedRegisterView = new Mock<IRegisterView>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedAccountManagementService = new Mock<IAccountManagementService>();
            var mockedEmailSenderService = new Mock<IEmailSenderService>();
            var mockedPasswordService = new Mock<IPasswordGeneratorService>();

            Assert.That(
                () => new RegistrationPresenter(
                    mockedRegisterView.Object,
                    null,
                    mockedSubjectManagementService.Object,
                    mockedClassOfStudentsManagementService.Object,
                    mockedAccountManagementService.Object,
                    mockedEmailSenderService.Object,
                    mockedPasswordService.Object),
                Throws.ArgumentNullException.With.Message.Contain("registrationService"));
        }

        [Test]
        public void ThrowArgumentNulLException_WithMessageContainsSubjectManagementService_WhenSubjectManagementServiceIsNull()
        {
            var mockedRegisterView = new Mock<IRegisterView>();
            var mockedRegistrationService = new Mock<IRegistrationService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedAccountManagementService = new Mock<IAccountManagementService>();
            var mockedEmailSenderService = new Mock<IEmailSenderService>();
            var mockedPasswordService = new Mock<IPasswordGeneratorService>();

            Assert.That(
                () => new RegistrationPresenter(
                    mockedRegisterView.Object,
                    mockedRegistrationService.Object,
                    null,
                    mockedClassOfStudentsManagementService.Object,
                    mockedAccountManagementService.Object,
                    mockedEmailSenderService.Object,
                    mockedPasswordService.Object),
                Throws.ArgumentNullException.With.Message.Contain("subjectManagementService"));
        }

        [Test]
        public void ThorwArgumentNullException_WithMessageContainsClassOfStudentManagementService_WhenClassOfStudentsManagementServiceIsNull()
        {
            var mockedRegisterView = new Mock<IRegisterView>();
            var mockedRegistrationService = new Mock<IRegistrationService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedAccountManagementService = new Mock<IAccountManagementService>();
            var mockedEmailSenderService = new Mock<IEmailSenderService>();
            var mockedPasswordService = new Mock<IPasswordGeneratorService>();

            Assert.That(
                () => new RegistrationPresenter(
                    mockedRegisterView.Object,
                    mockedRegistrationService.Object,
                    mockedSubjectManagementService.Object,
                    null,
                    mockedAccountManagementService.Object,
                    mockedEmailSenderService.Object,
                    mockedPasswordService.Object),
                Throws.ArgumentNullException.With.Message.Contain("classOfStudentsManagementService"));
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContainsAccountManagementService_WhenAccountManagementServiceIsNull()
        {
            var mockedRegisterView = new Mock<IRegisterView>();
            var mockedRegistrationService = new Mock<IRegistrationService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedEmailSenderService = new Mock<IEmailSenderService>();
            var mockedPasswordService = new Mock<IPasswordGeneratorService>();

            Assert.That(
                () => new RegistrationPresenter(
                    mockedRegisterView.Object,
                    mockedRegistrationService.Object,
                    mockedSubjectManagementService.Object,
                    mockedClassOfStudentsManagementService.Object,
                    null,
                    mockedEmailSenderService.Object,
                    mockedPasswordService.Object),
                Throws.ArgumentNullException.With.Message.Contain("accountManagementService"));
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContainsEmailSender_WhenEmailSenderIsNull()
        {
            var mockedRegisterView = new Mock<IRegisterView>();
            var mockedRegistrationService = new Mock<IRegistrationService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedAccountManagementService = new Mock<IAccountManagementService>();
            var mockedEmailSenderService = new Mock<IEmailSenderService>();
            var mockedPasswordService = new Mock<IPasswordGeneratorService>();

            Assert.That(
                () => new RegistrationPresenter(
                    mockedRegisterView.Object,
                    mockedRegistrationService.Object,
                    mockedSubjectManagementService.Object,
                    mockedClassOfStudentsManagementService.Object,
                    mockedAccountManagementService.Object,
                    null,
                    mockedPasswordService.Object),
                Throws.ArgumentNullException.With.Message.Contain("emailSender"));
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContaiinsPasswordService_WhenPassWordServiceIsNull()
        {
            var mockedRegisterView = new Mock<IRegisterView>();
            var mockedRegistrationService = new Mock<IRegistrationService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedAccountManagementService = new Mock<IAccountManagementService>();
            var mockedEmailSenderService = new Mock<IEmailSenderService>();

            Assert.That(
                () => new RegistrationPresenter(
                    mockedRegisterView.Object,
                    mockedRegistrationService.Object,
                    mockedSubjectManagementService.Object,
                    mockedClassOfStudentsManagementService.Object,
                    mockedAccountManagementService.Object,
                    mockedEmailSenderService.Object,
                    null),
                Throws.ArgumentNullException.With.Message.Contain("passwordService"));
        }
    }
}
