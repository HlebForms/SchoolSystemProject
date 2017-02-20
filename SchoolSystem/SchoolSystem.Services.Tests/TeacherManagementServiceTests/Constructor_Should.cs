using NUnit.Framework;
using SchoolSystem.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Services.Tests.TeacherManagementServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_teachersRepo_IsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new TeacherManagementService(null));
        }
    }
}
