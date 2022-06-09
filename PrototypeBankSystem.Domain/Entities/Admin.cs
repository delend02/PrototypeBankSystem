using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeBankSystem.Domain.Entities
{
    public class Admin
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AdminRole Role { get; set; }

        public enum AdminRole
        {
            Manager,
            Programmer,
            Analyst
        }
    }
}
