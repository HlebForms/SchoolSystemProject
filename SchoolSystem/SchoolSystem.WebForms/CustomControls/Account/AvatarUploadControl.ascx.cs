using Ninject;
using SchoolSystem.Data;
using SchoolSystem.WebForms.App_Start;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolSystem.WebForms.CustomControls.Account
{
    public partial class AvatarUploadControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadAvatarBtn_Click(object sender, EventArgs e)
        {
            var db = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();
            var loggedUserUserName = this.Context.User.Identity.Name;

            if (this.AvatarUpload.HasFile)
            {
                try
                {
                    if (this.AvatarUpload.PostedFile.ContentType == "image/jpeg")
                    {
                        if (this.AvatarUpload.PostedFile.ContentLength < 5 * 1000 * 1000)
                        {
                            string extension = Path.GetExtension(this.AvatarUpload.FileName);
                            string filename = loggedUserUserName + extension;

                            string avatarPath = Server.MapPath("~/Images/avatars/") + filename;
                            this.AvatarUpload.SaveAs(avatarPath);
                            this.StatusLabel.Text = "Upload status: File uploaded!";

                            db.Users.FirstOrDefault(x => x.UserName == loggedUserUserName).AvatarPictureUrl = "~/Images/avatars/" + filename;
                            db.SaveChanges();
                        }
                        else
                            this.StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        this.StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    this.StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
    }
}