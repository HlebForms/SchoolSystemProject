using System;
using Bytes2you.Validation;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;
using WebFormsMvp;

namespace SchoolSystem.MVP.Admin.Presenters
{
    public class CreatingClassOfStudentsPresenter : Presenter<ICreatingClassOfStudentsView>
    {
        private readonly IClassOfStudentsManagementService classOfStudentsManagementService;
        private readonly ISubjectManagementService subjectManagementService;

        public CreatingClassOfStudentsPresenter(
            ICreatingClassOfStudentsView view,
            IClassOfStudentsManagementService classOfStudentsManagementService,
            ISubjectManagementService subjectManagementService)
            : base(view)
        {
            Guard.WhenArgument(classOfStudentsManagementService, "classOfStudentsManagementService").IsNull().Throw();
            Guard.WhenArgument(subjectManagementService, "subjectManagementService").IsNull().Throw();

            this.classOfStudentsManagementService = classOfStudentsManagementService;
            this.subjectManagementService = subjectManagementService;

            this.View.EventCreateClassOfStudents += this.CreateClassOfStudents;
            this.View.EventGetAllSubjects += this.GetAllSubjects;
        }

        private void GetAllSubjects(object sender, EventArgs e)
        {
            this.View.Model.Subjects = this.subjectManagementService.GetAllSubjectsWithTeacher();
        }

        private void CreateClassOfStudents(object sender, CreatingClassOfStudentsEventArgs e)
        {
            this.View.Model.IsSuccesfull = this.classOfStudentsManagementService.AddClass(e.ClassName, e.SubjectIds);
        }
    }
}