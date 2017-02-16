using System;

using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.Web.Services.Contracts;

using Bytes2you.Validation;
using WebFormsMvp;

namespace SchoolSystem.MVP.Admin.Presenters
{
    public class AssignSubjectsToClassOfStudentsPresenter : Presenter<IAssignSubjectsToClassOfStudentsView>
    {
        private readonly IClassOfStudentsManagementService classOfStudentManagementService;
        private readonly ISubjectManagementService subjectManagementService;

        public AssignSubjectsToClassOfStudentsPresenter(
            IAssignSubjectsToClassOfStudentsView view,
            IClassOfStudentsManagementService classOfStudentManagementService,
            ISubjectManagementService subjectManagementService)
            : base(view)
        {
            Guard.WhenArgument(classOfStudentManagementService, "classOfStudentManagementService").IsNull().Throw();
            Guard.WhenArgument(subjectManagementService, "subjectManagementService").IsNull().Throw();

            this.classOfStudentManagementService = classOfStudentManagementService;
            this.subjectManagementService = subjectManagementService;

            this.View.EventGetAllClassOfStudents += View_EventGetAllClassOfStudents;
            this.View.EventGetAvailableSubjectsForTheClass += View_EventGetAvailableSubjectsForTheClass;
            this.View.EventAssignSubjectsToClassOfStudents += View_EventAssignSubjectsToClassOfStudents;
        }

        private void View_EventAssignSubjectsToClassOfStudents(object sender, Views.EventArguments.AssignSubjectsToClassOfStudentsEventArgs e)
        {
            this.View.Model.IsAddingSubjectsSuccesfull =
                this.classOfStudentManagementService.AddSubjectsToClass(e.ClassOfStudentsId, e.SubjectIdsToBeAdded);
        }

        private void View_EventGetAvailableSubjectsForTheClass(object sender, Views.EventArguments.GetAvailableSubjectsForTheClassEventArgs e)
        {
            this.View.Model.AvailableSubjects = 
                subjectManagementService.GetSubjectsNotYetAssignedToTheClass(e.ClassOfStudentsId);
        }

        private void View_EventGetAllClassOfStudents(object sender, EventArgs e)
        {
            this.View.Model.ClassOfStudents = this.classOfStudentManagementService.GetAllClasses();
        }
    }
}