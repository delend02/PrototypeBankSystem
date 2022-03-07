﻿using System.Windows.Input;
using System.ComponentModel;
using System.Threading.Tasks;
using PrototypeBankSystem.Presentation.View;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    internal class MainWindowViewModel : ViewModel, INotifyPropertyChanged
    {

        public MainWindowViewModel()
        {
            AddClientButton = new LamdaCommand(OnAddClient, CanAddClient);
            TransferMoneyButton = new LamdaCommand(OnTransferMoney, CanTransferMoney);
            InvestmentButton = new LamdaCommand(OnInvestment, CanInvestment);
            GiveCreditButton = new LamdaCommand(OnGiveCredit, CanGiveCredit);
            ListClient = new LamdaCommand(OnListClient, CanListClient);
        }
        public ICommand ListClient { get; }

        private void OnListClient(object p)
        {
            ManagmentClient managment = new();
            managment.Show();
            ExitProgramm();
        }

        private bool CanListClient(object p) => true;

        public ICommand AddClientButton { get; }
        
        private void OnAddClient(object p)
        {
            
            AddClient addClient = new();
            addClient.Show();
            ExitProgramm();
        }

        private bool CanAddClient(object p) => true;

        public ICommand TransferMoneyButton { get; }

        private void OnTransferMoney(object p)
        {
            MoneyTransfer moneyTransfer = new();
            moneyTransfer.Show();
            ExitProgramm();
        }

        private bool CanTransferMoney(object p) => true;

        public ICommand InvestmentButton { get; }

        private void OnInvestment(object p)
        {
            OpeningADeposit openingADeposit = new();
            openingADeposit.Show();
            ExitProgramm();
        }

        private bool CanInvestment(object p) => true; 

        public ICommand GiveCreditButton { get; }

        private void OnGiveCredit(object p)
        {
            IssuanceOfCredit issuanceOfCredit = new();
            issuanceOfCredit.Show();
            ExitProgramm();
        }

        private bool CanGiveCredit(object p) => true;

        private static void ExitProgramm()
        {
            var window = System.Windows.Application.Current.Windows[0];
            if (window != null)
                window.Close();
        }
    }
}
