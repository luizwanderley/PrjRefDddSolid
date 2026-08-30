using CommonTestUtilities;
using PrjRefDddSolid.Application.UserCases.User.Register;
using PrjRefDddSolid.Exception;
using Shouldly;
using System.Diagnostics.CodeAnalysis;

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

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("                ")]
    [SuppressMessage("Usage", "xUnit1012:Null should only be used for nullable parameters", Justification = "<Intentional because is a unit test>")]
    public void Vaidate_ShoudldHaveError_WhenNameIsEmpty(string name)
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Name = name;

        var validator = new RegisterUserAccountValidator();
        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
            errors.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessageException.VALIDATION_NAME_REQUIRED));
        });

    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("                ")]
    [SuppressMessage("Usage", "xUnit1012:Null should only be used for nullable parameters", Justification = "<Intentional because is a unit test>")]
    public void Vaidate_ShoudldHaveError_WhenEmailIsEmpty(string email)
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Email = email;

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
            errors.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessageException.VALIDATION_EMAIL_REQUIRED));
        });

    }

    [Fact]
    public void Vaidate_ShoudldHaveError_WhenPasswordIsEmpty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Password = string.Empty;

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
            errors.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessageException.VALIDATION_PASSWORD_REQUIRED));
        });

    }
}
