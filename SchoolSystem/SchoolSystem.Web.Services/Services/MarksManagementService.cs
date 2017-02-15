using System;
using System.Collections.Generic;
using System.Linq;

using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Contracts;

using Bytes2you.Validation;

namespace SchoolSystem.Web.Services
{
    public class MarksManagementService : IMarksManagementService
    {
        private readonly IRepository<SubjectStudent> subjectStudenRepo;
        private readonly IRepository<Mark> marksRepo;
        private readonly Func<IUnitOfWork> unitOfWork;

        public MarksManagementService(
            IRepository<SubjectStudent> subjectStudenRepo,
            IRepository<Mark> marksRepo,
            Func<IUnitOfWork> unitOfWork
            )
        {
            Guard.WhenArgument(subjectStudenRepo, "subjectStudenRepo").IsNull().Throw();
            Guard.WhenArgument(marksRepo, "marksRepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.subjectStudenRepo = subjectStudenRepo;
            this.marksRepo = marksRepo;
            this.unitOfWork = unitOfWork;
        }

        public void AddMark(string studentId, int subjectId, int markId)
        {
            var st = this.subjectStudenRepo
                .GetFirst(x => x.StudentId == studentId
                    && x.MarkId == markId
                    && x.SubjectId == subjectId);

            if (st == null)
            {
                using (var uow = this.unitOfWork())
                {
                    this.subjectStudenRepo.Add(new SubjectStudent()
                    {
                        SubjectId = subjectId,
                        MarkId = markId,
                        StudentId = studentId,
                        Count = 1
                    });

                    uow.Commit();
                }
            }
            else
            {
                using (var uow = this.unitOfWork())
                {
                    st.Count++;
                    uow.Commit();
                }
            }
        }

        public IEnumerable<Mark> GetAllMarks()
        {
            return this.marksRepo.GetAll();
        }

        public IEnumerable<SchoolReportCardModel> GetMarks(int subjectId, int classOfStudentsId)
        {
            var result = this.subjectStudenRepo
                .GetAll(x => x.SubjectId == subjectId && x.Student.ClassOfStudentsId == classOfStudentsId,
                s => s,
                i => i.Student,
                i => i.Student.User)
                .Select(x => new
                {
                    Name = x.Student.User,
                    Marks = string.Join(", ", Enumerable.Repeat(x.Mark.Value, x.Count))
                })
                .GroupBy(x => x.Name)
                .Select(x => new SchoolReportCardModel()
                {
                    FirstName = x.Key.FirstName,
                    LastName = x.Key.LastName,
                    Grades = x.Select(z => z.Marks)
                });

            return result;
        }

        public IEnumerable<StudentMarksModel> GetMarksForStudent(string studentName)
        {
            Guard.WhenArgument(studentName, "studentName").IsNullOrEmpty().Throw();

            var result = this.subjectStudenRepo
                    .GetAll(x => x.Student.User.UserName == studentName,
                    s => s,
                    i => i.Subject,
                    i => i.Student,
                    i => i.Student.User)
                    .Select(x => new
                    {
                        Name = x.Subject.Name,
                        MarkPerSubject = Enumerable.Repeat(x.Mark.Value, x.Count)
                    })
                    .GroupBy(x => x.Name)
                    .Select(x => new StudentMarksModel()
                    {
                        SubjectName = x.Key,
                        Marks = x.SelectMany(z => z.MarkPerSubject)
                    });

            return result;
        }
    }
}
