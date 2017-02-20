using NUnit.Framework;
using SchoolSystem.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Services.Tests.StudentManagementServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_studentsRepo_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new StudentManagementService(null));
        }
    }
}
