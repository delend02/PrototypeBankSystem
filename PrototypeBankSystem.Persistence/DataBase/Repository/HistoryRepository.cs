using Microsoft.EntityFrameworkCore;
using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Persistence.DataBase.Repository
{
    public class HistoryRepository
    {
        readonly ApplicationContext context;

        public HistoryRepository(ApplicationContext db)
        {
            context = db;
        }

        public async Task<IEnumerable<History>> GetAll()
        {
            return context.History.Take(15);
        }
    }
}
