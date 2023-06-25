using Core.Domain.Users;
using Core.Domain.Exceptions;
using System.Net;

namespace Core.Infrastructure.Domain.Users;

public sealed class HttpUserProvider : IUserProvider
{
    private readonly HttpUserProviderSettings _settings;
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpUserProvider(HttpUserProviderSettings settings, IHttpClientFactory httpClientFactory)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }

    public async Task<User> GetAsync(string userId)
    {
        var httpClient = _httpClientFactory.CreateClient();
        
        var response = await httpClient.GetAsync($"{_settings.Url}/api/users/{userId}");

        switch (response.StatusCode)
        {
            case HttpStatusCode.NotFound:
                throw new NotFoundException($"User with id {userId} not found");

            case HttpStatusCode.BadRequest:
                throw new ValidationException($"Invalid user id");
        }

        response.EnsureSuccessStatusCode();

        return new User(userId);
    }
}