using Application.Features.Users.Dtos;

namespace WebApp.Helper;
public class UserSessionHelper : IUserSessionHelper
{
    private IHttpContextAccessor _httpContextAccessor;
    public UserSessionHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string FullName => GetUser() == null ? null : string.Format("{0} {1}", GetUser().FirstName, GetUser().LastName);
    public string Rol => GetUser() == null ? null : GetUser().Type.ToString();

    public UserDto GetUser()
    {
        return _httpContextAccessor.HttpContext.Session.GetObject<UserDto>("user");
    }

    public void SetUser(UserDto loginDTO)
    {
        _httpContextAccessor.HttpContext.Session.SetObject("user", loginDTO);
    }

    public void Clear()
    {
        _httpContextAccessor.HttpContext.Session.Clear();
    }

}