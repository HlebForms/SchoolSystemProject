using Bytes2you.Validation;
using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.WebForms.CustomControls.Teacher.Views;
using SchoolSystem.WebForms.CustomControls.Teacher.Views.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Teacher.Presenters
{
    public class AddingMarksPresenter : Presenter<IAddingMarksView>
    {
        private readonly ISubjectManagementService subjectManagementService;

        public AddingMarksPresenter(
            IAddingMarksView view,
            ISubjectManagementService subjectManagementService)
            : base(view)
        {
            Guard.WhenArgument(subjectManagementService, "subjectManagementService").IsNull().Throw();

            this.subjectManagementService = subjectManagementService;

            this.View.EventBindSubjects += View_EventBindSubjects;
        }

        private void View_EventBindSubjects(object sender, BindSubjectsEventArgs e)
        {
            this.View.Model.Subjects = this.subjectManagementService.GetSubjectsPerTeacher(e.TecherName, e.IsAdmin);
        }
    }
}