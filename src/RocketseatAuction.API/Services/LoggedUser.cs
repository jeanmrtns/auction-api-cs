using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _httpContextAcessor;
    private readonly IUserRepository _repository;

    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository)
    {
        _httpContextAcessor = httpContext;
        _repository = repository;
    }

    public User User()
    {
        var currentUserToken = TokenOnRequest();
        var email = FromBase64String(currentUserToken);

        return _repository.FindFirstByEmail(email);
    }

    private string TokenOnRequest()
    {
        var token = this._httpContextAcessor.HttpContext!.Request.Headers.Authorization.ToString(); ;

        return token["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
