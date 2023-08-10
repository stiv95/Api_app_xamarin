using Estiven_API_Xamarin.Data.Models;

namespace Estiven_API_Xamarin.API.Services
{
    public interface IAccountService
    {
        string GenerateJwtToken(User user);
    }
}
