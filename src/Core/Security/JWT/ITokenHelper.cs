using Domain.Entities;

namespace Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(UserEntity user, IList<OperationClaimEntity> operationClaims);

}