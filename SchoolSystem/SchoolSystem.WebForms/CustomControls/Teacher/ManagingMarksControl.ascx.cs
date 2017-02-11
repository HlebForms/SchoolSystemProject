using Microsoft.AspNet.Identity;
using Ninject;
using SchoolSystem.Data;
using SchoolSystem.Data.Models;
using SchoolSystem.WebForms.App_Start;
using SchoolSystem.WebForms.CustomControls.Teacher.Models;
using SchoolSystem.WebForms.CustomControls.Teacher.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using SchoolSystem.WebForms.CustomControls.Teacher.Views.EventArguments;
using SchoolSystem.Data.Models.Common;
using WebFormsMvp;
using SchoolSystem.WebForms.CustomControls.Teacher.Presenters;

namespace SchoolSystem.WebForms.CustomControls.Teacher
{
    [PresenterBinding(typeof(ManagingMarksPresenter))]
    public partial class AdddingMarksControl : MvpUserControl<ManagingMarksModel>, IManagingMarksView
    {
        public event EventHandler<BindSubjectsEventArgs> EventBindSubjects;
        public event EventHandler<BindClassesEventArgs> EventBindClasses;
        public event EventHandler<BindMarksEventArgs> EventBindMarks;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var kernel = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();

                this.EventBindSubjects(this, new BindSubjectsEventArgs()
                {
                    IsAdmin = this.Page.User.IsInRole(UserType.Admin),
                    TecherName = this.Page.User.Identity.Name
                });

                this.SubjectsDropDown.DataSource = this.Model.Subjects;
                this.SubjectsDropDown.DataBind();

                this.RiseEventBindClassOfStudentsDropDown();
            }

        }

        private void RiseEventBindClassOfStudentsDropDown()
        {
            var subjectId = int.Parse(this.SubjectsDropDown.SelectedValue);
            this.EventBindClasses(this, new BindClassesEventArgs()
            {
                SubjectId = subjectId
            });

            this.ClassOfStudentsDropDown.DataSource = this.Model.StudentClasses;
            this.ClassOfStudentsDropDown.DataBind();

            this.BindGradeList();
        }

        protected void SubjectsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RiseEventBindClassOfStudentsDropDown();

            this.BindGradeList();
        }

        protected void ClassOfStudentsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGradeList();
        }

        private void BindGradeList()
        {
            var kernel = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();

            var subjectid = int.Parse(this.SubjectsDropDown.SelectedValue);
            var classOfStudentsid = int.Parse(this.ClassOfStudentsDropDown.SelectedValue);

            this.EventBindMarks(this, new BindMarksEventArgs()
            {
                ClassOfStudentsId = classOfStudentsid,
                SubjectId = subjectid
            });

            this.GradesList.DataSource = this.Model.SchoolReportCard;
            this.GradesList.DataBind();

            //var result = kernel
            //    .SubjectStudent
            //    .Where(x => x.SubjectId == subjectid && x.Student.ClassOfStudentsId == classOfStudentsid)
            //    .ToList()
            //   .Select(x => new
            //   {
            //       Name = x.Student.User,
            //       Marks = string.Join(", ", Enumerable.Repeat(x.Mark.Value, x.Count))
            //   })
            //   .GroupBy(x => x.Name)
            //   .Select(x => new Model
            //   {
            //       Name = x.Key.FirstName + " " + x.Key.LastName,
            //       StudentId = x.Key.Id,
            //       grades = x.Select(z => z.Marks)
            //   })
            //    .ToList();

        }

        public IEnumerable<Mark> PopulateMarksDropDown()
        {
            var kernel = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();

            var res = kernel.Marks.ToList();

            return res;
        }

        protected void GradesList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            var kernel = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();

            var studentsDropDown = e.Item.FindControl("StudentsDropDown") as DropDownList;
            var markDropDown = e.Item.FindControl("MarksDropDown") as DropDownList;

            if (e.CommandName == "Insert")
            {

                var markToAdd = int.Parse(markDropDown.SelectedValue);
                var student = studentsDropDown.SelectedValue;
                var subjectid = int.Parse(this.SubjectsDropDown.SelectedValue);

                var st = kernel.SubjectStudent
                    .FirstOrDefault(x => x.StudentId == student && x.MarkId == markToAdd && x.SubjectId == subjectid);


                if (st == null)
                {
                    kernel.SubjectStudent.Add(new SubjectStudent()
                    {
                        SubjectId = int.Parse(SubjectsDropDown.SelectedValue),
                        MarkId = markToAdd,
                        StudentId = student,
                        Count = 1
                    });

                    kernel.SaveChanges();
                }
                else
                {
                    st.Count++;
                    kernel.SaveChanges();
                }

            }
        }

        public IEnumerable<CustomStudent> Test()
        {
            var kernel = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();

            int classId = int.Parse(this.ClassOfStudentsDropDown.SelectedValue);

            var res = kernel.Students.Where(x => x.ClassOfStudentsId == classId)
                .Select(x => new CustomStudent
                {
                    Fullname = x.User.FirstName + " " + x.User.LastName,
                    Id = x.Id
                }).ToList();

            return res;
        }

        protected void GradesList_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            this.BindGradeList();
        }
    }

    public class CustomStudent
    {
        public string Id { get; set; }

        public string Fullname { get; set; }
    }
    public class StudenGrade
    {
        public string Name { get; set; }

        public int Grade { get; set; }

        public int GradeCount { get; set; }

    }

    public class Model
    {
        public string StudentId { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> grades { get; set; }
    }


}