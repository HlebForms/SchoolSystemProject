using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;

using WebFormsMvp.Web;
using WebFormsMvp;
using SchoolSystem.MVP.Teacher.Views.EventArguments;
using SchoolSystem.MVP.Teacher.Presenters;
using SchoolSystem.MVP.Teacher.Models;
using SchoolSystem.MVP.Teacher.Views;

namespace SchoolSystem.WebForms.CustomControls.Teacher
{
    [PresenterBinding(typeof(ManagingMarksPresenter))]
    public partial class AdddingMarksControl : MvpUserControl<ManagingMarksModel>, IManagingMarksView
    {
        public event EventHandler<BindSubjectsEventArgs> EventBindSubjectsForTheSelectedTeacher;
        public event EventHandler<BindClassesEventArgs> EventBindClasses;
        public event EventHandler<BindSchoolReportCardEventArgs> EventBindSchoolReportCard;
        public event EventHandler<InserMarkEventArgs> EventInsertMark;
        public event EventHandler<BindStudentsEventArgs> EventBindStudents;
        public event EventHandler EventBindMarks;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.EventBindSubjectsForTheSelectedTeacher(this, new BindSubjectsEventArgs()
                {
                    TecherName = this.Page.User.Identity.Name
                });

                this.SubjectsDropDown.DataSource = this.Model.SubjectsForTheSpecifiedTeacher;
                this.SubjectsDropDown.DataBind();

                this.BindClassOfStudentsDropDown();
            }
        }

        public IEnumerable<StudentInfoModel> PopulateStudentsDropDown()
        {
            this.EventBindStudents(this, new BindStudentsEventArgs()
            {
                ClassId = int.Parse(this.ClassOfStudentsDropDown.SelectedValue)
            });

            return this.Model.Students;
        }

        public IEnumerable<Mark> PopulateMarksDropDown()
        {
            this.EventBindMarks(this, null);

            return this.Model.Marks;
        }

        protected void SubjectsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindClassOfStudentsDropDown();

            this.BindSchoolReportCard();
        }

        protected void ClassOfStudentsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindSchoolReportCard();
        }

        protected void SchoolReportCardListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            var studentsDropDown = e.Item.FindControl("StudentsDropDown") as DropDownList;
            var markDropDown = e.Item.FindControl("MarksDropDown") as DropDownList;

            if (e.CommandName == "Insert")
            {
                var markToAdd = int.Parse(markDropDown.SelectedValue);
                var student = studentsDropDown.SelectedValue;
                var subjectid = int.Parse(this.SubjectsDropDown.SelectedValue);

                this.EventInsertMark(this, new InserMarkEventArgs()
                {
                    MarkId = markToAdd,
                    StudentId = student,
                    SubjectId = subjectid
                });
            }
        }

        protected void SchoolReportCardListView_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            this.BindSchoolReportCard();
        }

        private void BindClassOfStudentsDropDown()
        {
            var subjectId = int.Parse(this.SubjectsDropDown.SelectedValue);
            this.EventBindClasses(this, new BindClassesEventArgs()
            {
                SubjectId = subjectId
            });

            this.ClassOfStudentsDropDown.DataSource = this.Model.StudentClasses;
            this.ClassOfStudentsDropDown.DataBind();

            this.BindSchoolReportCard();
        }

        private void BindSchoolReportCard()
        {
            var subjectid = int.Parse(this.SubjectsDropDown.SelectedValue);
            var classOfStudentsid = int.Parse(this.ClassOfStudentsDropDown.SelectedValue);

            this.EventBindSchoolReportCard(this, new BindSchoolReportCardEventArgs()
            {
                ClassOfStudentsId = classOfStudentsid,
                SubjectId = subjectid
            });

            this.SchoolReportCardListView.DataSource = this.Model.SchoolReportCard;
            this.SchoolReportCardListView.DataBind();
        }
    }
}