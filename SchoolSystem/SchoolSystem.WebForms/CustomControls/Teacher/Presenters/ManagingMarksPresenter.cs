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
    public class ManagingMarksPresenter : Presenter<IManagingMarksView>
    {
        private readonly ISubjectManagementService subjectManagementService;
        private readonly IClassOfStudentsManagementService classOfStudentsManagementService;
        private readonly IMarksManagementService marksManagementService;

        public ManagingMarksPresenter(
            IManagingMarksView view,
            ISubjectManagementService subjectManagementService,
            IClassOfStudentsManagementService classOfStudentsManagementService,
            IMarksManagementService marksManagementService)
            : base(view)
        {
            Guard.WhenArgument(subjectManagementService, "subjectManagementService").IsNull().Throw();
            Guard.WhenArgument(classOfStudentsManagementService, "classOfStudentsManagementService").IsNull().Throw();
            Guard.WhenArgument(marksManagementService, "marksManagementService").IsNull().Throw();

            this.subjectManagementService = subjectManagementService;
            this.classOfStudentsManagementService = classOfStudentsManagementService;
            this.marksManagementService = marksManagementService;

            this.View.EventBindSubjects += View_EventBindSubjects;
            this.View.EventBindClasses += View_EventBindClasses;
            this.View.EventBindMarks += View_EventBindMarks;
        }

        private void View_EventBindMarks(object sender, BindMarksEventArgs e)
        {
            this.View.Model.SchoolReportCard = this.marksManagementService.GetMarks(e.SubjectId, e.ClassOfStudentsId);
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