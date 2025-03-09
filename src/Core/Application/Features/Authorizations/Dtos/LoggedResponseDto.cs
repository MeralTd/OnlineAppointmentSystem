using Application.Features.Users.Dtos;
using Security.JWT;

namespace Application.Features.Authorizations.Dtos;

public class LoggedResponseDto
{
    public AccessToken? AccessToken { get; set; }
    public LoggedHttpResponse ToHttpResponse() => new() { AccessToken = AccessToken };
    public UserDto? User { get; set; }

    public class LoggedHttpResponse
    {
        public AccessToken? AccessToken { get; set; }
    }
}