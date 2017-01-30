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

                this.EventBindScheduleData(this, args);

                this.schedule.DataSource = this.Model.StudentSchedule;
                this.schedule.DataBind();
            }

            //var program1 = new SubjectClassOfStudentsDaysOfWeek()
            //{
            //    ClassOfStudentsId = 1,
            //    DaysOfWeekId = 1,
            //    SubjectId = 1,
            //    StartHour = DateTime.Now,
            //    EndHour = DateTime.Now.AddHours(1)
            //};
            //var program2 = new SubjectClassOfStudentsDaysOfWeek()
            //{
            //    ClassOfStudentsId = 2,
            //    DaysOfWeekId = 2,
            //    SubjectId = 2,
            //    StartHour = DateTime.Now.AddHours(1),
            //    EndHour = DateTime.Now.AddHours(2)
            //};
            //var program3 = new SubjectClassOfStudentsDaysOfWeek()
            //{
            //    ClassOfStudentsId = 3,
            //    DaysOfWeekId = 3,
            //    SubjectId = 3,
            //    StartHour = DateTime.Now.AddHours(2),
            //    EndHour = DateTime.Now.AddHours(3)
            //};


            //var todayProgram = new HashSet<SubjectClassOfStudentsDaysOfWeek>() {
            //   program1,
            //   program2,
            //   program3
            //};

            //this.schedule.DataSource = todayProgram;
            //this.schedule.DataBind();
        }
    }
}