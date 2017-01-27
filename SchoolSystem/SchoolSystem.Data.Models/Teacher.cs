using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models
{
    public class Teacher
    {
        //private ICollection<User> users;

        //public Teacher()
        //{
        //    this.users = new HashSet<User>();
        //}


        public int Id { get; set; }

        public int UserId { get; set; }


        public virtual User User { get; set; }

        //public virtual ICollection<User> Users
        //{
        //    get { return this.users; }
        //    set { this.users = value; }
        //}


    }
}
