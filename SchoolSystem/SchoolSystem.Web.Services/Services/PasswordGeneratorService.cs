using Bytes2you.Validation;
using SchoolSystem.Web.Providers.Contracts;
using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Web.Services
{
    public class PasswordGeneratorService : IPasswordGeneratorService
    {
        private readonly IRandomProvider randomProvider;
        private readonly IList<char> characters;
        private const int passwordLength = 10;
        private const int StartSymbolCode = 48;
        private const int NumberOfLastValidSymbol = 122;
        public PasswordGeneratorService(IRandomProvider randomProvider)
        {
            Guard.WhenArgument(randomProvider, "randomProvider").IsNull().Throw();

            this.randomProvider = randomProvider;

            this.characters = Enumerable.Range(StartSymbolCode, NumberOfLastValidSymbol - StartSymbolCode).Select(c => (char)c).ToList();
        }

        public string GenerateRandomPassword()
        {
            var randomPassword = new StringBuilder();

            for (int i = 0; i < passwordLength; i++)
            {
                var index = this.randomProvider.GetRandomNumber(0, this.characters.Count - 1);
                randomPassword.Append(this.characters[index].ToString());
            }

            return randomPassword.ToString();
        }
    }
}
