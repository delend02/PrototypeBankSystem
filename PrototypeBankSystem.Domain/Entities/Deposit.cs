﻿using System.Text.Json.Serialization;

namespace PrototypeBankSystem.Domain.Entities
{
    public class Deposit
    {
        public int ID { get; set; }
        public double AmountOfDeposit { get; set; }
        public string RateType { get; set; }    
        public DateTime DepositStart { get; set; }
        public DateTime DepositStop { get; set; }
        public double InterestRate { get; set; }
        public int ClientCardID { get; set; }

        public Deposit(double amountOfDeposit, string rateType ,DateTime depositStart, DateTime depositStop, double interestRate)
        {
            AmountOfDeposit = amountOfDeposit;
            RateType = rateType;
            DepositStart = depositStart;
            DepositStop = depositStop;
            InterestRate = interestRate;
        }
    }
}
