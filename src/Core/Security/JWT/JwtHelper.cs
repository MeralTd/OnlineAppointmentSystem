using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Security.JWT;

public class JwtHelper : ITokenHelper
{
    private IConfiguration Configuration { get; }
    private readonly TokenOptions _tokenOptions;
    private DateTime _accessTokenExpiration;

    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;
        const string configurationSection = "TokenOptions";
        _tokenOptions = Configuration.GetSection(configurationSection).Get<TokenOptions>() ??
                        throw new NullReferenceException(
                            $"\"{configurationSection}\" section cannot found in configuration.");
    }

    public AccessToken CreateToken(UserEntity user, IList<OperationClaimEntity> operationClaims)
    {

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));

        // Signing credentials oluşturuluyor
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Token expiration (geçerlilik süresi)
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);



        // JWT token oluşturuluyor
        var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);


        // Token yazma
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);

        return new AccessToken { Token = token, Expiration = _accessTokenExpiration };
    }


    private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, UserEntity user, SigningCredentials signingCredentials, IList<OperationClaimEntity> operationClaims)
    {
        JwtSecurityToken jwt = new(tokenOptions.Issuer, tokenOptions.Audience, expires: _accessTokenExpiration,
            notBefore: DateTime.Now, claims: SetClaims(user, operationClaims), signingCredentials: signingCredentials);
        return jwt;
    }

    private IEnumerable<Claim> SetClaims(UserEntity user, IList<OperationClaimEntity> operationClaims)
    {
        List<Claim> claims = new();
        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claims.Add(new Claim(ClaimTypes.Email, user.Email));
        claims.Add(new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"));
        claims.AddRange(operationClaims.Select(operationClaim => new Claim(ClaimTypes.Role, operationClaim.Name)));
        return claims;
    }

    private static string RandomRefreshToken()
    {
        var numberByte = new byte[32];
        using var random = RandomNumberGenerator.Create();
        random.GetBytes(numberByte);
        return Convert.ToBase64String(numberByte);
    }
}