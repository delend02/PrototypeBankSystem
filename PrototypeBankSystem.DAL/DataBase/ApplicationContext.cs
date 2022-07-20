using Microsoft.EntityFrameworkCore;
using PrototypeBankSystem.BLL.Entities;

namespace PrototypeBankSystem.DAL.DataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Credit> Credit { get; set; }
        public DbSet<ClientCard> ClientCard { get; set; }
        public DbSet<Deposit> Deposit { get; set; }
        public DbSet<History> History { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
