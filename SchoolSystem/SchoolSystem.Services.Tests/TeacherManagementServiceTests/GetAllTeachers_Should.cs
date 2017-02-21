using System;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Web.Services;

namespace SchoolSystem.Services.Tests.TeacherManagementServiceTests
{
    [TestFixture]
    public class GetAllTeachers_Should
    {
        [Test]
        public void Call_TeacherRepo_GetAll_Method_Once()
        {
            var mockedTeachersRepo = new Mock<IRepository<Teacher>>();

            var service = new TeacherManagementService(mockedTeachersRepo.Object);

            mockedTeachersRepo.Setup(x => x.GetAll(
                It.IsAny<Expression<Func<Teacher, bool>>>(),
                It.IsAny<Expression<Func<Teacher, TeacherBasicInfoModel>>>(),
                It.IsAny<Expression<Func<Teacher, object>>[]>()));

            service.GetAllTeachers();

            mockedTeachersRepo.Verify(x => x.GetAll(
                It.IsAny<Expression<Func<Teacher, bool>>>(),
                It.IsAny<Expression<Func<Teacher, TeacherBasicInfoModel>>>(),
                It.IsAny<Expression<Func<Teacher, object>>[]>()), 
                Times.Once);
        }
    }
}
