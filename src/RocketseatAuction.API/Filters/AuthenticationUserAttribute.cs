using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketseatAuction.API.Contracts;

namespace RocketseatAuction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private IUserRepository _repository;

    public AuthenticationUserAttribute(IUserRepository repository) => _repository = repository;

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authenticationToken = this.TokenOnRequest(context.HttpContext);

        if (authenticationToken.Length == 0)
        {
            context.Result = new UnauthorizedObjectResult("Invalid token");
        }

        var email = this.FromBase64String(authenticationToken);

        var exists = _repository.ExistsUserWithEmail(email);

        if (!exists)
        {
            context.Result = new UnauthorizedObjectResult("Invalid token");
        }
    }

    private string TokenOnRequest(HttpContext context)
    {
        var token = context.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(token))
        {
            return "";
        }

        return token["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
