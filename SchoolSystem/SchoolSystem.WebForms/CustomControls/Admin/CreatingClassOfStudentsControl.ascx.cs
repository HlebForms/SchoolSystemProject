using SchoolSystem.WebForms.CustomControls.Admin.Models;
using SchoolSystem.WebForms.CustomControls.Admin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;
using SchoolSystem.WebForms.CustomControls.Admin.Presenters;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Admin
{
    [PresenterBinding(typeof(CreatingClassOfStudentsPresenter))]
    public partial class CreatingClassControl :MvpUserControl<CreatingClassOfStudentsModel>, ICreatingClassOfStudentsView
    {
        public event EventHandler<CreatingClassOfStudentsEventArgs> EventCreateClassOfStudents;
        public event EventHandler<EventArgs> EventBindPageData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

            }
        }

        protected void CreateClsasBtn_Click(object sender, EventArgs e)
        {

        }
    }
}