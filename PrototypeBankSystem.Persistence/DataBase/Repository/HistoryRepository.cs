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
            var his = context.History.OrderByDescending(x => x.ID);
            
            var a = his.Take(15);
            return a;
        }
    }
}
