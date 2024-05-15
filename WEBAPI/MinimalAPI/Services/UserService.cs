using MinimalAPI.Services;

public sealed class UserService : IUserService
{
    public async Task CreateUserAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
    }
}
