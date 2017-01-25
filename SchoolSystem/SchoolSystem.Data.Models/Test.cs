using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models
{
    public class Test : DbContext
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
