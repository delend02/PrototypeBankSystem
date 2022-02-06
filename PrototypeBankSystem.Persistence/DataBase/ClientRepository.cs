using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeBankSystem.Persistence.DataBase
{
    public class ClientRepository : IRepository<ClientDTO>
    {
        public void Create(ClientDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ClientDTO entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<ClientDTO> ts)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientDTO entity, ClientDTO entityOld)
        {
            throw new NotImplementedException();
        }
    }
}
