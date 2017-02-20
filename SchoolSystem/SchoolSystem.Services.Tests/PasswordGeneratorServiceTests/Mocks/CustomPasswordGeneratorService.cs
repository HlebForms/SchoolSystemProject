using System.Collections.Generic;
using SchoolSystem.Web.Services;
using SchoolSystem.Web.Providers.Contracts;

namespace SchoolSystem.Services.Tests.PasswordGeneratorServiceTests.Mocks
{
    public class CustomPasswordGeneratorService : PasswordGeneratorService
    {
        public CustomPasswordGeneratorService(IRandomProvider randomProvider)
            : base(randomProvider)
        {
        }

        public IList<char> GetCharacters
        {
            get { return base.Characters; }
        }

        public int GetPasswordLentgh
        {
            get { return PasswordLength; }
        }

        public int GetStartSymbolCode
        {
            get { return StartSymbolCode; }
        }

        public int GetNumberOfLastValidSymbol
        {
            get { return NumberOfLastValidSymbol; }
        }
    }
}
