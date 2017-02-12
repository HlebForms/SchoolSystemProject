using System;

using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.WebForms.CustomControls.Student.Views;
using SchoolSystem.WebForms.CustomControls.Student.Views.EventArguments;

using Bytes2you.Validation;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Student.Presenters
{
    public class SchoolReportCardPreseneter : Presenter<ISchoolReporCardView>
    {
        private readonly IMarksManagementService marksManagementService;

        public SchoolReportCardPreseneter(
            ISchoolReporCardView view,
            IMarksManagementService marksManagementService
            ) : base(view)
        {
            Guard.WhenArgument(marksManagementService, "marksManagementService").IsNotNull().Throw();

            this.View.EvenGetStudentMarks += View_EvenGetStudentMarks;

            this.marksManagementService = marksManagementService;
        }

        private void View_EvenGetStudentMarks(object sender, GetStudentMarksEventArgs e)
        {
            this.View.Model.StudentMarks = this.marksManagementService.GetMarksForStudent(e.StudentName);
        }
    }
}