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
            string sortDir = 
                this.ViewState["sortDirection"] == null ?
                e.SortDirection.ToString() 
                : this.ViewState["sortDirection"].ToString();

            this.BindGridView();

            switch (e.SortExpression)
            {
                case "ByName":

                    if (sortDir == "Ascending")
                    {
                        this.ScoolReportCardGrid.DataSource = this.Model.StudentMarks.OrderBy(x => x.SubjectName);
                        this.ScoolReportCardGrid.DataBind();
                        this.ViewState["sortDirection"] = SortDirection.Descending;
                    }
                    else
                    {
                        this.ScoolReportCardGrid.DataSource = this.Model.StudentMarks.OrderByDescending(x => x.SubjectName); ;
                        this.ScoolReportCardGrid.DataBind();
                        this.ViewState["sortDirection"] = SortDirection.Ascending;
                    }
                    break;

                case "ByAverage":

                    if (sortDir == "Ascending")
                    {
                        this.ScoolReportCardGrid.DataSource = this.Model.StudentMarks.OrderBy(x => x.Average);
                        this.ScoolReportCardGrid.DataBind();
                        this.ViewState["sortDirection"] = SortDirection.Descending;
                    }
                    else
                    {
                        this.ScoolReportCardGrid.DataSource = this.Model.StudentMarks.OrderByDescending(x => x.Average);
                        this.ScoolReportCardGrid.DataBind();
                        this.ViewState["sortDirection"] = SortDirection.Ascending;
                    }
                    break;
                default:
                    break;
            }

        }
    }
}