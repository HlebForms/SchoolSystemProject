using SchoolSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolSystem.WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var program1 = new SubjectClassOfStudentsDaysOfWeek()
            {
                ClassOfStudentsId = 1,
                DaysOfWeekId = 1,
                SubjectId = 1,
                StartHour = DateTime.Now,
                EndHour = DateTime.Now.AddHours(1)
            };
            var program2 = new SubjectClassOfStudentsDaysOfWeek()
            {
                ClassOfStudentsId = 2,
                DaysOfWeekId = 2,
                SubjectId = 2,
                StartHour = DateTime.Now.AddHours(1),
                EndHour = DateTime.Now.AddHours(2)
            };
            var program3 = new SubjectClassOfStudentsDaysOfWeek()
            {
                ClassOfStudentsId = 3,
                DaysOfWeekId = 3,
                SubjectId = 3,
                StartHour = DateTime.Now.AddHours(2),
                EndHour = DateTime.Now.AddHours(3)
            };


            var todayProgram = new HashSet<SubjectClassOfStudentsDaysOfWeek>() {
               program1,
               program2,
               program3
            };
            
            this.schedule.DataSource = todayProgram;
            this.schedule.DataBind();
        }
    }
}