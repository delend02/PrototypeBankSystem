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

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile(@"appsettings.json");
                var config = builder.Build();
                var section = config.GetSection("ConnectionString");
                var connectionDB = section.GetSection("DefaultConnectionMSSQLDatabase").Value;
                optionsBuilder.UseSqlServer(connectionDB);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Connection DB done!");
            }
            
        }
    }
}
