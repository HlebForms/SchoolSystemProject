using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.CreatingClassOfStudentsPresenterTests
{
    [TestFixture]
    public class GetAllSubjects_Should
    {
        [Test]
        public void Set_Model_Subjects_Property_Correctly()
        {
            var mockedView = new Mock<ICreatingClassOfStudentsView>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var model = new CreatingClassOfStudentsModel();

            var expected = new List<SubjectBasicInfoModel>();

            mockedView.SetupGet(x => x.Model).Returns(model);
            mockedSubjectManagementService
                .Setup(x => x.GetAllSubjectsWithTeacher())
                .Returns(expected);

            var presenter = new CreatingClassOfStudentsPresenter(
                mockedView.Object,
                mockedClassOfStudentsManagementService.Object,
                mockedSubjectManagementService.Object
                );

            mockedView.Raise(x => x.EventGetAllSubjects += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(expected, mockedView.Object.Model.Subjects);
        }
    }
}
