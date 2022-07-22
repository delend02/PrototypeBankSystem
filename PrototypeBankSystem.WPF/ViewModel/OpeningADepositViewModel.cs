using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using PrototypeBankSystem.BLL.Entities;
using PrototypeBankSystem.WPF.View;
using PrototypeBankSystem.WPF.HelpersMethodsSession;
using PrototypeBankSystem.BLL.Services;

namespace PrototypeBankSystem.WPF.ViewModel
{
    internal class OpeningADepositViewModel : ViewModel, INotifyPropertyChanged
    {

        private readonly MainWindow _mainWindow = new();

        public OpeningADepositViewModel()
        {
            LoadDataClient();
            OpenDeposit = new LamdaCommand(OnOpenDeposit, CanOpenDeposit);
            ExitMain = new LamdaCommand(OnExitMain, CanExitMain);
        }

        #region CheckBox
        private bool _checkCapitalization;

        public bool CheckCapitalization 
        { 
            get => _checkCapitalization; 
            set => Set(ref _checkCapitalization, value);
        }


        #endregion

        #region ComboBox
        private ObservableCollection<ClientCard> _comboBoxCard = new();

        public ObservableCollection<ClientCard> ComboBoxCard
        {
            get
            {
                return _comboBoxCard;
            }
            set => Set(ref _comboBoxCard, value);
        }
        #endregion

        #region ListView
        private ObservableCollection<Client> _listViewClient = new();

        public ObservableCollection<Client> ListViewClient
        {
            get => _listViewClient;
            set => Set(ref _listViewClient, value);
        }
        #endregion

        #region TextBlock
        private string? _textCreditHistory;

        public string TextCreditHistory
        {
            get => _textCreditHistory ?? "";
            set => Set(ref _textCreditHistory, value);
        }

        private string? _textPrivilege;

        public string TextPrivilege
        {
            get => _textPrivilege ?? "";
            set => Set(ref _textPrivilege, value);
        }

        private string? _textDepositRates;

        public string TextDepositRates
        {
            get => _textDepositRates ?? "";
            set => Set(ref _textDepositRates, value);
        }

        private string? _textDepositApproval;

        public string TextDepositApproval
        {
            get => _textDepositApproval ?? "";
            set => Set(ref _textDepositApproval, value);
        }
        #endregion

        #region SelectedItem
        private Client _selectedClient;

        public Client SelectedClient
        {
            get => _selectedClient;
            set 
            {
                TextDepositApproval = "";
                TextDepositRates = "";
                TextCreditHistory = "";
                TextPrivilege = "";

                Set(ref _selectedClient, value);
                if(_selectedClient != null)
                    ComboBoxCard = _selectedClient.ClientCard;
            } 
        }

        private ClientCard _selectedCard;

        public ClientCard SelectedCard
        {
            get
            {
                if (_selectedCard != null)
                {
                    List<bool> creditStory = new();
                    if (_selectedCard.Credits != null)
                        foreach (var item in _selectedCard.Credits)
                            creditStory.Add(item.RepaidLoan);

                    int goodStory = creditStory.Count(x => x == true);
                    int badStory = creditStory.Count(x => x == false);

                    string story = "Нулевая";
                    float percentStory = 1.5f;

                    if (goodStory > badStory) { story = "Хорошая"; percentStory = 3; }
                    else if (goodStory == 0 && badStory == 0) { story = "Нулевая"; percentStory = 1.5f; }
                    else if (goodStory < badStory) { story = "Плохая"; percentStory = 1; }

                    TextCreditHistory = story;

                    float percent = default;
                    if (_selectedClient.Privilege == "V.I.P")
                        percent = 1 + percentStory * 1.5f;
                    else if (_selectedClient.Privilege == "Юридическое лицо")
                        percent = 2 + percentStory * 1.5f;
                    else if (_selectedClient.Privilege == "Физическое лицо")
                        percent = 3 + percentStory * 1.5f;
                    TextDepositRates = $"{percent}%";
                }
                return _selectedCard;
            }
            set => Set(ref _selectedCard, value);
        }
        #endregion


