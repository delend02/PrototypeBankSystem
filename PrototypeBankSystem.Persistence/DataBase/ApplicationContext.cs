using Microsoft.EntityFrameworkCore;
using PrototypeBankSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Collections.Specialized;

namespace PrototypeBankSystem.Persistence.DataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Credit> Credit { get; set; }
        public DbSet<ClientCard> ClientCard { get; set; }
        public DbSet<Deposit> Deposit { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
