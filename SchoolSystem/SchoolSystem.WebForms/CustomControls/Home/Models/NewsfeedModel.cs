using SchoolSystem.Data.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Home.Models
{
    public class NewsfeedModel
    {
        public IEnumerable<NewsModel> Newsfeed { get; set; }

        public IEnumerable<NewsModel> ImportantNews { get; set; }

    }
}