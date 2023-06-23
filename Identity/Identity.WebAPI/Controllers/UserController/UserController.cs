using Identity.WebAPI.Model;
using Identity.WebAPI.Services.TokenSender;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Identity.WebAPI.Controllers.UserController;

// Register +
// Get +
// Confirm Email +
// Reset Password 
// Confirm reset password

[Route("api/users/")]
[ApiController]
public class UserController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly ProblemDetailsFactory _problemDetailsFactory;
    private readonly ITokenSender _tokenSender;

    public UserController(UserManager<User> userManager, ProblemDetailsFactory problemDetailsFactory, ITokenSender tokenSender)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _problemDetailsFactory = problemDetailsFactory ?? throw new ArgumentNullException(nameof(problemDetailsFactory));
        _tokenSender = tokenSender ?? throw new ArgumentNullException(nameof(tokenSender));
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var user = new User() { UserName = request.UserName };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return IdentityProblem(result.Errors);
        }

        var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        await _tokenSender.SendForEmailConfirmation(user, confirmEmailToken);

        return Ok();
    }

    [HttpPut("{userId}/email/confirm/{token}")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
        {
            return NotFoundProblem($"User with id {userId} not found");
        }

        // Replace nessesary for correct work in Swagger
        var result = await _userManager.ConfirmEmailAsync(user, token.Replace("%2F", "/"));

        if (!result.Succeeded)
        {
            return IdentityProblem(result.Errors);
        }

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get(string userId, bool confirmed = false)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null || ( confirmed && await _userManager.IsEmailConfirmedAsync(user)))
        {
            return NotFoundProblem($"User with id {userId} not found");
        }

        return Ok(new UserDto(user.Id, user.UserName, user.Email));    
    }

    private IActionResult IdentityProblem(IEnumerable<IdentityError> identityErrors)
    {
        var modelState = new ModelStateDictionary();

        foreach (var error in identityErrors)
        {
            modelState.AddModelError(error.Code, error.Description);
        }

        return ValidationProblem(modelState);
    }

    private IActionResult NotFoundProblem(string detail)
    {
        var problemDetails = 
            _problemDetailsFactory.CreateProblemDetails(HttpContext, statusCode: StatusCodes.Status404NotFound, detail: detail);

        return NotFound(problemDetails);
    }
}