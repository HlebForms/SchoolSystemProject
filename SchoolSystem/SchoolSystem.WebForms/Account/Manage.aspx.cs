using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolSystem.WebForms.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Tab1_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 0;
            Active_Tabs();
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 1;
            Active_Tabs();
        }

        private void Active_Tabs()
        {
            var tabs = this.Tabs.Controls;
            int count = 0;
            int selectedTabIndex = this.MultiView1.ActiveViewIndex;

            foreach (Button tab in tabs)
            {
                if (count == selectedTabIndex)
                {
                    tab.CssClass = "btn btn-primary tab";
                }
                else
                {
                    tab.CssClass = "btn btn-default tab";
                }
                count++;
            }
        }
    }
}