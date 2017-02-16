using System;

using SchoolSystem.MVP.Teacher.Views;
using SchoolSystem.MVP.Teacher.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

using Bytes2you.Validation;
using WebFormsMvp;

namespace SchoolSystem.MVP.Teacher.Presenters
{
    public class ManagingMarksPresenter : Presenter<IManagingMarksView>
    {
        private readonly ISubjectManagementService subjectManagementService;
        private readonly IClassOfStudentsManagementService classOfStudentsManagementService;
        private readonly IMarksManagementService marksManagementService;
        private readonly IStudentManagementService studentManagementService;

        public ManagingMarksPresenter(
            IManagingMarksView view,
            ISubjectManagementService subjectManagementService,
            IClassOfStudentsManagementService classOfStudentsManagementService,
            IStudentManagementService studentManagementService,
            IMarksManagementService marksManagementService)
            : base(view)
        {
            Guard.WhenArgument(subjectManagementService, "subjectManagementService").IsNull().Throw();
            Guard.WhenArgument(classOfStudentsManagementService, "classOfStudentsManagementService").IsNull().Throw();
            Guard.WhenArgument(marksManagementService, "marksManagementService").IsNull().Throw();
            Guard.WhenArgument(studentManagementService, "studentManagementService").IsNull().Throw();

            this.subjectManagementService = subjectManagementService;
            this.classOfStudentsManagementService = classOfStudentsManagementService;
            this.marksManagementService = marksManagementService;
            this.studentManagementService = studentManagementService;

            this.View.EventBindSubjectsForTheSelectedTeacher += View_EventBindSubjects;
            this.View.EventBindClasses += View_EventBindClasses;
            this.View.EventBindSchoolReportCard += View_EventBindSchoolReportCard;
            this.View.EventInsertMark += View_EventInsertMark;
            this.View.EventBindStudents += View_EventBindStudents;
            this.View.EventBindMarks += View_EventBindMarks;
        }

        private void View_EventBindMarks(object sender, EventArgs e)
        {
            this.View.Model.Marks = this.marksManagementService.GetAllMarks();
        }

        private void View_EventBindStudents(object sender, BindStudentsEventArgs e)
        {
            this.View.Model.Students = this.studentManagementService.GetAllStudentsFromClass(e.ClassId);
        }

        private void View_EventInsertMark(object sender, InserMarkEventArgs e)
        {
            this.marksManagementService.AddMark(e.StudentId, e.SubjectId, e.MarkId);
        }

        private void View_EventBindSchoolReportCard(object sender, BindReortCardEventArgs e)
        {
            this.View.Model.SchoolReportCard = this.marksManagementService.GetMarks(e.SubjectId, e.ClassOfStudentsId);
        }

        private void View_EventBindClasses(object sender, BindClassesEventArgs e)
        {
            this.View.Model.StudentClasses = this.classOfStudentsManagementService.GetAllClassesWithSpecifiedSubject(e.SubjectId);
        }

        private void View_EventBindSubjects(object sender, BindSubjectsEventArgs e)
        {
            this.View.Model.Subjects = this.subjectManagementService.GetSubjectsPerTeacher(e.TecherName);
        }
    }
}