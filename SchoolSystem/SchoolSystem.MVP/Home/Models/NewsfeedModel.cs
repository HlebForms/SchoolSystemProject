using System.Collections.Generic;

using SchoolSystem.Data.Models.CustomModels;

namespace SchoolSystem.MVP.Home.Models
{
    public class NewsfeedModel
    {
        public IEnumerable<NewsModel> Newsfeed { get; set; }

        public IEnumerable<NewsModel> ImportantNews { get; set; }
    }
}