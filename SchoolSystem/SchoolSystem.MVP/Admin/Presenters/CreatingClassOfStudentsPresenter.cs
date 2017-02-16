using System;

using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.MVP.Admin.Views;

using Bytes2you.Validation;
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
            ISubjectManagementService subjectManagementService
            )
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
            var result = this.classOfStudentsManagementService.AddClass(e.ClassName, e.SubjectIds);

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