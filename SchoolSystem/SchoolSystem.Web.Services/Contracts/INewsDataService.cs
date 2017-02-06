using SchoolSystem.Data.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface INewsDataService
    {
        void AddNews(string username, string content, DateTime createdOn, bool isImportant);

        /// <summary>
        ///  Returns the important news for the last 5 days
        /// </summary>
        /// <returns></returns>
        IEnumerable<NewsModel> GetImportantNews();

        /// <summary>
        /// Returns the last "count" not important news (default value is 20)
        /// </summary>
        /// <param name="count">the number of news to return</param>
        /// <returns></returns>
        IEnumerable<NewsModel> GetNews(int count = 20);
    }
}
