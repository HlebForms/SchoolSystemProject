using SchoolSystem.WebForms.CustomControls.Home.Models;
using SchoolSystem.WebForms.CustomControls.Home.Views.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Home.Views
{
    public interface INewsfeedView : IView<NewsfeedModel>
    {
        event EventHandler EventBindNewsfeedData;

        event EventHandler<AddNewsEventargs> EventAddNews;
    }
}