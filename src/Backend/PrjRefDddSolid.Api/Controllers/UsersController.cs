using Microsoft.AspNetCore.Mvc;
using PrjRefDddSolid.Application.UserCases.User.Register;
using PrjRefDddSolid.Communication.Requests;
using PrjRefDddSolid.Communication.Responses;

namespace PrjRefDddSolid.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RequestRegisterUserAccountJson request, [FromServices] IRegisterUserAccountUseCase useCase)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }
}
