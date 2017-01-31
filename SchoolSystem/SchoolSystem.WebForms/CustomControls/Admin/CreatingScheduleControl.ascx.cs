using SchoolSystem.WebForms.CustomControls.Admin.Models;
using SchoolSystem.WebForms.CustomControls.Admin.Presenters;
using SchoolSystem.WebForms.CustomControls.Admin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;

namespace SchoolSystem.WebForms.CustomControls.Admin
{
    [PresenterBinding(typeof(CreatingSchedulePresenter))]
    public partial class CreateScheduleControl : MvpUserControl<CreatingScheduleModel>, ICreatingScheduleView
    {
        public event EventHandler<EventArgs> EventBindAllClasses;
        public event EventHandler<CreatingScheduleEventArgs> EventBindScheduleData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.EventBindAllClasses(this, e);
                this.ClassOfStudentsDropDown.DataSource = this.Model.AllClassOfStudents;
                this.ClassOfStudentsDropDown.DataBind();
             
                this.GridView1.DataSource = this.Model.CurrentSchedule.Where(x => x.DayOfWeek == this.DaysOfWeekDropDown.SelectedValue);

                this.GridView1.DataBind();
            }
        }

        public void DaysOfWeekDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            this.GridView1.DataSource = this.Model.CurrentSchedule.Where(x => x.DayOfWeek == this.DaysOfWeekDropDown.SelectedValue);
            this.GridView1.DataBind();
        }
    }
}
