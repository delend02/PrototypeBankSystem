using Microsoft.EntityFrameworkCore;
using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Persistence.DataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Credit> Credit { get; set; }
        public DbSet<ClientCard> ClientCard { get; set; }
        public DbSet<Deposit> Deposit { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var builder = new ConfigurationBuilder();
            //builder.AddJsonFile("settings.json");
            //var config = builder.Build();
            //string connection = config.GetConnectionString("DefaultConnectionMSSQLDatabase");
            optionsBuilder.UseSqlServer("Server =.\\SQLExpress; Database = PrototypeBankSystemDB; Trusted_Connection = True; MultipleActiveResultSets = true; User ID = root; pwd = root");
        }
    }
}
