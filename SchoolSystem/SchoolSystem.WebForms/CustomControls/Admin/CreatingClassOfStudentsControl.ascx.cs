using System;
using System.Linq;
using System.Web.UI.WebControls;

using WebFormsMvp.Web;
using WebFormsMvp;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Views;

namespace SchoolSystem.WebForms.CustomControls.Admin
{
    [PresenterBinding(typeof(CreatingClassOfStudentsPresenter))]
    public partial class CreatingClassControl : MvpUserControl<CreatingClassOfStudentsModel>, ICreatingClassOfStudentsView
    {
        public event EventHandler<CreatingClassOfStudentsEventArgs> EventCreateClassOfStudents;
        public event EventHandler<EventArgs> EventGetAllSubjects;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.EventGetAllSubjects(this, e);
                this.SubjectsList.DataSource = this.Model.Subjects;
                this.SubjectsList.DataBind();
            }
        }

        protected void CreateClsasBtn_Click(object sender, EventArgs e)
        {
            var subjects = this.SubjectsList.Items.Cast<ListItem>().Where(i => i.Selected).Select(x => x.Value).ToList();

            var args = new CreatingClassOfStudentsEventArgs()
            {
                ClassName = this.ClassNameTextBox.Text,
                SubjectIds = subjects
            };
            this.EventCreateClassOfStudents(this, args);

            if (this.Model.IsSuccesfull)
            {
                this.SubjectsList.ClearSelection();
                this.ClassNameTextBox.Text = string.Empty;
                
                this.Notifier.NotifySuccess("Класът е създаден!");
            }
            else
            {
                this.Notifier.NotifyError("Възникна грешка!");
            }
        }
    }
}