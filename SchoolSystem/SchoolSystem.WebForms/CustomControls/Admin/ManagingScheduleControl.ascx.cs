using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SchoolSystem.Data.Models;

using WebFormsMvp.Web;
using WebFormsMvp;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.MVP.Admin.Views;

namespace SchoolSystem.WebForms.CustomControls.Admin
{
    [PresenterBinding(typeof(ManagingSchedulePresenter))]
    public partial class CreateScheduleControl : MvpUserControl<ManagingScheduleControlModel>, IManagingScheduleView
    {
        public event EventHandler<EventArgs> EventBindAllClasses;
        public event EventHandler<ManagingScheduleEventArgs> EventBindScheduleData;
        public event EventHandler<EventArgs> EventBindDaysOfWeek;
        public event EventHandler<AddingSubjectToScheduleEventArgs> EventAddSubjectToSchedule;
        public event EventHandler<BindSubjectsForClassEventArgs> EventBitSubjectForCurrentClass;
        public event EventHandler<RemovingSubjectFromScheduleEventArgs> EventRemoveSubjectFromSchedule;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.EventBindAllClasses(this, e);
                this.ClassOfStudentsDropDown.DataSource = this.Model.AllClassOfStudents;
                this.ClassOfStudentsDropDown.DataBind();

                this.EventBindDaysOfWeek(this, e);
                this.DaysOfWeekDropDown.DataSource = this.Model.DaysOfWeek;
                this.DaysOfWeekDropDown.DataBind();

                this.BindShceduleData();
            }

        }

        public void DaysOfWeekDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindShceduleData();
        }

        protected void ScheduleList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            var dayOfWeekId = int.Parse(this.DaysOfWeekDropDown.SelectedValue);
            var classId = int.Parse(this.ClassOfStudentsDropDown.SelectedValue);

            switch (e.CommandName)
            {
                case ("Insert"):
                    var subjectDropDown = e.Item.FindControl("AddingSubjectDropDown") as DropDownList; 
                    var selectedSubjectId = int.Parse(subjectDropDown.SelectedValue);

                    var startHourDropDown = e.Item.FindControl("StartHourDropDown") as DropDownList;
                    var startHour = int.Parse(startHourDropDown.SelectedValue);

                    // public DateTime(int year, int month, int day, int hour, int minute, int second);
                    var currentYear = DateTime.Now.Year;
                    var startHourDateTime = new DateTime(currentYear, 1, 1, startHour, 0, 0);

                    var endHourDropDown = e.Item.FindControl("EndHourDropDown") as DropDownList;
                    var endHour = int.Parse(endHourDropDown.SelectedValue);
                    var endHourAsDateTime = new DateTime(currentYear, 1, 1, endHour, 0, 0);

                    this.ScheduleList_InsertItem(classId, dayOfWeekId, selectedSubjectId, startHourDateTime, endHourAsDateTime);
                    break;
                case ("Delete"):
                    int subjId = int.Parse(e.CommandArgument.ToString());
                    this.ScheduleList_DeleteItem(classId, dayOfWeekId, subjId);
                    break;
            }
        }

        private void ScheduleList_DeleteItem(int classId, int dayOfWeekId, int selectedSubjectId)
        {
            this.EventRemoveSubjectFromSchedule(this, new RemovingSubjectFromScheduleEventArgs()
            {
                ClassId = classId,
                DaysOfWeekId = dayOfWeekId,
                SubjectId = selectedSubjectId
            });
        }

        private void ScheduleList_InsertItem(int classId, int dayOfWeekId, int selectedSubjectId, DateTime sartHour, DateTime endHour)
        {
            this.EventAddSubjectToSchedule(this, new AddingSubjectToScheduleEventArgs()
            {
                ClassId = classId,
                DaysOfWeekId = dayOfWeekId,
                StartHour = sartHour,
                EndHour = endHour,
                SubjectId = selectedSubjectId
            });

            if (!this.Model.IsInsertingSuccessFull)
            {
                this.Notifier.NotifyError("В един ден предметите не могат да се повтарят!");
            }
        }

        public IEnumerable<Subject> PopulateSubjects()
        {
            this.EventBitSubjectForCurrentClass(this, new BindSubjectsForClassEventArgs()
            {
                ClassId = int.Parse(this.ClassOfStudentsDropDown.SelectedValue)
            });

            return this.Model.SubjectForCurrentClass;
        }

        protected void ScheduleList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            this.BindShceduleData();
        }

        protected void ScheduleList_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            this.BindShceduleData();
        }

        private void BindShceduleData()
        {
            this.EventBindScheduleData(this, new ManagingScheduleEventArgs()
            {
                ClassId = int.Parse(this.ClassOfStudentsDropDown.SelectedValue),
                DayOfWeekId = int.Parse(this.DaysOfWeekDropDown.SelectedValue)
            });

            this.ScheduleList.DataSource = this.Model.CurrentSchedule;
            this.ScheduleList.DataBind();
        }
    }
}
