using FluentValidation;
using PrjRefDddSolid.Communication.Requests;
using PrjRefDddSolid.Domain.Extensions;
using PrjRefDddSolid.Exception;

namespace PrjRefDddSolid.Application.UserCases.User.Register;

public class RegisterUserAccountValidator : AbstractValidator<RequestRegisterUserAccountJson>
{
    public RegisterUserAccountValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessageException.VALIDATION_NAME_REQUIRED);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessageException.VALIDATION_EMAIL_REQUIRED);
        RuleFor(user => user.Password).NotEmpty().WithMessage(ResourceMessageException.VALIDATION_PASSWORD_REQUIRED);
        When(user => user.Email.IsNotEmpty(), () =>
        {
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessageException.VALIDATION_EMAIL_INVALID);
        });
    }
}
