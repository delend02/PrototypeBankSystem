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
            try
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile(@"C:\Users\Maksim\source\repos\PrototypeBankSystem\PrototypeBankSystem.Persistence\settings.json");
                var config = builder.Build();
                string connection = config.GetConnectionString("DefaultConnectionMSSQLDatabase");
                optionsBuilder.UseSqlServer(connection);
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
