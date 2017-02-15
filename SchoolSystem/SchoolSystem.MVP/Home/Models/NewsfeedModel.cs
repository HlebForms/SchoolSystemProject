using SchoolSystem.Data.Models.CustomModels;
using System.Collections.Generic;

namespace SchoolSystem.MVP.Home.Models
{
    public class NewsfeedModel
    {
        public IEnumerable<NewsModel> Newsfeed { get; set; }

        public IEnumerable<NewsModel> ImportantNews { get; set; }

    }
}