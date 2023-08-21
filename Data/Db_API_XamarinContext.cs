using Microsoft.EntityFrameworkCore;
using Estiven_API_Xamarin.Data.Models;

namespace Estiven_API_Xamarin.Data
{
    public class Db_API_XamarinContext : DbContext
    {
        public Db_API_XamarinContext (DbContextOptions<Db_API_XamarinContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ListUser> ListUser { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            modelBuilder.Entity<UserRole>().ToTable(nameof(UserRole));
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<ListUser>().ToTable(nameof(ListUser));


            base.OnModelCreating(modelBuilder);
        }
    }
}
