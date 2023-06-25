using Identity.WebAPI.Model;
using Microsoft.AspNetCore.Identity;

namespace Identity.WebAPI;

public static class TestDataInitializer
{
    public static async void Initialize(UserManager<User> userManager)
    {
        await userManager.CreateAsync(
            new User()
            {
                Id = "9eadfc0a-bca1-44d5-b9b0-e73b1299fa58",
                Email = "dima@mail.com"
            },
            password: "qweR_1"
        );
    }
}