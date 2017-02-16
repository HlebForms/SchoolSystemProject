using System;
using System.Linq;
using System.Web.UI.WebControls;

using WebFormsMvp;
using WebFormsMvp.Web;
using SchoolSystem.MVP.Student.Presenters;
using SchoolSystem.MVP.Student.Models;
using SchoolSystem.MVP.Student.Views.EventArguments;
using SchoolSystem.MVP.Student.Views;

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
            //SortDirection sortDir = this.ViewState["sortExpression"] == null ? e.SortDirection : this.ViewState["sortExpression"];

            //switch (e.SortExpression)
            //{
            //    case "ByName":

            //        if (sortDir == "Ascending")
            //        {
            //            this.BindGridView();
            //            this.ScoolReportCardGrid.DataSource = this.Model.StudentMarks.OrderBy(x => x.SubjectName);
            //            this.ScoolReportCardGrid.DataBind();

            //            this.ViewState["sortExpression"] = SortDirection.Descending;
            //        }
            //        else
            //        {
            //            this.BindGridView();
            //            this.ScoolReportCardGrid.DataSource = this.Model.StudentMarks.OrderByDescending(x => x.SubjectName); ;
            //            this.ScoolReportCardGrid.DataBind();
            //            this.ViewState["sortExpression"] = SortDirection.Ascending;
            //        }
            //        break;

            //    case "ByAverage":
            //        if (e.SortDirection == SortDirection.Ascending)
            //        {
            //            this.BindGridView();
            //            this.ScoolReportCardGrid.DataSource = this.Model.StudentMarks.OrderBy(x => x.Average);
            //            this.ScoolReportCardGrid.DataBind();
            //            this.ViewState["sortExpression"] = SortDirection.Descending;
            //        }
            //        else
            //        {
            //            this.BindGridView();
            //            this.ScoolReportCardGrid.DataSource = this.Model.StudentMarks.OrderByDescending(x => x.Average);
            //            this.ScoolReportCardGrid.DataBind();
            //            this.ViewState["sortExpression"] = e.SortExpression + " " + "ASC";
            //            this.ViewState["sortExpression"] = SortDirection.Ascending;
            //        }
            //        break;
            //    default:
            //        break;
            }
        }
    }
}