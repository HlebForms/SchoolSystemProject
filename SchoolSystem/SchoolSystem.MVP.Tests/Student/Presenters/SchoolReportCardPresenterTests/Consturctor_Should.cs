using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Student.Presenters;
using SchoolSystem.MVP.Student.Views;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Student.Presenters.SchoolReportCardPresenterTests
{
    [TestFixture]
    public class Consturctor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithMessageContainsMarksManagementService_WhenMarksManagementServiceIsNull()
        {
            var mockedSchoolReportCardView = new Mock<ISchoolReporCardView>();

            Assert.That(() => new SchoolReportCardPreseneter(mockedSchoolReportCardView.Object, null),
                Throws.ArgumentNullException.With.Message.Contain("marksManagementService"));
        }

        [Test]
        public void NotThrow_WhenAllArgumentsAreValid()
        {
            var mockedSchoolReportCardView = new Mock<ISchoolReporCardView>();
            var mockedMarksManagemetService = new Mock<IMarksManagementService>();

            Assert.DoesNotThrow(() => new SchoolReportCardPreseneter(mockedSchoolReportCardView.Object, mockedMarksManagemetService.Object));
        }
    }
}
