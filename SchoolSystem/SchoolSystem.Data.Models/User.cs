using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Models
{
    public class User : IdentityUser
    {
        private ICollection<Newsfeed> newsFeed;

        public User()
        {
            this.newsFeed = new HashSet<Newsfeed>();
        }

        public virtual Teacher Teacher { get; set; }

        [MinLength(4)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MinLength(4)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public string AvatarPictureUrl { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<Newsfeed> NewsFeed
        {
            get { return this.newsFeed; }

            set { this.newsFeed = value; }
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }

    }
}
