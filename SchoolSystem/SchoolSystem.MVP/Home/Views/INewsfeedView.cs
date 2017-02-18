using System;
using SchoolSystem.MVP.Home.Models;
using SchoolSystem.MVP.Home.Views.EventArguments;
using WebFormsMvp;

namespace SchoolSystem.MVP.Home.Views
{
    public interface INewsfeedView : IView<NewsfeedModel>
    {
        event EventHandler EventBindNewsfeedData;

        event EventHandler<AddNewsEventargs> EventAddNews;
    }
}