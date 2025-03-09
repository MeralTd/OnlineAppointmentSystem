using Application.Features.Users.Dtos;

namespace WebApp.Helper;
public interface IUserSessionHelper
{
    public string FullName { get; }
    public string Rol { get; }

    UserDto GetUser();
    void SetUser(UserDto loginDTO);
    void Clear();
}