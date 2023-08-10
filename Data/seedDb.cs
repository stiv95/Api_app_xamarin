using Estiven_API_Xamarin.Data.Models;
using Estiven_API_Xamarin.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace Estiven_API_Xamarin.Data
{
    public class SeedDb
    {
        private readonly Db_API_XamarinContext context;
        private readonly Random random;

        public SeedDb(Db_API_XamarinContext context)
        {
            this.context = context;
            random = new Random();
        }
        public async Task SeedAsync()
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.Clients.Any())
            {
                AddClient("First Client");
                AddClient("Second Client");
                AddClient("Third Client");
                await context.SaveChangesAsync();
            }

            if (!context.UserRoles.Any())
            {
                AddUserRole("Administrator", RoleType.SuperAdmin);
                AddUserRole("Staff", RoleType.Staff);
                AddUserRole("Guest", RoleType.Guest);
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                AddUser("AdminUser", "123", 1);
                AddUser("StaffUser", "123", 2);
                AddUser("GuestUser", "123", 3);
                await context.SaveChangesAsync();
            }

            await context.Database.MigrateAsync();
        }

        private void AddClient(string name)
        {
            context.Clients.Add(new Client
            {
                Name = name,
                Dna = random.Next(1000000, 1999999).ToString()
            });
        }

        private void AddUserRole(string roleName, RoleType roleType)
        {
            context.UserRoles.Add(new UserRole
            {
                Name = roleName,
                Type = roleType
            });
        }

        private void AddUser(string userId, string password, long userRoleId)
        {
            context.Users.Add(new User
            {
                UserName = userId,
                Password = password,
                RoleId = userRoleId
            });
        }
    }
}