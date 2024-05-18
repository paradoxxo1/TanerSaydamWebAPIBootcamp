using AuthenticationAndAuthorization.WebAPI.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace AuthenticationAndAuthorization.WebAPI.Auth
{
    public class ApiKeyAuthShemeOptions : AuthenticationSchemeOptions
    {
        public string ApiKey { get; set; } = "MySecretSecretKey";
    }
}

public class ApiKeyAuthHandler : AuthenticationHandler<ApiKeyAuthShemeOptions>
{
    private string apiKey;
    public ApiKeyAuthHandler(
        IOptionsMonitor<ApiKeyAuthShemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock) : base(options, logger, encoder, clock)
    {
        apiKey = options.CurrentValue.ApiKey;
    }
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return Task.FromResult(AuthenticateResult.Fail("Invalid Api Key"));
        }
        var header = Request.Headers[HeaderNames.Authorization].ToString();
        if (header != "MySecretSecretKey")
        {
            return Task.FromResult(AuthenticateResult.Fail("Invalid Api Key"));
        }
        var claimsIdentity = new ClaimsIdentity(null, apiKey);
        var ticket = new AuthenticationTicket(new ClaimsPrincipal(), "MyAuthSheme");
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}
