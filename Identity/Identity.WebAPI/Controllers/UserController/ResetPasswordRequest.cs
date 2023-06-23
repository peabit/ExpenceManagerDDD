namespace Identity.WebAPI.Controllers.UserController;

public sealed record ResetPasswordRequest(string Token, string Email, string NewPassword);