using Ninject;
using SchoolSystem.Data;
using SchoolSystem.WebForms.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolSystem.WebForms.CustomControls.Home
{
    public partial class ImportantNewsControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected override void OnPreRender(EventArgs e)
        {
            var context = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();
          
            this.importantNewsList.DataSource = context.NewsFeed.Where(n => n.IsImportant == true).OrderByDescending(x => x.CreatedOn).ToList();
            this.importantNewsList.DataBind();
        }
    }
}