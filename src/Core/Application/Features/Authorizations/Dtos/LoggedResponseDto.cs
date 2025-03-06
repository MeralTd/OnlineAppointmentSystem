using Security.JWT;

namespace Application.Features.Authorizations.Dtos;

public class LoggedResponseDto
{
    public AccessToken? AccessToken { get; set; }
    public LoggedHttpResponse ToHttpResponse() => new() { AccessToken = AccessToken };

    public class LoggedHttpResponse
    {
        public AccessToken? AccessToken { get; set; }
    }
}