using Omegaluz.SimpleOAuth;
using Example.Properties;
using Example.Providers;

namespace Example
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

            SimpleOAuthSecurity.RegisterFacebookClient(Settings.Default.FacebookAppId, Settings.Default.FacebookAppSecret);
            SimpleOAuthSecurity.RegisterTwitterClient(Settings.Default.TwitterConsumerKey, Settings.Default.TwitterConsumerSecret);
            SimpleOAuthSecurity.RegisterLinkedInClient(Settings.Default.LinkedInConsumerKey, Settings.Default.LinkedInConsumerSecret);
            SimpleOAuthSecurity.RegisterGoogleClient();
        }
    }


}
