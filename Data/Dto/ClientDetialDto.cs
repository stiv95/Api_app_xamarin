using Estiven_API_Xamarin.Data.Models;

namespace Estiven_API_Xamarin.API.Data.Dto
{
    public class ClientDetailDto : Client
    {
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public double LifeExpectancy { get; set; }
    }
}
