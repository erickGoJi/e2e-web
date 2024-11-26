using e2e.Data;
using e2e.Model;

namespace e2e.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsFirstAttempt(string e)
        {
            throw new NotImplementedException();
        }
    }
}
