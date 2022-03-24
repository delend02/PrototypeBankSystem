using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeBankSystem.Application.DTO
{
    public class ClientCardInfoDTO
    {
        public Guid ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public string NumberPhone { get; set; }
        public string Privilege { get; set; }
        public string NumberCard { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Cash { get; set; }
    }
}
