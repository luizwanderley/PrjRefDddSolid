using CommonTestUtilities;
using PrjRefDddSolid.Application.UserCases.User.Register;
using PrjRefDddSolid.Exception;
using Shouldly;

namespace Validators.Tests.User.Register;

public class RegisterUserAccountValidatorTests
{
    [Fact]
    public void Success()
    {
        //AAA

        //Arrange
        var request = RequestRegisterUserAccountJsonBuilder.Build();

        //Act
        var validator = new RegisterUserAccountValidator();
        var result = validator.Validate(request);

        //Assert
        //Assert.True(result.IsValid);

        //Assert com biblioteca Shouldly
        result.IsValid.ShouldBeTrue();
    }

    [Fact]
    public void Vaidate_ShoudldHaveError_WhenNameIsEmpty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Name = string.Empty;

        var validator = new RegisterUserAccountValidator();
        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
            errors.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessageException.VALIDATION_NAME_REQUIRED));
        });

    }
}
