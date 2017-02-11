using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Contracts;
using Bytes2you.Validation;

namespace SchoolSystem.Web.Services
{
    public class MarksManagementService : IMarksManagementService
    {
        private readonly IRepository<SubjectStudent> subjectStudenRepo;

        public MarksManagementService(IRepository<SubjectStudent> subjectStudenRepo)
        {
            Guard.WhenArgument(subjectStudenRepo, "subjectStudenRepo").IsNull().Throw();

            this.subjectStudenRepo = subjectStudenRepo;
        }

        public IEnumerable<SchoolReportCard> GetMarks(int subjectId, int classOfStudentsId)
        {
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

            var result = this.subjectStudenRepo
                .GetAll(x => x.SubjectId == subjectId, x => x)
                .Select(x => new
                {
                    Name = x.Student.User,
                    Marks = string.Join(", ", Enumerable.Repeat(x.Mark.Value, x.Count))
                })
                .GroupBy(x => x.Name)
                .Select(x => new SchoolReportCard()
                {
                    FirstName = x.Key.FirstName,
                    LastName = x.Key.LastName,
                    Grades = x.Select(z => z.Marks)
                });

            return result;
        }
    }
}
