using SchoolSystem.Web.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Web.Providers.Providers
{
    public class RandomProvider : IRandomProvider
    {
        private readonly Random random;

        public RandomProvider()
        {
            this.random = new Random();
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }
    }
}
