using Estiven_API_Xamarin.API.Services;
using Estiven_API_Xamarin.Data;
using Estiven_API_Xamarin.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Estiven_API_Xamarin.API.Services
{
    public class UserService : IUserService
    {

        private readonly Db_API_XamarinContext _context;


        public UserService(Db_API_XamarinContext context)
        {
            _context = context;
        }

        public async Task<User>? GetUserAsync(string username, string password)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(user => user.UserName == username && user.Password == password);

            return user;
        }
    }
}
