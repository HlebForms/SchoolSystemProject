using System;
using System.Linq;
using System.Web.UI.WebControls;

using SchoolSystem.WebForms.CustomControls.Admin.Models;
using SchoolSystem.WebForms.CustomControls.Admin.Presenters;
using SchoolSystem.WebForms.CustomControls.Admin.Views;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace SchoolSystem.WebForms.CustomControls.Admin
{
    [PresenterBinding(typeof(AssignSubjectsToClassOfStudentsPresenter))]
    public partial class AssignSubjectsToClassOfStudentsControl : MvpUserControl<AssignSubjectsToClassOfStudentsModel>, IAssignSubjectsToClassOfStudentsView
    {
        public event EventHandler EventGetAllClassOfStudents;
        public event EventHandler<GetAvailableSubjectsForTheClassEventArgs> EventGetAvailableSubjectsForTheClass;
        public event EventHandler<AssignSubjectsToClassOfStudentsEventArgs> EventAssignSubjectsToClassOfStudents;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.EventGetAllClassOfStudents(this, e);
                this.ClassOfStudentsDropDown.DataSource = this.Model.ClassOfStudents;
                this.ClassOfStudentsDropDown.DataBind();

                this.BindAvailableSubjects();
            }
        }

        private void BindAvailableSubjects()
        {
            this.EventGetAvailableSubjectsForTheClass(this, new GetAvailableSubjectsForTheClassEventArgs()
            {
                ClassOfStudentsId = int.Parse(this.ClassOfStudentsDropDown.SelectedValue)
            });

            this.AvailableSubjectsCheckboxList.DataSource = this.Model.AvailableSubjects;
        }

        protected void ClassOfStudentsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindAvailableSubjects();
        }

        protected void AddSubjectsToClassBtn_Click(object sender, EventArgs e)
        {
            var selectedSubjectsIds = this.AvailableSubjectsCheckboxList.Items
                    .Cast<ListItem>()
                    .Where(i => i.Selected)
                    .Select(x => int.Parse(x.Value))
                    .ToList();

            if (selectedSubjectsIds.Count == 0)
            {
                this.Notifier.NotifyError("Моля изберете поне един предмет от списъка!");
                return;
            }

            this.EventAssignSubjectsToClassOfStudents(this, new AssignSubjectsToClassOfStudentsEventArgs()
            {
                ClassOfStudentsId = int.Parse(this.ClassOfStudentsDropDown.SelectedValue),
                SubjectIdsToBeAdded = selectedSubjectsIds
            });

            if (this.Model.IsAddingSubjectsSuccesfull)
            {
                this.Notifier.NotifySuccess("Успешно добавихте предметите към класа");
                this.BindAvailableSubjects();
            }
            else
            {
                this.Notifier.NotifyError("Възникна грешка! Опитайте отново!");
            }
        }
    }
}