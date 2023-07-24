using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<Estiven_API_Xamarin.Data.Models.Client> Clients { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            base.OnModelCreating(modelBuilder);
        }
    }
}
