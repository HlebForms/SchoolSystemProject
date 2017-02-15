using SchoolSystem.Data.Models;
using SchoolSystem.WebForms.CustomControls.Home.Models;
using SchoolSystem.WebForms.CustomControls.Home.Presenter;
using SchoolSystem.WebForms.CustomControls.Home.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using SchoolSystem.WebForms.CustomControls.Home.Views.EventArguments;
using SchoolSystem.Data.Models.Common;

namespace SchoolSystem.WebForms.CustomControls.Home
{
    [PresenterBinding(typeof(SchedulePresenter))]
    public partial class ScheduleControl : MvpUserControl<ScheduleControlModel>, IScheduleView
    {
        public event EventHandler<ScheduleEventargs> EventBindStudentScheduleData;
        public event EventHandler<ScheduleEventargs> EventBindTeacherScheduleData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var loggedUserName = this.Context.User.Identity.Name;

                var args = new ScheduleEventargs()
                {
                    Username = loggedUserName
                };

                if (this.Context.User.IsInRole(UserType.Student))
                {
                    this.EventBindStudentScheduleData(this, args);

                    this.Schedule.DataSource = this.Model.StudentSchedule;
                    this.Schedule.DataBind();
                }

                if (this.Context.User.IsInRole(UserType.Teacher))
                {
                    this.EventBindTeacherScheduleData(this, args);

                    this.Schedule.DataSource = this.Model.TeacherSchedule;
                    this.Schedule.DataBind();
                }
            }
        }
    }
}