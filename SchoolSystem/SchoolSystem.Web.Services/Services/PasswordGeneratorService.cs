using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bytes2you.Validation;
using SchoolSystem.Web.Providers.Contracts;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.Web.Services
{
    public class PasswordGeneratorService : IPasswordGeneratorService
    {
        protected const int PasswordLength = 10;
        protected const int StartSymbolCode = 48;
        protected const int NumberOfLastValidSymbol = 122;

        protected readonly IList<char> Characters;
        private readonly IRandomProvider randomProvider;

        public PasswordGeneratorService(IRandomProvider randomProvider)
        {
            Guard.WhenArgument(randomProvider, "randomProvider").IsNull().Throw();

            this.randomProvider = randomProvider;

            this.Characters = Enumerable.Range(StartSymbolCode, NumberOfLastValidSymbol - StartSymbolCode).Select(c => (char)c).ToList();
        }

        public string GenerateRandomPassword()
        {
            var randomPassword = new StringBuilder();

            for (int i = 0; i < PasswordLength; i++)
            {
                var index = this.randomProvider.GetRandomNumber(0, this.Characters.Count - 1);
                randomPassword.Append(this.Characters[index].ToString());
            }

            return randomPassword.ToString();
        }
    }
}
