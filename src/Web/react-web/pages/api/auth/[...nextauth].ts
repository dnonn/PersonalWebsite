import NextAuth from "next-auth";
import Providers from "next-auth/providers";

export default NextAuth({
  providers: [
    Providers.IdentityServer4({
      id: process.env.IdentityServer4_ID,
      name: process.env.IdentityServer4_NAME,
      scope: process.env.IdentityServer4_SCOPE,
      domain: process.env.IdentityServer4_DOMAIN,
      clientId: process.env.IdentityServer4_CLIENT_ID,
      clientSecret: process.env.IdentityServer4_CLIENT_SECRET,
    }),
  ],
  callbacks: {
    async jwt(token, user, account, profile, isNewUser) {
      // Initial sign in
      console.log(account);
      if (account && user) {
        return {
          accessToken: account.accessToken,
          user,
        };
      }

      // Return previous token if the access token has not expired yet
      return token;
    },
    async session(session, token) {
      session.user = token
      return session;
    },
  },
});