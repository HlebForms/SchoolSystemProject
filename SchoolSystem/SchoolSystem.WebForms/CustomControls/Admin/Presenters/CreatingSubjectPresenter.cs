using SchoolSystem.WebForms.CustomControls.Admin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.WebForms.CustomControls.Admin.Presenters
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
            var result = this.subjectManagementService.CreateSubject(e.SubjectName);

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