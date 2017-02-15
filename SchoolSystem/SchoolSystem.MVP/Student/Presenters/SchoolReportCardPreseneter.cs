
using SchoolSystem.Web.Services.Contracts;

using Bytes2you.Validation;
using WebFormsMvp;
using SchoolSystem.MVP.Student.Views;
using SchoolSystem.MVP.Student.Views.EventArguments;

namespace SchoolSystem.MVP.Student.Presenters
{
    public class SchoolReportCardPreseneter : Presenter<ISchoolReporCardView>
    {
        private readonly IMarksManagementService marksManagementService;

        public SchoolReportCardPreseneter(
            ISchoolReporCardView view,
            IMarksManagementService marksManagementService
            ) : base(view)
        {
            Guard.WhenArgument(marksManagementService, "marksManagementService").IsNull().Throw();

            this.View.EvenGetStudentMarks += View_EvenGetStudentMarks;

            this.marksManagementService = marksManagementService;
        }

        private void View_EvenGetStudentMarks(object sender, GetStudentMarksEventArgs e)
        {
            this.View.Model.StudentMarks = this.marksManagementService.GetMarksForStudent(e.StudentName);
        }
    }
}