using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.AssignSubjectToTeacherPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowWhen_TeacherManagementService_IsNull()
        {
            var mockedView = new Mock<IAssignSubjectToTeacherView>();
            //var mockedTeacherManagementService = new Mock<ITeacherManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new AssignSubjectToTeacherPresenter(
                mockedView.Object,
                null,
                mockedSubjectManagementService.Object));

            Assert.That(ex.ParamName, Is.EqualTo("teacherManagementService"));
        }

        [Test]
        public void ThrowWhen_SubjectManagementService_IsNull()
        {
            var mockedView = new Mock<IAssignSubjectToTeacherView>();
            var mockedTeacherManagementService = new Mock<ITeacherManagementService>();
            //var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new AssignSubjectToTeacherPresenter(
                mockedView.Object,
                mockedTeacherManagementService.Object,
                null));

            Assert.That(ex.ParamName, Is.EqualTo("subjectManagementService"));
        }
    }
}
