using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using PrototypeBankSystem.Domain.Entities;
using PrototypeBankSystem.Presentation.View;
using System.Diagnostics;
using PrototypeBankSystem.Application.HelpersMethodsSession;
using PrototypeBankSystem.Application.Models.Api;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    internal class IssuanceOfCreditViewModel : ViewModel, INotifyPropertyChanged
    {

        private readonly MainWindow _mainWindow = new();

        public IssuanceOfCreditViewModel()
        {
            LoadDataClient();
            TakeCredit = new LamdaCommand(OnTakeCredit, CanTakeCredit);
            ExitMain = new LamdaCommand(OnExitMain, CanExitMain);
        }

        #region ListView
        private ObservableCollection<Client> _listViewClient = new();

        public ObservableCollection<Client> ListViewClient
        { 
            get => _listViewClient;
            set => Set(ref _listViewClient, value); 
        }

        #endregion

        #region ComboBox
        private ObservableCollection<ClientCard> _comboBoxCard = new();

        public ObservableCollection<ClientCard> ComboBoxCard
        {
            get => _comboBoxCard;
            set => Set(ref _comboBoxCard, value);
        }
        #endregion

        #region SelectedItem
        private Client _selectedClient;

        public Client SelectedClient 
        {
            get => _selectedClient;
            set 
            {
                TextCreditHistory = "";
                LoanRates = "";
                LoanApproval = "";

                Set(ref _selectedClient, value); 
                if(SelectedClient != null)
                    ComboBoxCard = new ObservableCollection<ClientCard>(_selectedClient.ClientCard);
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

                    if (goodStory > badStory) { story = "Хорошая"; percentStory = 0; }
                    else if (goodStory == 0 && badStory == 0) { story = "Нулевая"; percentStory = 1.5f; }
                    else if (goodStory < badStory) { story = "Плохая"; percentStory = 3; }

                    TextCreditHistory = story;

                    float percent = default;
                    if (_selectedClient.Privilege == "V.I.P")
                        percent = 1 + percentStory * 1.5f;
                    else if (_selectedClient.Privilege == "Юридическое лицо")
                        percent = 2 + percentStory * 1.5f;
                    else if (_selectedClient.Privilege == "Физическое лицо")
                        percent = 3 + percentStory * 1.5f;
                    LoanRates = $"{percent}%";
                }
                return _selectedCard;
            }
            set => Set(ref _selectedCard, value);
        }
        #endregion

        #region TextBlock
        private string? _textCreditHistory;

        public string TextCreditHistory
        {
            get => _textCreditHistory ?? "";
            set => Set(ref _textCreditHistory, value);
        }

        private string? _loanRates;

        public string? LoanRates
        {
            get => _loanRates;
            set => Set(ref _loanRates, value);
        }

        private string? _loanApproval;

        public string LoanApproval
        {
            get => _loanApproval ?? "";
            set => Set(ref _loanApproval, value);
        }
        #endregion

        #region TextBox
        private string? _creditTerm;

        public string TextCreditTerm
        {
            get => _creditTerm ?? "";
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

                if (3 <= a && a <= 120)
                {
                    Set(ref _creditTerm, value);
                }
            }
        }

        private string? _textSumCredit;

        public string TextSumCredit
        {
            get => _textSumCredit ?? "";
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

                if (a >= 5000)
                {
                    Set(ref _textSumCredit, value);
                }
            }
        }
        #endregion

        #region Button
        public ICommand TakeCredit { get; }

        private async void OnTakeCredit(object p)
        {
            if (_textSumCredit == null || _creditTerm == null || SelectedClient == null || SelectedCard == null)
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            else
            {
                var dateCreate = DateTime.Now;
                var rate = LoanRates.Split('%');

                _selectedCard.Cash += int.Parse(TextSumCredit);

                await ApiClientCards.UpdateAsync(_selectedCard);
                //await _clientRepository.UpdateClientCard(_selectedCard);

                var credit = new Credit(_selectedCard.ID, float.Parse(TextSumCredit), dateCreate, dateCreate.AddMonths(int.Parse(TextCreditTerm)), float.Parse(rate[0]));

                await ApiCredit.CreateAsync(credit);
                //await _clientRepository.CreateCredit(new Credit(_selectedCard.ID, float.Parse(TextSumCredit), dateCreate, dateCreate.AddMonths(int.Parse(TextCreditTerm)), float.Parse(rate[0])));

                //double s = Math.Round((double.Parse(TextSumCredit) * float.Parse(rate[0])) / (1 - (1 / Math.Pow((1 + float.Parse(rate[0])), int.Parse(TextCreditTerm)))), 2);
                double endingCredit = Math.Round(double.Parse(TextSumCredit) + (double.Parse(TextSumCredit) * float.Parse(rate[0]) / 100), 2);
                double monthlyPayment = Math.Round(endingCredit / int.Parse(TextCreditTerm), 2);

                MessageBox.Show($"Клиенту был одобрен и выдан кредит!\nСумма: {_textSumCredit} рублей" +
                    $"\nCтавка: {_loanRates}" +
                    $"\nНа срок: {_creditTerm} месяца" +
                                $"\nЕжемесячная выплата: {monthlyPayment}" +
                                $"\nПо окончанию кредита клиент должен: {endingCredit}",
                                "Успешно",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information,
                                MessageBoxResult.OK);

                _mainWindow.TransitionWithClosureToMain();
            }
        }

        private bool CanTakeCredit(object p) => true;

        public ICommand ExitMain { get; }

        private void OnExitMain(object p)
        {
            _mainWindow.TransitionWithClosureToMain();
        }

        private bool CanExitMain(object p) => true;
        #endregion

        private async void LoadDataClient()
        {
            var card = new ObservableCollection<ClientCard>(await ApiClientCards.GetAllAsync());

            var client = new ObservableCollection<Client>(await ApiClient.GetAllAsync());

            var credit = new ObservableCollection<Credit>(await ApiCredit.GetAllAsync());

            foreach (var itemClient in client)
            {
                foreach(var itemCard in card)
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