        #region TextBox
        private string? _DepositTerm;

        public string TextDepositTerm
        {
            get => _DepositTerm ?? "";
            set
            {
                int a = 0;

                if (value == "0" ^ !value.All(char.IsDigit))
                {
                    return;
                }

                if (value != "")
                {
                    a = int.Parse(value);
                }

                if (1 <= a && a <= 12)
                {
                    Set(ref _DepositTerm, value);
                }
            }
        }

        private string? _textSumDeposit;

        public string TextSumDeposit
        {
            get => _textSumDeposit ?? "";
            set
            {
                int a = 0;

                if (value == "0" ^ !value.All(char.IsDigit))
                {
                    return;
                }

                if (value != "")
                {
                    a = int.Parse(value);
                }

                if (100_000 <= a && a <= 1_000_000_000)
                {
                    Set(ref _textSumDeposit, value);
                }
            }
        }
        #endregion

        #region Button
        public ICommand OpenDeposit { get; }

        private async void OnOpenDeposit(object p)
        {
            if (_textSumDeposit == null || _DepositTerm == null || SelectedClient == null)
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            else if (SelectedCard.Cash < int.Parse(_textSumDeposit))
                MessageBox.Show("Недостаточно средств для открытия вклада", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            else
            {
                var dateCreate = DateTime.UtcNow;
                var rate = TextDepositRates.Split('%');

                var deposit = new Deposit(double.Parse(_textSumDeposit), TextPrivilege, dateCreate, dateCreate.AddMonths(int.Parse(TextDepositTerm)), float.Parse(rate[0]), SelectedCard.ID);

                await DepositServices.CreateAsync(deposit);

                double finalPayment;
                if (_checkCapitalization)
                {
                    var sumOfDeposit = double.Parse(_textSumDeposit);
                    for (int i = 0; i < int.Parse(_DepositTerm); i++)
                    {
                        double nextMounthPay = sumOfDeposit * (double.Parse(rate[0]) / 100) / int.Parse(_DepositTerm);
                        sumOfDeposit += nextMounthPay;
                    }
                    finalPayment = sumOfDeposit - double.Parse(_textSumDeposit);
                }
                else
                    finalPayment = double.Parse(_textSumDeposit) * (double.Parse(rate[0]) / 100);

                finalPayment = Math.Round(finalPayment, 2);

                SelectedCard.Cash += (int)finalPayment;

                await ClientCardsServices.UpdateAsync(SelectedCard);


                var capitalization = _checkCapitalization ? "есть" : "нет";

                MessageBox.Show($"Клиенту был одобрен и открыт вклад!" +
                    $"\nСумма: {_textSumDeposit} рублей" +
                    $"\nCтавка: {_textDepositRates}" +
                    $"\nНа срок: {_DepositTerm} месяца" +
                    $"\nКапитализация: {capitalization}" +
                    $"\nКлиенту будет в плюсе на: {finalPayment} рублей",
                                "Успешно",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information,
                                MessageBoxResult.OK);

                _mainWindow.TransitionWithClosureToMain();
            }

        }

        private bool CanOpenDeposit(object p) => true;

        public ICommand ExitMain { get; }

        private void OnExitMain(object p)
        {
            _mainWindow.TransitionWithClosureToMain();
        }

        private bool CanExitMain(object p) => true;
        #endregion

        private async void LoadDataClient()
        {
            var card = new ObservableCollection<ClientCard>(await ClientCardsServices.GetAllAsync());

            var client = new ObservableCollection<Client>(await ClientServices.GetAllAsync());

            var credit = new ObservableCollection<Credit>(await CreditServices.GetAllAsync());

            foreach (var itemClient in client)
            {
                foreach (var itemCard in card)
                {
                    foreach (var itemCredit in credit)
                    {
                        if (itemCard.ID == itemCredit.ClientCardID)
                            itemCard.Credits.Add(itemCredit);
                    }
                    if (itemClient.ID == itemCard.ClientID)
                        itemClient.ClientCard.Add(itemCard);
                }
            }

            ListViewClient = client;
        }
    }
}
