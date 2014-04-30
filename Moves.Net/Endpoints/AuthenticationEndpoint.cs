using Moves.Net.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Moves.Net.Endpoints
{
    public class AuthenticationEndpoint : EndpointBase
    {
        public AuthenticationEndpoint(Credentials credentials) : base(credentials)
        { }

        public string CreateAuthorizationUrl(string[] scopes)
        {
            return string.Format("{0}authorize?response_type=code&client_id={1}&scope={2}",
                EndpointBase.MovesAuthenticationBaseUrl,
                this.Credentials.ClientId,                
                string.Join(" ", scopes)                
            );                     
        }

        public AccessTokenData ReceiveAccessToken(string authorizationToken, string redirectUri)
        {
            var request = CreateRequest(
                "access_token?grant_type=authorization_code&code={0}&client_id={1}&client_secret={2}&redirect_uri=" + redirectUri,
                authorizationToken,
                this.Credentials.ClientId,
                this.Credentials.ClientSecret
            );

            var response = Post(EndpointBase.MovesAuthenticationBaseUrl, request);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw MovesException.FromErrorResponse(response);
            }

            return DeserializeContent<AccessTokenData>(response);
        }

        public AccessTokenData RefreshAccessToken(string refreshToken)
        {
            var request = CreateRequest(
                "access_token?grant_type=refresh_token&refresh_token={0}&client_id={1}&client_secret={2}",
                refreshToken,
                this.Credentials.ClientId,
                this.Credentials.ClientSecret
            );

            var response = Post(EndpointBase.MovesAuthenticationBaseUrl, request);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw MovesException.FromErrorResponse(response);
            }

            return DeserializeContent<AccessTokenData>(response);
        }

        public AccessTokenValidation ValidateAccessToken(string accessToken)
        {
            var request = CreateRequest(
                "tokeninfo?access_token={0}",
                accessToken
            );

            var response = Get(EndpointBase.MovesAuthenticationBaseUrl, request);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw MovesException.FromErrorResponse(response);
            }

            return DeserializeContent<AccessTokenValidation>(response);
        }
    }
}
