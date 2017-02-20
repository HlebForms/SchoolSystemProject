using System;
using System.Linq;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.MVP.Admin.Views.EventArguments;

namespace SchoolSystem.WebForms.CustomControls.Admin
{
    [PresenterBinding(typeof(AssignSubjectToTeacherPresenter))]
    public partial class AssignSubjectToTeacherControl : MvpUserControl<AssignSubjectToTeacherModel>, IAssignSubjectToTeacherView
    {
        public event EventHandler EventGetSubjectsWithoutTeacher;
        public event EventHandler EventGetTeacher;
        public event EventHandler<AssignSubjectsToTeacherEventArgs> EventAssignSubjectsToTeacher;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.EventGetTeacher(this, e);
                this.TeacherDropDown.DataSource = this.Model.Teachers;
                this.TeacherDropDown.DataBind();

                this.BindSubjectsCheckboxList(e);
            }
        }

        private void BindSubjectsCheckboxList(EventArgs e)
        {
            this.EventGetSubjectsWithoutTeacher(this, e);
            this.SubjectsWithoutTeacherCheboxList.DataSource = this.Model.SubjectsWithoutTeacher;
            this.SubjectsWithoutTeacherCheboxList.DataBind();
        }

        protected void TeacherDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AssignSubjectsToTeacherBtn_Click(object sender, EventArgs e)
        {
            var selectedSubjectsIds = this.SubjectsWithoutTeacherCheboxList.Items
                   .Cast<ListItem>()
                   .Where(i => i.Selected)
                   .Select(x => int.Parse(x.Value))
                   .ToList();

            if (selectedSubjectsIds.Count == 0)
            {
                this.Notifier.NotifyError("Моля изберете поне един предмет от списъка!");
                return;
            }

            this.EventAssignSubjectsToTeacher(this, new AssignSubjectsToTeacherEventArgs
            {
                TeacherId = this.TeacherDropDown.SelectedValue,
                SubjectIds = selectedSubjectsIds
            });

            if (this.Model.IsAddingSuccessfull)
            {
                this.Notifier.NotifySuccess("Предметите са добавени успешно");
                this.BindSubjectsCheckboxList(e);
            }
            else
            {
                this.Notifier.NotifySuccess("Възникна грешка! Опитайте отново!");

            }
        }
    }
}