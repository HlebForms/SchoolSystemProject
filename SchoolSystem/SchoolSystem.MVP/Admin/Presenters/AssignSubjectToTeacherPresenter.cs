using System;

using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

using Bytes2you.Validation;
using WebFormsMvp;

namespace SchoolSystem.MVP.Admin.Presenters
{
    public class AssignSubjectToTeacherPresenter : Presenter<IAssignSubjectToTeacherView>
    {
        private readonly ITeacherManagementService teacherManagementService;
        private readonly ISubjectManagementService subjectManagementService;

        public AssignSubjectToTeacherPresenter(
            IAssignSubjectToTeacherView view,
            ITeacherManagementService teacherManagementService,
            ISubjectManagementService subjectManagementService
            )
            : base(view)
        {
            Guard.WhenArgument(teacherManagementService, "teacherManagementService").IsNull().Throw();
            Guard.WhenArgument(subjectManagementService, "subjectManagementService").IsNull().Throw();

            this.teacherManagementService = teacherManagementService;
            this.subjectManagementService = subjectManagementService;

            this.View.EventGetTeacher += View_EventGetTeacher;
            this.View.EventGetSubjectsWithoutTeacher += View_EventGetSubjectsWithoutTeacher;
            this.View.EventAssignSubjectsToTeacher += View_EventAssignSubjectsToTeacher;
        }

        private void View_EventAssignSubjectsToTeacher(object sender, AssignSubjectsToTeacherEventArgs e)
        {
            this.View.Model.IsAddingSuccessfull = this.subjectManagementService.AddSubjectsToTeacher(e.TeacherId, e.SubjectIds);
        }

        private void View_EventGetSubjectsWithoutTeacher(object sender, EventArgs e)
        {
            this.View.Model.SubjectsWithoutTeacher = this.subjectManagementService.GetAllSubjectsWithoutTeacher();
        }

        private void View_EventGetTeacher(object sender, EventArgs e)
        {
            this.View.Model.Teachers = this.teacherManagementService.GetAllTeachers();
        }
    }
}