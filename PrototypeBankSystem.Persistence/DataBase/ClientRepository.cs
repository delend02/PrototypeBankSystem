using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;
using System.Collections.ObjectModel;

namespace PrototypeBankSystem.Persistence.DataBase
{
    public class ClientRepository : IRepository<Client>
    {
        private static ObservableCollection<Client> _client = new();

        public void Create(Client entity)
        {
            _client.Add(entity);
        }

        public void Delete(Client entity)
        {
            _client.Remove(entity);
        }

        public IEnumerable<Client> GetAll()
        {
            return _client;
        }

        public void Save(IEnumerable<Client> ts)
        {
            _client = (ObservableCollection<Client>)ts;
        }

        public void Update(Client entity, Client entityOld)
        {
            throw new NotImplementedException();
        }
    }
}
