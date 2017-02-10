using Microsoft.AspNet.Identity;
using Ninject;
using SchoolSystem.Data;
using SchoolSystem.Data.Models;
using SchoolSystem.WebForms.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolSystem.WebForms.CustomControls.Teacher
{
    public partial class AdddingMarksControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var kernel = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();

                var teacherId = this.Page.User.Identity.GetUserId();

                this.SubjectsDropDown.DataSource = kernel.Subjects.Where(x => x.TeacherId == teacherId).ToList();
                this.SubjectsDropDown.DataBind();

            }
        }

        protected void SubjectsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kernel = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();

            var subjectId = int.Parse(this.SubjectsDropDown.SelectedValue);
            var classes = kernel
                .SubjectClassOfStudents.Where(x => x.SubjectId == subjectId)
                .Select(x => new
                {
                    Id = x.ClassOfStudentsId,
                    Name = x.ClassOfStudents.Name
                }).ToList();

            this.ClassOfStudentsDropDown.DataSource = classes;
            this.ClassOfStudentsDropDown.DataBind();
        }

        protected void ClassOfStudentsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kernel = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();
            var teacherId = this.Page.User.Identity.GetUserId();

            var subjectid = int.Parse(this.SubjectsDropDown.SelectedValue);
            var classOfStudentsid = int.Parse(this.ClassOfStudentsDropDown.SelectedValue);

            var result = kernel
                .SubjectStudent
                .Where(x => x.SubjectId == subjectid && x.Student.ClassOfStudentsId == classOfStudentsid)
                .ToList()
               .Select(x => new
               {
                   Name = x.Student.User,
                   Marks = string.Join(", ", Enumerable.Repeat(x.Mark.Value, x.Count))
               })
               .GroupBy(x => x.Name)
               .Select(x => new Model
               {
                   Name = x.Key.FirstName + " " + x.Key.LastName,
                   StudentId = x.Key.Id,
                   grades = x.Select(z => z.Marks)
               })
                .ToList();


            this.GradesList.DataSource = result;
            this.GradesList.DataBind();
            //var result = kernel
            //     .SubjectStudent
            //     .Where(x => x.SubjectId == subjectid && x.Student.ClassOfStudentsId == classOfStudentsid)
            //     .ToList();

            //var result = kernel.ClassOfStudents.Where(x => x.Id == classOfStudentsid);

        }

        public IEnumerable<CustomStudent> PopulateStudentsDropDown()
        {
            var kernel = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();

            var res = kernel.Students.Select(x => new CustomStudent
            {
                Fullname = x.User.FirstName + " " + x.User.LastName,
                Id = x.Id
            }).ToList();

            return res;
        }

        public IEnumerable<Mark> PopulateMarksDropDown()
        {
            var kernel = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();

            var res = kernel.Marks.ToList();

            return res;
        }

        protected void GradesList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

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