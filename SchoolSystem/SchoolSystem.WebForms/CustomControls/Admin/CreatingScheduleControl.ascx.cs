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
using SchoolSystem.Data.Models;
using Ninject;
using SchoolSystem.WebForms.App_Start;
using System.Data.Entity;
using SchoolSystem.Data;
using System.Windows.Forms;

namespace SchoolSystem.WebForms.CustomControls.Admin
{
    [PresenterBinding(typeof(CreatingSchedulePresenter))]
    public partial class CreateScheduleControl : MvpUserControl<CreatingScheduleModel>, ICreatingScheduleView
    {

        private readonly SchoolSystemDbContext context;
        public event EventHandler<EventArgs> EventBindAllClasses;
        public event EventHandler<CreatingScheduleEventArgs> EventBindScheduleData;
        public event EventHandler<EventArgs> EventBindDaysOfWeek;

        public CreateScheduleControl()
        {
            this.context = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.EventBindAllClasses(this, e);
                this.ClassOfStudentsDropDown.DataSource = this.Model.AllClassOfStudents;
                this.ClassOfStudentsDropDown.DataBind();

                this.EventBindDaysOfWeek(this, e);
                this.DaysOfWeekDropDown.DataSource = this.Model.DaysOfWeek;
                this.DaysOfWeekDropDown.DataBind();
                this.EventBindScheduleData(this, new CreatingScheduleEventArgs()
                {
                    ClassId = this.ClassOfStudentsDropDown.SelectedValue,
                    DayOfWeekId = this.DaysOfWeekDropDown.SelectedValue
                });

                this.ScheduleList.DataSource = this.Model.CurrentSchedule;
                this.ScheduleList.DataBind();
            }
        }

        public void DaysOfWeekDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EventBindScheduleData(this, new CreatingScheduleEventArgs()
            {
                ClassId = this.ClassOfStudentsDropDown.SelectedValue,
                DayOfWeekId = this.DaysOfWeekDropDown.SelectedValue
            });

            this.ScheduleList.DataSource = this.Model.CurrentSchedule;
            this.ScheduleList.DataBind();
        }

        public void ScheduleList_InsertItem()
        {
            var item = new SchoolSystem.WebForms.CustomControls.Admin.Models.Test();
            item.ClassName = this.ClassOfStudentsDropDown.SelectedItem.Text;
            item.DayOfWeek = this.DaysOfWeekDropDown.SelectedItem.Text;

            TryUpdateModel(item);
            if (this.Page.ModelState.IsValid)
            {
                // Save changes here
                //this.Model.CurrentSchedule.Add(item);
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ScheduleList_UpdateItem(int id)
        {
            SchoolSystem.WebForms.CustomControls.Admin.Models.Test item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            //item = this.Model.CurrentSchedule.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                // The item wasn't found
                this.Page.ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(item);
            if (this.Page.ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }

  
    }
}
