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

namespace SchoolSystem.MVP.Tests.Admin.Presenters.AssignSubjectsToClassOfStudentsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {

        [Test]
        public void ThrowWhen_classOfStudentManagementService_IsNull()
        {
            var mockedView = new Mock<IAssignSubjectsToClassOfStudentsView>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

          var ex = Assert.Throws<ArgumentNullException>(()=> new AssignSubjectsToClassOfStudentsPresenter(
                mockedView.Object,
                null,
                mockedSubjectManagementService.Object
                ));

            Assert.That(ex.ParamName, Is.EqualTo("classOfStudentManagementService"));
        }

        [Test]
        public void ThrowWhen_mockedSubjectManagementService_IsNull()
        {
            var mockedView = new Mock<IAssignSubjectsToClassOfStudentsView>();
            var mockedClassOfStudentManagementService = new Mock<IClassOfStudentsManagementService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new AssignSubjectsToClassOfStudentsPresenter(
                  mockedView.Object,
                  mockedClassOfStudentManagementService.Object,
                  null
                  ));

            Assert.That(ex.ParamName, Is.EqualTo("subjectManagementService"));
        }
    }
}
