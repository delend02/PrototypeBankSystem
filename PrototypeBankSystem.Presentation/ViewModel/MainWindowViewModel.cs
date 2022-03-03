using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using System.Threading.Tasks;
using PrototypeBankSystem.Presentation.View;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    
    // Открывать вклады, с капитализацией и без
    // 100 12%
    // 12 ме - 112
    // 100 12%
    // 101 12%
    // 102.01 12%

    //     100
    // 1   101
    // 2   102,01
    // 3   103,0301
    // 4   104,060401
    // 5   105,101005
    // 6   106,1520151
    // 7   107,2135352
    // 8   108,2856706
    // 9   109,3685273
    // 10  110,4622125
    // 11  111,5668347
    // 12  112,682503

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

        private async Task OnListClient(object p)
        {
            ManagmentClient managment = new();
            managment.Show();
            ExitProgramm();
        }

        private bool CanListClient(object p) => true;

        public ICommand AddClientButton { get; }
        
        private async Task OnAddClient(object p)
        {
            
            AddClient addClient = new();
            addClient.Show();
            ExitProgramm();
        }

        private bool CanAddClient(object p) => true;

        public ICommand TransferMoneyButton { get; }

        private async Task OnTransferMoney(object p)
        {
            MoneyTransfer moneyTransfer = new();
            moneyTransfer.Show();
            ExitProgramm();
        }

        private bool CanTransferMoney(object p) => true;

        public ICommand InvestmentButton { get; }

        private async Task OnInvestment(object p)
        {
            OpeningADeposit openingADeposit = new();
            openingADeposit.Show();
            ExitProgramm();
        }

        private bool CanInvestment(object p) => true; 

        public ICommand GiveCreditButton { get; }

        private async Task OnGiveCredit(object p)
        {
            IssuanceOfCredit issuanceOfCredit = new();
            issuanceOfCredit.Show();
            ExitProgramm();
        }

        private bool CanGiveCredit(object p) => true;

        private void ExitProgramm()
        {
            var window = System.Windows.Application.Current.Windows[0];
            if (window != null)
                window.Close();
        }
    }
}
