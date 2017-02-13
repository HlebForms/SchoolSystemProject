using SchoolSystem.WebForms.CustomControls.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views
{
    public interface IAssignSubjectToTeacherView : IView<AssignSubjectToTeacherModel>
    {
        event EventHandler EventGetTeachersWithouthSubjects;

        event EventHandler EventGetSubjectsWithoutTeacher;
    }
}
