using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Web.Services;

namespace SchoolSystem.Services.Tests.StudentManagementServiceTests
{
    [TestFixture]
    public class GetAllStudentsFromClass_Should
    {
        [Test]
        public void Map_Data_Correctly()
        {
            var mockedStudentsRepo = new Mock<IRepository<Student>>();
            var service = new StudentManagementService(mockedStudentsRepo.Object);

            var user1 = new User { FirstName = "fname1", LastName = "lname1" };
            var user2 = new User { FirstName = "fname2", LastName = "lname2" };
            var user3 = new User { FirstName = "fname3", LastName = "lname3" };

            var student1 = new Student { Id = "id1", ClassOfStudentsId = 1, User = user1 };
            var student2 = new Student { Id = "id2", ClassOfStudentsId = 2, User = user2 };
            var student3 = new Student { Id = "id3", ClassOfStudentsId = 3, User = user3 };

            var students = new List<Student>()
            {
                student1,
                student2,
                student3
            };
            
            mockedStudentsRepo
                    .Setup(x => x.GetAll(
                            It.IsAny<Expression<Func<Student, bool>>>(),
                            It.IsAny<Expression<Func<Student, StudentInfoModel>>>(),
                            It.IsAny<Expression<Func<Student, object>>[]>()))
                    .Returns(
                        (Expression<Func<Student, bool>> predicate,
                         Expression<Func<Student, StudentInfoModel>> select,
                         Expression<Func<Student, object>>[] include) =>
                        students.Where(predicate.Compile()).Select(select.Compile()));

            var expected = service.GetAllStudentsFromClass(1).First();

            Assert.AreEqual(expected.Id, student1.Id);
            Assert.AreEqual(expected.Fullname, student1.User.FirstName + student1.User.LastName);
        }
    }
}
