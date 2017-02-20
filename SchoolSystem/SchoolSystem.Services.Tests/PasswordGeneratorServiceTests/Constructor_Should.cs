using Moq;
using NUnit.Framework;
using SchoolSystem.Services.Tests.PasswordGeneratorServiceTests.Mocks;
using SchoolSystem.Web.Providers.Contracts;
using SchoolSystem.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Services.Tests.PasswordGeneratorServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithMessageContaining_RandomProvider_WhenRandomProviderIsNull()
        {
            Assert.That(
                () => new PasswordGeneratorService(null),
                Throws.ArgumentNullException.With.Message.Contain("randomProvider"));
        }

        [Test]
        public void DoesNotThrow_WhenAllArgumentsAreValid()
        {
            var mockedRandomProvider = new Mock<IRandomProvider>();

            Assert.DoesNotThrow(() => new PasswordGeneratorService(mockedRandomProvider.Object));
        }

        [Test]
        public void InitizalizeCharactersFromAsciiTableCorrectly_WhenTheServiceIsCreated()
        {
            var mockedRanodmProvider = new Mock<IRandomProvider>();

            var customPasswordGeneratorService = new CustomPasswordGeneratorService(mockedRanodmProvider.Object);
            var expectedCharacters = 
                Enumerable.Range(
                    customPasswordGeneratorService.GetStartSymbolCode, 
                    customPasswordGeneratorService.GetNumberOfLastValidSymbol - customPasswordGeneratorService.GetStartSymbolCode)
                    .Select(c => (char)c).ToList();


            CollectionAssert.AreEqual(expectedCharacters, customPasswordGeneratorService.GetCharacters);
        }
    }
}
