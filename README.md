## General
Moves.Net contains a client proxy which can be used to access the [Moves](http://www.moves-app.com/) [API](https://dev.moves-app.com/docs/api).

## Usage

Download the NuGet package: https://www.nuget.org/packages/Moves.Net/

You need to obtain an authorization token before using the Moves.Net client. Once you have an authorization token, you can use the client to receive an access token. See [authentication](https://dev.moves-app.com/docs/authentication) on how to obtain an authorization token.

Receive an access token:
<pre>
	var client = new MovesClient(clientId, clientSecret);
	var accessToken = client.ReceiveAccessToken(authorizationToken, redirectUri);
</pre>
<em>Important: make sure the redirectUri contains the *exact* same value you used to [obtain your authorization token](https://dev.moves-app.com/docs/authentication#authorization)<em>

Use the client to access the API:
<pre>
	var client = new MovesClient(clientId, clientSecret, accessToken);
	var result = client.Places.GetByDay(2014, 5, 5);
</pre>