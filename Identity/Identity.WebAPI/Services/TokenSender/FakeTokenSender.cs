using Identity.WebAPI.Model;

namespace Identity.WebAPI.Services.TokenSender;

public class FakeTokenSender : ITokenSender
{
    public async Task SendForChangePasswordConfirmation(User user, string token)
        => await File.WriteAllTextAsync("ConfirmPasswordToken.txt", token);

    public async Task SendForEmailConfirmation(User user, string token)
        => await File.WriteAllTextAsync("ConfirmEmailToken.txt", token);
}