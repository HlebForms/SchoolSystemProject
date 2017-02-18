using System;
using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.CreatingSubjectPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_SubjectManagementService_IsNull()
        {
            var mockedView = new Mock<ICreatingSubjectView>();

            var ex = Assert.Throws<ArgumentNullException>(
                () => new CreatingSubjectPresenter(
                mockedView.Object,
                null));

            Assert.That(ex.ParamName, Is.EqualTo("subjectManagementService"));
        }
    }
}
