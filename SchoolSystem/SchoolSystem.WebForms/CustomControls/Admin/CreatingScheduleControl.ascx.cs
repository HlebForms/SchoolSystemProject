using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using SchoolSystem.WebForms.CustomControls.Admin.Models;
using SchoolSystem.WebForms.CustomControls.Admin.Presenters;
using SchoolSystem.WebForms.CustomControls.Admin.Views;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;

using WebFormsMvp.Web;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Admin
{
    [PresenterBinding(typeof(CreatingSchedulePresenter))]
    public partial class CreateScheduleControl : MvpUserControl<CreatingScheduleModel>, ICreatingScheduleView
    {
        public event EventHandler<EventArgs> EventBindAllClasses;
        public event EventHandler<CreatingScheduleEventArgs> EventBindScheduleData;
        public event EventHandler<EventArgs> EventBindDaysOfWeek;
        public event EventHandler<AddingSubjectToScheduleEventArgs> EventAddSubjectToSchedule;
        public event EventHandler<BindSubjectsForClassEventArgs> EventBitSubjectForCurrentClass;
        public event EventHandler<RemovingSubjectFromScheduleEventArgs> EventRemoveSubjectFromSchedule;

        protected override void OnPreRender(EventArgs e)
        {
        }

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
            }
        }

        public void DaysOfWeekDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EventBindScheduleData(this, new CreatingScheduleEventArgs()
            {
                ClassId = this.ClassOfStudentsDropDown.SelectedValue,
                DayOfWeekId = this.DaysOfWeekDropDown.SelectedValue
            });
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
                    var startHourDateTime = new DateTime(2016, 1, 1, startHour, 0, 0);

                    var endHourDropDown = e.Item.FindControl("EndHourDropDown") as DropDownList;
                    var endHour = int.Parse(endHourDropDown.SelectedValue);
                    var endHourAsDateTime = new DateTime(2016, 1, 1, startHour, 0, 0);

                    this.ScheduleList_InsertItem(classId, dayOfWeekId, selectedSubjectId, startHourDateTime, endHourAsDateTime);
                    break;
                case ("Delete"):
                    var hiddenField = e.Item.FindControl("HiddenFielSubjectId") as HiddenField;
                    int subjId = int.Parse(hiddenField.Value);

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
        }

        public IEnumerable<ManagingScheduleModel> ScheduleList_GetData()
        {
            this.EventBindScheduleData(this, new CreatingScheduleEventArgs()
            {
                ClassId = this.ClassOfStudentsDropDown.SelectedValue,
                DayOfWeekId = this.DaysOfWeekDropDown.SelectedValue
            });

            return this.Model.CurrentSchedule;
        }

        public IEnumerable<Subject> PopulateSubjects()
        {
            this.EventBitSubjectForCurrentClass(this, new BindSubjectsForClassEventArgs()
            {
                ClassId = int.Parse(this.ClassOfStudentsDropDown.SelectedValue)
            });

            return this.Model.SubjectForCurrentClass;
        }
    }
}
