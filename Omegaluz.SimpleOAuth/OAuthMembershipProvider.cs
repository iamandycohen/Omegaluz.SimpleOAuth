using DotNetOpenAuth.AspNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omegaluz.SimpleOAuth
{
    public abstract class OAuthMembershipProvider : IOpenAuthDataProvider
    {

        /// <summary>
        /// Deletes the OAuth and OpenID account with the specified provider name and provider user id.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="providerUserId">The provider user id.</param>
        public virtual void DeleteOAuthAccount(string provider, string providerUserId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new OAuth account with the specified data or update an existing one if it already exists.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="providerUserId">The provider userid.</param>
        /// <param name="userName">The username.</param>
        public virtual void CreateOrUpdateOAuthAccount(string provider, string providerUserId, string userName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the id of the user with the specified provider name and provider user id.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="providerUserId">The provider user id.</param>
        /// <returns></returns>
        public virtual object GetUserIdFromOAuth(string provider, string providerUserId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the username of a user with the given id
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        public virtual string GetUserNameFromId(object userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether there exists a local account (as opposed to OAuth account) with the specified userId.
        /// </summary>
        /// <param name="userId">The user id to check for local account.</param>
        /// <returns>
        ///   <c>true</c> if there is a local account with the specified user id]; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool HasLocalAccount(object userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the OAuth token secret from the specified OAuth token.
        /// </summary>
        /// <param name="token">The token from which to retrieve secret.</param>
        /// <returns>The token secret of the specified token</returns>
        public virtual string GetOAuthTokenSecret(string token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stores the specified token and secret into database.
        /// </summary>
        /// <param name="requestToken">The token.</param>
        /// <param name="requestTokenSecret">The secret.</param>
        public virtual void StoreOAuthRequestToken(string requestToken, string requestTokenSecret)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Replaces the request token with access token and secret in the database.
        /// </summary>
        /// <param name="requestToken">The request token.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="accessTokenSecret">The access token secret.</param>
        public virtual void ReplaceOAuthRequestTokenWithAccessToken(string requestToken, string accessToken, string accessTokenSecret)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the OAuth token from the backing store from the database.
        /// </summary>
        /// <param name="token">The token to be deleted.</param>
        public virtual void DeleteOAuthToken(string token)
        {
            throw new NotImplementedException();
        }

        public virtual string GetUserNameFromOpenAuth(string openAuthProvider, string openAuthId)
        {
            object userId = GetUserIdFromOAuth(openAuthProvider, openAuthId);

            if (userId == null || (userId is int && ((int)userId) == -1))
            {
                return null;
            }

            return GetUserNameFromId(userId);
        }

        /// <summary>
        /// Gets all OAuth accounts associated with the specified username
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public abstract ICollection<OAuthAccount> GetAccountsForUser(string userName);

    }
}
