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
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;
using System.Web.ModelBinding;

namespace SchoolSystem.WebForms.CustomControls.Admin
{
    [PresenterBinding(typeof(CreatingSchedulePresenter))]
    public partial class CreateScheduleControl : MvpUserControl<CreatingScheduleModel>, ICreatingScheduleView
    {
        public event EventHandler<EventArgs> EventBindAllClasses;
        public event EventHandler<CreatingScheduleEventArgs> EventBindScheduleData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.EventBindAllClasses(this, e);
                this.ClassOfStudentsDropDown.DataSource = this.Model.AllClassOfStudents;
                this.ClassOfStudentsDropDown.DataBind();

                //this.ScheduleList.DataSource = this.Model.CurrentSchedule.Where(x => x.DayOfWeek == this.DaysOfWeekDropDown.SelectedValue
                // && x.ClassName == this.ClassOfStudentsDropDown.SelectedItem.Text);

                //this.ScheduleList.DataBind();
            }
        }

        public void DaysOfWeekDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

            //this.ScheduleList.DataSource = this.Model.CurrentSchedule.Where(x => x.DayOfWeek == this.DaysOfWeekDropDown.SelectedValue
            //     && x.ClassName == this.ClassOfStudentsDropDown.SelectedItem.Text);
            //this.ScheduleList.DataBind();
        }

        protected void ScheduleList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ScheduleList_UpdateItem(int id)
        {
            SchoolSystem.WebForms.CustomControls.Admin.Models.Test item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            item = this.Model.CurrentSchedule.FirstOrDefault();

            if (item == null)
            {
                // The item wasn't found
                //ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            //if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<SchoolSystem.WebForms.CustomControls.Admin.Models.Test> ScheduleList_GetData()
        {
            return this.Model.CurrentSchedule.AsQueryable();
        }
    }
}
