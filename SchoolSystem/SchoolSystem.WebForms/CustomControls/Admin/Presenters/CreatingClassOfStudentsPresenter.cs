using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.WebForms.CustomControls.Admin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;
using Bytes2you.Validation;

namespace SchoolSystem.WebForms.CustomControls.Admin.Presenters
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

            Guard.WhenArgument(classOfStudentsManagementService, "classOfStudentsManagementService").IsNotNull().Throw();
            Guard.WhenArgument(subjectManagementService, "subjectManagementService").IsNotNull().Throw();

            this.classOfStudentsManagementService = classOfStudentsManagementService;
            this.subjectManagementService = subjectManagementService;

            this.View.EventCreateClassOfStudents += this.CreateClassOfStudents;
            this.View.EventGetAllSubjects += this.GetAllSubjects;
        }

        private void GetAllSubjects(object sender, EventArgs e)
        {
            this.View.Model.Subjects = this.subjectManagementService.GetAllSubjects();
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