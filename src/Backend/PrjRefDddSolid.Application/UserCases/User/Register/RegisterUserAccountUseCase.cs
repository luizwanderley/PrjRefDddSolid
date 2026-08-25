using FluentValidation.Results;
using Mapster;
using PrjRefDddSolid.Communication.Requests;
using PrjRefDddSolid.Communication.Responses;
using PrjRefDddSolid.Domain.Repositories;
using PrjRefDddSolid.Domain.Repositories.User;
using PrjRefDddSolid.Domain.Security.PasswordHashing;
using PrjRefDddSolid.Exception;
using PrjRefDddSolid.Exception.ExceptionsBase;

namespace PrjRefDddSolid.Application.UserCases.User.Register;

public class RegisterUserAccountUseCase : IRegisterUserAccountUseCase
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IUnitOfWork _initOfWork;

    public RegisterUserAccountUseCase(IPasswordHasher passwordHasher, IUserWriteOnlyRepository userWriteOnlyRepository, IUserReadOnlyRepository userReadOnlyRepository, IUnitOfWork initOfWork)
    {
        _passwordHasher = passwordHasher;
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _userReadOnlyRepository = userReadOnlyRepository;
        _initOfWork = initOfWork;

    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserAccountJson request)
    {
        await ValidateOnThrowOnFailures(request);

        var user = request.Adapt<Domain.Entities.User>();

        user.Password = _passwordHasher.HashPassword(user.Password);

        await _userWriteOnlyRepository.Add(user);

        await _initOfWork.Commit();

        return new ResponseRegisteredUserJson
        {
            Name = user.Name
        };
    }

    private async Task ValidateOnThrowOnFailures(RequestRegisterUserAccountJson request)
    {
        var validator = new RegisterUserAccountValidator();
        var result = validator.Validate(request);

        var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
        if (emailExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceMessageException.VALIDATION_EMAIL_ALREADY_EXIST));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
