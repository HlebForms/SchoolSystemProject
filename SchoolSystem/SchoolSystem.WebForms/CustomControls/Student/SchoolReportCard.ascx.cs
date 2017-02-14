using System;
using System.Linq;
using System.Web.UI.WebControls;
using SchoolSystem.WebForms.CustomControls.Student.Models;

using SchoolSystem.WebForms.CustomControls.Student.Presenters;
using SchoolSystem.WebForms.CustomControls.Student.Views;
using SchoolSystem.WebForms.CustomControls.Student.Views.EventArguments;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace SchoolSystem.WebForms.CustomControls.Student
{
    [PresenterBinding(typeof(SchoolReportCardPreseneter))]
    public partial class SchoolReportCard : MvpUserControl<SchoolReportCardModel>, ISchoolReporCardView
    {
        public event EventHandler<GetStudentMarksEventArgs> EvenGetStudentMarks;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.BindGridView();
            }
        }

        private void BindGridView()
        {
            this.EvenGetStudentMarks(this, new GetStudentMarksEventArgs()
            {
                StudentName = this.Page.User.Identity.Name
            });

            this.ScoolReportCardGrid.DataSource = this.Model.StudentMarks;
            this.ScoolReportCardGrid.DataBind();
        }

        protected void ScoolReportCardGrid_Sorting(object sender, GridViewSortEventArgs e)
        {

            switch (e.SortExpression)
            {
                case "ByName":

                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        this.ScoolReportCardGrid.DataSource = this.Model.StudentMarks.OrderBy(x => x.SubjectName);
                        this.ScoolReportCardGrid.DataBind();
                    }
                    else
                    {
                        this.ScoolReportCardGrid.DataSource = this.Model.StudentMarks.OrderByDescending(x => x.SubjectName); ;
                        this.ScoolReportCardGrid.DataBind();
                    }
                    break;

                case "ByAverage":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        this.ScoolReportCardGrid.DataSource = this.Model.StudentMarks.OrderBy(x => x.Average);
                        this.ScoolReportCardGrid.DataBind();
                    }
                    else
                    {
                        this.ScoolReportCardGrid.DataSource = this.Model.StudentMarks.OrderBy(x => x.Average);
                        this.ScoolReportCardGrid.DataBind();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}