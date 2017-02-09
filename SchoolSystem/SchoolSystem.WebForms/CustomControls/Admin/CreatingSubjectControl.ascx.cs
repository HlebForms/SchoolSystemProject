using System;

using SchoolSystem.WebForms.CustomControls.Admin.Models;
using SchoolSystem.WebForms.CustomControls.Admin.Views;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;
using SchoolSystem.WebForms.CustomControls.Admin.Presenters;

using WebFormsMvp;
using WebFormsMvp.Web;
using System.IO;

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
            if (this.SubjectPicture.HasFile)
            {
                var file = this.SubjectPicture.PostedFile;

                string extension = Path.GetExtension(file.FileName);
                string subjectName = this.SubjectNameTextBox.Text;

                string filename = subjectName + extension;

                string subjectPictureStoragePath = Server.MapPath("~/Images/subject_images/") + filename;
                string subjectPictureUrl = "~/Images/subject_images/" + filename;

                var subj = new CreatingSubjectEventArgs()
                {
                    SubjectName = subjectName,
                    AvatarFile = file,
                    SubjectPictureStoragePath = subjectPictureStoragePath,
                    SubjectPictureUrl = subjectPictureUrl
                };

                this.EventCreateSubject(this, subj);

                if (this.Model.IsSuccesfull)
                {
                    this.Notifier.NotifySuccess("Предметът е създаден!");
                }
                else
                {
                    this.Notifier.NotifyError("Възникна грешка! (Вероятно вече съществува предмет с такова име)");
                }
            }
            else
            {
                this.Notifier.NotifyError("Mоля, прикачете картинка на предмета!");
            }
        }
    }
}