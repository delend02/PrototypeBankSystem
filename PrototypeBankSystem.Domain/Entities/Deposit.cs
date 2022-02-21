﻿namespace PrototypeBankSystem.Domain.Entities
{
    public class Deposit
    {
        public double AmountOfDeposit { get; set; }
        public string RateType { get; set; }    
        public DateTime DepositStart { get; set; }
        public DateTime DepositStop { get; set; }
        public float InterestRate { get; set; }

        public Deposit(double amountOfDeposit, string rateType ,DateTime depositStart, DateTime depositStop, float interestRate)
        {
            AmountOfDeposit = amountOfDeposit;
            RateType = rateType;
            DepositStart = depositStart;
            DepositStop = depositStop;
            InterestRate = interestRate;
        }
    }
}