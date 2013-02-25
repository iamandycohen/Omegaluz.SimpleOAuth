using Omegaluz.SimpleOAuth;
using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.WebPages;
using WebMatrix.WebData;

namespace Example.Providers
{

    public class OAuthMembershipProxyProvider : OAuthMembershipProvider
    {

        #region OAuthMembershipProvider

        public override string GetUserNameFromId(object userId)
        {
            using (var users = new UsersContext())
            {
                var user = users.UserProfiles
                    .FirstOrDefault(e => (object)e.UserId == userId);

                return user != null ? user.UserName : null;
            }
        }

        public override object GetUserIdFromOAuth(string provider, string providerUserId)
        {
            object userID = null;

            using (var membership = new MembershipContext())
            {
                var oauthuser = membership.OAuthMembership
                    .FirstOrDefault(e => e.Provider == provider && e.ProviderUserId == providerUserId);

                if (oauthuser != null)
                {
                    userID = oauthuser.UserId;
                }
            }

            return userID;
        }

        public override void CreateOrUpdateOAuthAccount(string provider, string providerUserId, string userName)
        {
            if (userName.IsEmpty())
            {
                throw new MembershipCreateUserException(MembershipCreateStatus.ProviderError);
            }

            int userId = (int)GetUserId(userName);

            if (userId == -1)
            {
                throw new MembershipCreateUserException(MembershipCreateStatus.InvalidUserName);
            }

            var oldUserId = GetUserIdFromOAuth(provider, providerUserId);

            using (var db = new MembershipContext())
            {
                if (oldUserId == null || (oldUserId != null && (int)oldUserId == -1))
                {
                    // account doesn't exist. create a new one.
                    var membership = new OAuthMembership
                    {
                        Provider = provider,
                        ProviderUserId = providerUserId,
                        UserId = userId
                    };

                    try
                    {
                        db.OAuthMembership.Add(membership);
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        throw new MembershipCreateUserException(MembershipCreateStatus.ProviderError);
                    }
                }
                else
                {
                    // account already exists. update it
                    try
                    {
                        var membership = db.OAuthMembership
                            .First(e => e.Provider.ToUpper() == provider.ToUpper() && e.ProviderUserId.ToUpper() == providerUserId.ToUpper());

                        membership.UserId = userId;
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        throw new MembershipCreateUserException(MembershipCreateStatus.ProviderError);
                    }
                }
            }
        }

        public override bool HasLocalAccount(object userId)
        {
            using (var db = new MembershipContext())
            {
                var membership = db.Membership
                    .FirstOrDefault(e => e.UserId == (int)userId);

                return membership != null;
            }
        }

        public override void DeleteOAuthAccount(string provider, string providerUserId)
        {
            using (var db = new MembershipContext())
            {
                // delete account
                try
                {
                    var account = db.OAuthMembership
                        .First(e => e.Provider.ToUpper() == provider.ToUpper() && e.ProviderUserId.ToUpper() == providerUserId.ToUpper());

                    db.OAuthMembership.Remove(account);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw new MembershipCreateUserException(MembershipCreateStatus.ProviderError);
                }
            }
        }

        public override ICollection<OAuthAccount> GetAccountsForUser(string userName)
        {
            int userId = (int)GetUserId(userName);

            if (userId != -1)
            {
                using (var db = new MembershipContext())
                {
                    var oauthMemberships = db.OAuthMembership
                        .Where(e => e.UserId == userId);

                    return oauthMemberships
                        .ToList()
                        .Select(e => new OAuthAccount(e.Provider, e.ProviderUserId))
                        .ToList();
                }
            }

            return new OAuthAccount[0];
        }

        public override string CreateAccount(string userName, string password, bool requireConfirmationToken = false)
        {
            return WebSecurity.CreateAccount(userName, password, requireConfirmationToken);
        }

        #endregion

        public object GetUserId(string userName)
        {
            using (var db = new UsersContext())
            {
                var result = db.UserProfiles
                    .FirstOrDefault(e => e.UserName.ToUpper() == userName.ToUpper());

                if (result != null)
                {
                    return result.UserId;
                }

                return -1;
            }
        }

    }
}