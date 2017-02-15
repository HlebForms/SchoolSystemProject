using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using SchoolSystem.Data.Models.Common;
using SchoolSystem.MVP.Home.Models;
using SchoolSystem.MVP.Home.Presenter;
using SchoolSystem.MVP.Home.Views.EventArguments;
using SchoolSystem.MVP.Home.Views;

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