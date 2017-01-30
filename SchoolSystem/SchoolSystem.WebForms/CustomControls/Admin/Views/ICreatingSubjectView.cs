using SchoolSystem.WebForms.CustomControls.Admin.Models;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views
{
    public interface ICreatingSubjectControlView : IView<CreatingSubjcetModel>
    {
        event EventHandler<CreatingSubjectEventArgs> EventCreateSubject;
    }
}
