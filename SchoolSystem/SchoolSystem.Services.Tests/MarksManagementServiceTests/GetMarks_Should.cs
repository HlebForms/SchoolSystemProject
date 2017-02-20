using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Services.Tests.MarksManagementServiceTests
{
    [TestFixture]
    public class GetMarks_Should
    {
        //[Test]
        //public void GetTheMarksForSpecifiedSubject_WhenArgumentsAreValid()
        //{
        //    var mockedSubjectStudentRepo = new Mock<IRepository<SubjectStudent>>();
        //    var mockedMarksRepo = new Mock<IRepository<Mark>>();
        //    var mockedUnitOfWork = new Mock<IUnitOfWork>();

        //    IEnumerable<SubjectStudent> colection = new List<SubjectStudent>()
        //    {
        //        new SubjectStudent()
        //        {
        //            SubjectId = 1,
        //            Student = new Student()
        //            {
        //                ClassOfStudentsId =1,
        //                User = new User() {Id = "1", FirstName="John", LastName="Doe" }
        //            },
        //            Mark = new Mark() {  Id=1,Value=1},
        //            Count = 1
        //        }
        //    };

        //    IEnumerable<SchoolReportCardModel> expected = null;

        //    mockedSubjectStudentRepo
        //        .Setup(
        //        x => x.GetAll(
        //            It.IsAny<Expression<Func<SubjectStudent, bool>>>(),
        //            It.IsAny<Expression<Func<SubjectStudent, SubjectStudent>>>(),
        //            It.IsAny<Expression<Func<SubjectStudent, object>>>()))
        //        .Returns(
        //            (Expression<Func<SubjectStudent, bool>> predicate,
        //            Expression<Func<SubjectStudent, SubjectStudent>> select,
        //            Expression<Func<SubjectStudent, object>> include,
        //            Expression<Func<SubjectStudent, dynamic>> s) =>
        //          expected = colection.Where(predicate.Compile())
        //           .Select(select.Compile())
        //           .Select(s.Compile())
        //           .GroupBy(x => x.)



        //    var service = new MarksManagementService(
        //                  mockedSubjectStudentRepo.Object,
        //                  mockedMarksRepo.Object,
        //                  () => mockedUnitOfWork.Object);

        //    var result = service.GetMarks(1, 1);

        //    CollectionAssert.AreEquivalent(expected, result);
        //}
    }
}
