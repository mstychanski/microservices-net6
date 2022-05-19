namespace AuthService.Domain
{
    public interface IAuthService
    {
        bool TryAuthorize(string username, string password, out User user);

        Task<(bool isValid, User user)> TryAuthorizeAsync(string username, string password);
    }
}