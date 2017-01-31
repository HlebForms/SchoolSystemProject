using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.WebForms.CustomControls.Admin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;

namespace SchoolSystem.WebForms.CustomControls.Admin.Presenters
{
    public class CreatingSchedulePresenter : Presenter<ICreatingScheduleView>
    {
        private readonly IScheduleDataService scheduleService;
        private readonly IClassOfStudentsManagementService classOfStudentsManagementService;

        public CreatingSchedulePresenter(
            ICreatingScheduleView view,
            IScheduleDataService scheduleService,
            IClassOfStudentsManagementService classOfStudentsManagementService
            )
            : base(view)
        {
            if (scheduleService == null)
            {
                throw new ArgumentNullException("scheduleService");
            }

            if (classOfStudentsManagementService == null)
            {
                throw new ArgumentNullException("classOfStudentsManagementService");
            }

            this.scheduleService = scheduleService;
            this.classOfStudentsManagementService = classOfStudentsManagementService;
            this.View.EventBindScheduleData += this.BindScheduleData;
            this.View.EventBindAllClasses += this.GetAllClasses;
        }

        private void GetAllClasses(object sender, EventArgs e)
        {
            this.View.Model.AllClassOfStudents = this.classOfStudentsManagementService.GetAllClasses();
        }

        private void BindScheduleData(object sender, CreatingScheduleEventArgs e)
        {
        }
    }
}