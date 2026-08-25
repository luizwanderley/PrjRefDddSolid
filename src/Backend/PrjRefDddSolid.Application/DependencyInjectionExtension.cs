using Microsoft.Extensions.DependencyInjection;
using PrjRefDddSolid.Application.UserCases.User.Register;

namespace PrjRefDddSolid.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterUserAccountUseCase, RegisterUserAccountUseCase>();
    }
}
