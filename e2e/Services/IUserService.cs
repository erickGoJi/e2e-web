namespace e2e.Services
{
    public interface IUserService
    {
        Task<bool> IsFirstAttempt(string email);
    }
}
