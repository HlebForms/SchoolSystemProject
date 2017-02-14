using SchoolSystem.WebForms.CustomControls.Admin.Models;
using SchoolSystem.WebForms.CustomControls.Admin.Presenters;
using SchoolSystem.WebForms.CustomControls.Admin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SchoolSystem.WebForms.CustomControls.Admin
{
    [PresenterBinding(typeof(AssignSubjectToTeacherPresenter))]
    public partial class AssignSubjectToTeacherControl : MvpUserControl<AssignSubjectToTeacherModel>, IAssignSubjectToTeacherView
    {
        public event EventHandler EventGetSubjectsWithoutTeacher;
        public event EventHandler EventGetTeacher;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.EventGetTeacher(this, e);
                this.TeacherDropDown.DataSource = this.Model.Teachers;
                this.TeacherDropDown.DataBind();

                this.EventGetSubjectsWithoutTeacher(this, e);
                this.SubjectsWithoutTeacherCheboxList.DataSource = this.Model.SubjectsWithoutTeacher;
                this.SubjectsWithoutTeacherCheboxList.DataBind();
            }
        }

        protected void TeacherDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}