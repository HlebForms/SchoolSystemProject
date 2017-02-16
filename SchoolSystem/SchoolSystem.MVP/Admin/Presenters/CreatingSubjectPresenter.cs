using System;

using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

using WebFormsMvp;

namespace SchoolSystem.MVP.Admin.Presenters
{
    public class CreatingSubjectPresenter : Presenter<ICreatingSubjectView>
    {
        private readonly ISubjectManagementService subjectManagementService;

        public CreatingSubjectPresenter(ICreatingSubjectView view, ISubjectManagementService subjectManagementService) : base(view)
        {
            if (subjectManagementService == null)
            {
                throw new ArgumentNullException("subjectManagementService");
            }

            this.subjectManagementService = subjectManagementService;
            this.View.EventCreateSubject += CreateSubject;
        }

        private void CreateSubject(object sender, CreatingSubjectEventArgs e)
        {
            e.AvatarFile.SaveAs(e.SubjectPictureStoragePath);

            var result = this.subjectManagementService.CreateSubject(e.SubjectName, e.SubjectPictureUrl);

            if (result)
            {
                this.View.Model.IsSuccesfull = true;
            }
            else
            {
                this.View.Model.IsSuccesfull = false;
            }
        }
    }
}