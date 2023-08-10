using Estiven_API_Xamarin.Data.Models;

namespace Estiven_API_Xamarin.API.Services
{
    public interface IUserService
    {
        Task<User>? GetUserAsync(string username, string password);
    }
}

