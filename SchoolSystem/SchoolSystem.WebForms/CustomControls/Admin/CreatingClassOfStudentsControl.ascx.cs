using SchoolSystem.WebForms.CustomControls.Admin.Models;
using SchoolSystem.WebForms.CustomControls.Admin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;
using SchoolSystem.WebForms.CustomControls.Admin.Presenters;
using WebFormsMvp;
using SchoolSystem.WebForms.CustomControls.Notifier;

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
                
                this.Notifier.NotifySuccess("Stana");
            }
            else
            {
                this.Notifier.NotifyError("NE stana");
            }
        }
    }
}