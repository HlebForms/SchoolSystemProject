using System;

using SchoolSystem.WebForms.CustomControls.Admin.Models;
using SchoolSystem.WebForms.CustomControls.Admin.Views;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;
using SchoolSystem.WebForms.CustomControls.Admin.Presenters;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace SchoolSystem.WebForms.CustomControls.Admin
{
    [PresenterBinding(typeof(CreatingSubjectPresenter))]
    public partial class AddingSubjectUserControl : MvpUserControl<CreatingSubjcetModel>, ICreatingSubjectView
    {
        public event EventHandler<CreatingSubjectEventArgs> EventCreateSubject;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddSubjectBtn_Click(object sender, EventArgs e)
        {
            var subj = new CreatingSubjectEventArgs()
            {
                SubjectName = this.SubjectNameTextBox.Text
            };

            this.EventCreateSubject(this, subj);

            if (this.Model.IsSuccesfull)
            {
                // Notify admin 
                Response.Write("Done");
            }
            else
            {
                Response.Write("Error");
                // Notify Admin
            }
        }
    }
}