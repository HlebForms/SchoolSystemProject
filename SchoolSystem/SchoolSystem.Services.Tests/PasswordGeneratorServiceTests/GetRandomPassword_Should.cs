using Moq;
using NUnit.Framework;
using SchoolSystem.Services.Tests.PasswordGeneratorServiceTests.Mocks;
using SchoolSystem.Web.Providers.Contracts;

namespace SchoolSystem.Services.Tests.PasswordGeneratorServiceTests
{
    [TestFixture]
    public class GetRandomPassword_Should
    {
        [Test]
        public void ReturnPasswordString_WithSpecifiedInConstantLength_WhenCalled()
        {
            var mockedRanodmProvider = new Mock<IRandomProvider>();
            var customPasswordGeneratorService = new CustomPasswordGeneratorService(mockedRanodmProvider.Object);
            var actualLengtht = customPasswordGeneratorService.GenerateRandomPassword().Length;

            mockedRanodmProvider.Setup(x => x.GetRandomNumber(0, customPasswordGeneratorService.GetPasswordLentgh - 1)).Returns(0);

            var expectedLenght = customPasswordGeneratorService.GetPasswordLentgh;

            Assert.AreEqual(expectedLenght, actualLengtht);
        }
    }
}
