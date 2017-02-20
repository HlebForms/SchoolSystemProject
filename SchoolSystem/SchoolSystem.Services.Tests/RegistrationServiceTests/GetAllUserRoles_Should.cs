using Microsoft.AspNet.Identity.EntityFramework;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;
using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Services.Tests.RegistrationServiceTests
{
    [TestFixture]
   public class GetAllUserRoles_Should
    {
        [Test]
        public void Call_userRolesRepo_GetAll_Method_Once()
        {
            var mockedUserRolesRepo = new Mock<IRepository<IdentityRole>>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedStudentRepo = new Mock<IRepository<Student>>();
            var mockedTeacherRepo = new Mock<IRepository<Teacher>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var service = new RegistrationService(
                mockedUserRolesRepo.Object,
                mockedSubjectManagementService.Object,
                mockedStudentRepo.Object,
                mockedTeacherRepo.Object,
                mockedUnitOfWork.Object);

            service.GetAllUserRoles();

            mockedUserRolesRepo.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
