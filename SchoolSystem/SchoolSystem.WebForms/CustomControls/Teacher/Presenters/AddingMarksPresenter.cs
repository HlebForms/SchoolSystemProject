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
        private readonly IClassOfStudentsManagementService classOfStudentsManagementService;

        public AddingMarksPresenter(
            IAddingMarksView view,
            ISubjectManagementService subjectManagementService,
            IClassOfStudentsManagementService classOfStudentsManagementService)
            : base(view)
        {
            Guard.WhenArgument(subjectManagementService, "subjectManagementService").IsNull().Throw();
            Guard.WhenArgument(classOfStudentsManagementService, "classOfStudentsManagementService").IsNull().Throw();

            this.subjectManagementService = subjectManagementService;
            this.classOfStudentsManagementService = classOfStudentsManagementService;

            this.View.EventBindSubjects += View_EventBindSubjects;
            this.View.EventBindClasses += View_EventBindClasses;
        }

        private void View_EventBindClasses(object sender, BindClassesEventArgs e)
        {
            this.View.Model.StudentClasses = this.classOfStudentsManagementService.GetAllClassesWithSpecifiedSubject(e.SubjectId);
        }

        private void View_EventBindSubjects(object sender, BindSubjectsEventArgs e)
        {
            this.View.Model.Subjects = this.subjectManagementService.GetSubjectsPerTeacher(e.TecherName, e.IsAdmin);
        }
    }
}