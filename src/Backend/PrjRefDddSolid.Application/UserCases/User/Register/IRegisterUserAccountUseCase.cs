using PrjRefDddSolid.Communication.Requests;
using PrjRefDddSolid.Communication.Responses;

namespace PrjRefDddSolid.Application.UserCases.User.Register;

public interface IRegisterUserAccountUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserAccountJson request);
}
