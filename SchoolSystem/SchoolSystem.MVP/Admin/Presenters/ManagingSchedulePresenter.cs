using SchoolSystem.Web.Services.Contracts;
using System;
using WebFormsMvp;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.MVP.Admin.Views;

namespace SchoolSystem.MVP.Admin.Presenters
{
    public class ManagingSchedulePresenter : Presenter<IManagingScheduleView>
    {
        private readonly IScheduleDataService scheduleService;
        private readonly IClassOfStudentsManagementService classOfStudentsManagementService;
        private readonly ISubjectManagementService subjectManagementService;

        public ManagingSchedulePresenter(
            IManagingScheduleView view,
            IScheduleDataService scheduleService,
            IClassOfStudentsManagementService classOfStudentsManagementService,
            ISubjectManagementService subjectManagementService
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

            if (subjectManagementService == null)
            {
                throw new ArgumentNullException("subjectManagementService");
            }

            this.scheduleService = scheduleService;
            this.classOfStudentsManagementService = classOfStudentsManagementService;
            this.subjectManagementService = subjectManagementService;

            this.View.EventBindScheduleData += this.BindScheduleData;
            this.View.EventBindAllClasses += this.GetAllClasses;
            this.View.EventBindDaysOfWeek += this.BindDaysOfWeek;
            this.View.EventBitSubjectForCurrentClass += this.BindSubjectsForSpecificClass;
            this.View.EventAddSubjectToSchedule += this.AddSubjectToSchedule;
            this.View.EventRemoveSubjectFromSchedule += this.RemoveSubjectFromSchedule;
        }

        private void RemoveSubjectFromSchedule(object sender, RemovingSubjectFromScheduleEventArgs e)
        {
            this.scheduleService.RemoveSubjectFromSchedule(e.ClassId, e.DaysOfWeekId, e.SubjectId);
        }

        private void AddSubjectToSchedule(object sender, AddingSubjectToScheduleEventArgs e)
        {
            this.View.Model.IsInsertingSuccessFull = this.scheduleService.AddSubjectToSchedule(e.ClassId, e.SubjectId, e.DaysOfWeekId, e.StartHour, e.EndHour);
        }

        private void BindSubjectsForSpecificClass(object sender, BindSubjectsForClassEventArgs e)
        {
            this.View.Model.SubjectForCurrentClass = this.subjectManagementService.GetAllSubjectsAlreadyAssignedToTheClass(e.ClassId);
        }

        private void BindDaysOfWeek(object sender, EventArgs e)
        {
            this.View.Model.DaysOfWeek = this.scheduleService.GetAllDaysOfWeek();
        }

        private void GetAllClasses(object sender, EventArgs e)
        {
            this.View.Model.AllClassOfStudents = this.classOfStudentsManagementService.GetAllClasses();
        }

        private void BindScheduleData(object sender, ManagingScheduleEventArgs e)
        {
            this.View.Model.CurrentSchedule = this.scheduleService.GetTodaysSchedule(
                int.Parse(e.DayOfWeekId), int.Parse(e.ClassId));
        }
    }
}