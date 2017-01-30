using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.WebForms.CustomControls.Admin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;

namespace SchoolSystem.WebForms.CustomControls.Admin.Presenters
{
    public class CreatingClassOfStudentsPresenter : Presenter<ICreatingClassOfStudentsView>
    {
        private readonly IClassOfStudentsManagementService classOfStudentsManagementService;
        public CreatingClassOfStudentsPresenter(ICreatingClassOfStudentsView view, IClassOfStudentsManagementService classOfStudentsManagementService)
            : base(view)
        {
            if (classOfStudentsManagementService == null)
            {
                throw new ArgumentNullException("classOfStudentsManagementService");
            }

            this.classOfStudentsManagementService = classOfStudentsManagementService;
            this.View.EventCreateClassOfStudents += this.CreateClassOfStudents;
            this.View.EventGetAllSubjects += this.GetAllSubjects;
        }

        private void GetAllSubjects(object sender, EventArgs e)
        {
            this.View.Model.Subjects = this.classOfStudentsManagementService.GetAllSubjects();
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