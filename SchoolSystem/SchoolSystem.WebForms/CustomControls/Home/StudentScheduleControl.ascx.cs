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
    [PresenterBinding(typeof(StudentSchedulePresenter))]
    public partial class StudentScheduleControl : MvpUserControl<StudentScheduleModel>, IStudentScheduleView
    {
        public event EventHandler<StudentScheduleEventargs> EventBindScheduleData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var loggedUserName = this.Context.User.Identity.Name;

                var args = new StudentScheduleEventargs()
                {
                    Username = loggedUserName
                };

                if (this.Context.User.IsInRole(UserType.Student))
                {
                    this.EventBindScheduleData(this, args);

                    this.schedule.DataSource = this.Model.StudentSchedule;
                    this.schedule.DataBind();
                }
            }
        }
    }
}