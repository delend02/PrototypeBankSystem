using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeBankSystem.Persistence.DataBase
{
    public class ClientRepository : IRepository<Client>
    {
        public void Create(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Client entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<Client> ts)
        {
            throw new NotImplementedException();
        }

        public void Update(Client entity, Client entityOld)
        {
            throw new NotImplementedException();
        }
    }
}
