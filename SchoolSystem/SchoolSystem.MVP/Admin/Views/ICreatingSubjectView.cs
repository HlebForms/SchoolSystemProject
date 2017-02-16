using System;

using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Views.EventArguments;

using WebFormsMvp;

namespace SchoolSystem.MVP.Admin.Views
{
    public interface ICreatingSubjectView : IView<CreatingSubjcetModel>
    {
        event EventHandler<CreatingSubjectEventArgs> EventCreateSubject;
    }
}
