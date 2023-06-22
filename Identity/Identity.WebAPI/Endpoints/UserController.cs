using Identity.WebAPI.Model;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Identity.WebAPI.Controllers;

// Register +
// Get
// Confirm Email
// Reset Password
// Confirm reset password

[Route("api/users")]
[ApiController]
public class UserController : Controller
{
    private readonly UserManager<User> _userManager;

    public UserController(UserManager<User> userManager) 
        => _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));

    [HttpPut]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var user = request.Adapt<User>();

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return ValidationProblem(result.Errors);
        }

        return Ok();
    }

    private IActionResult ValidationProblem(IEnumerable<IdentityError> identityErrors)
    {
        var modelState = new ModelStateDictionary();

        foreach (var error in identityErrors)
        {
            modelState.AddModelError(error.Code, error.Description);
        }

        return ValidationProblem(modelState);
    }
}