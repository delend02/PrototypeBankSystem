﻿namespace PrototypeBankSystem.Domain.Entities
{
    public class CreditCard
    {
        public string Number { get; set; }
        public Guid ClientID { get; set; }
        public string CarrierName { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Cash { get; set; }
        public bool Blocked { get; set; }

        public CreditCard(Guid clientID, string number, string carrierName)
        {
            ClientID = clientID;
            Number = number;
            CarrierName = carrierName;
        }
    }
}
