using Microsoft.AspNet.Identity;
using Ninject;
using SchoolSystem.Data;
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



            //var result = kernel
            //    .SubjectClassOfStudents
            //    .Where(x => x.SubjectId == subjectid && x.ClassOfStudentsId == classOfStudentsid)
            //    .Select(x => x.ClassOfStudents
            //                .Students
            //                .Select(y => new Grades
            //                {
            //                    StudentName = y.User.FirstName + " " + y.User.LastName,
            //                    Marks = y.StudentSubj.Select(z => new Ocenka() { Name = z.Mark.Name, Count = z.Count })
            //                })).ToList();




            //var result = kernel
            //     .SubjectStudent
            //     .Where(x => x.SubjectId == subjectid && x.Student.ClassOfStudentsId == classOfStudentsid)
            //     .Select(x => new StudenGrade
            //     {
            //         Name = x.Student.User.FirstName,
            //         Grade = x.Mark.Value,
            //         GradeCount = x.Count
            //     })
            //     .ToList();


            var result = kernel
                .SubjectStudent
                .Where(x => x.SubjectId == subjectid && x.Student.ClassOfStudentsId == classOfStudentsid)
                .ToList()
               .Select(x => new
               {
                   Name = x.Student.User.UserName,
                   Marks = string.Join(", ", Enumerable.Repeat(x.Mark.Value, x.Count))
               })
               .GroupBy(x => x.Name)
               .Select(x => new Model
               {
                   Name = x.Key,
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
    }

    public class StudenGrade
    {
        public string Name { get; set; }

        public int Grade { get; set; }
        public int GradeCount { get; set; }

    }

    public class Model
    {
        public string Name { get; set; }

        public IEnumerable<string> grades { get; set; }
    }


}