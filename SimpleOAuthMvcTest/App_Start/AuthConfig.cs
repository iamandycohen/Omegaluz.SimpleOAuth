using SimpleOAuth;
using SimpleOAuthMvcTest.Providers;

namespace SimpleOAuthMvcTest
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            //OAuthWebSecurity.RegisterGoogleClient();

            SimpleOAuthSecurity.SetProvider(new OAuthMembershipProxyProvider());

            SimpleOAuthSecurity.RegisterFacebookClient("558539204169705", "8178ad9b4e352f5a8c4349ec08136fd7");
            SimpleOAuthSecurity.RegisterTwitterClient("W6gy7E7YSg9dDAvhzGIl1A", "y7tFMtEAxQpjPbNTawoUaRxPFR1JkmU8LWqTMs");
            SimpleOAuthSecurity.RegisterLinkedInClient("v2ae4pcdrxu9", "30BQz5D1pPQBDwDw");
            SimpleOAuthSecurity.RegisterGoogleClient();
        }
    }


}
