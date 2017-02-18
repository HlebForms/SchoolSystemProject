using Bytes2you.Validation;
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
            Guard.WhenArgument(subjectManagementService, "subjectManagementService").IsNull().Throw();
            
            this.subjectManagementService = subjectManagementService;
            this.View.EventCreateSubject += this.CreateSubject;
        }

        private void CreateSubject(object sender, CreatingSubjectEventArgs e)
        {
            e.AvatarFile.SaveAs(e.SubjectPictureStoragePath);

            this.View.Model.IsSuccesfull = this.subjectManagementService.CreateSubject(e.SubjectName, e.SubjectPictureUrl);
        }
    }
}