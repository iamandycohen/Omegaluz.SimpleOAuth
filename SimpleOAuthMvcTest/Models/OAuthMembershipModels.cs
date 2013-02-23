using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleOAuthMvcTest.Models
{

    public class MembershipContext : DbContext
    {
        public MembershipContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<OAuthMembership> OAuthMembership { get; set; }
        public DbSet<Membership> Membership { get; set; }

    }

    [Table("webpages_OAuthMembership")]
    public class OAuthMembership
    {
        [Key, Column(Order = 0)]
        public string Provider { get; set; }
        [Key, Column(Order = 1)]
        public string ProviderUserId { get; set; }
        public int UserId { get; set; }
    }

    [Table("webpages_Membership")]
    public class Membership
    {
        [Key]
        public int UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ConfirmationToken { get; set; }
        public bool? IsConfirmed { get; set; }
        public DateTime? LastPasswordFailuredate { get; set; }
        public int PasswordFailuresSinceLastSuccess { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordChangedDate { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordVerificationToken { get; set; }
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }
    }

}