﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using PrototypeBankSystem.Domain.Entities;
using PrototypeBankSystem.Presentation;
using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Presentation.View;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    internal class IssuanceOfCreditViewModel : ViewModel, INotifyPropertyChanged
    {
        private readonly IRepository<Client> _clientRepository;

        public IssuanceOfCreditViewModel()
        {
            _listViewClient = (ObservableCollection<Client>)_clientRepository.GetAll();
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

        #region SelectedItem
        private Client _selectedClient;

        public Client SelectedClient 
        {
            get
            {
                if (_selectedClient != null)
                {
                    List<bool> creditStory = new();
                    if (_selectedClient.ClientCard.CreditHistory != null)
                        foreach (var item in _selectedClient.ClientCard.CreditHistory)
                            creditStory.Add(item.RepaidLoan);

                    int goodStory = creditStory.Count(x => x == true);
                    int badStory = creditStory.Count(x => x == false);

                    string story = "Нулевая";
                    float percentStory = 1.5f;

                    if (goodStory > badStory) { story = "Хорошая"; percentStory = 0; }
                    else if (goodStory == 0 &&  badStory == 0) { story = "Нулевая";  percentStory = 1.5f; }
                    else if (goodStory < badStory) {  story = "Плохая";  percentStory = 3; }

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
                return _selectedClient;
            }  
            set => Set(ref _selectedClient, value); 
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

        private async Task OnTakeCredit(object p)
        {
            if (_textSumCredit == null || _creditTerm == null || SelectedClient == null)
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            else
            {
                var dateCreate = DateTime.UtcNow;
                var rate = LoanRates.Split('%');
                
                int index = ListViewClient.IndexOf(SelectedClient);
            
                ListViewClient[index].ClientCard.CreditHistory.Add
                    (new Credit(double.Parse(TextSumCredit), dateCreate, dateCreate.AddMonths(int.Parse(TextCreditTerm)), float.Parse(rate[0])));

                ListViewClient[index].ClientCard.Cash += double.Parse(TextSumCredit);

                double endingCredit = Math.Round(double.Parse(TextSumCredit) + (double.Parse(TextSumCredit) * float.Parse(rate[0]) / 100), 2);
                double monthlyPayment = Math.Round(endingCredit / int.Parse(TextCreditTerm), 2);

                _clientRepository.Save(ListViewClient);

                MessageBox.Show($"Клиенту был одобрен и выдан кредит!\nСумма: {_textSumCredit} рублей" +
                    $"\nCтавка: {_loanRates}" +
                    $"\nНа срок: {_creditTerm} месяца" +
                    $"\nЕжемесячная выплата: {monthlyPayment}" +
                    $"\nПо окончанию кредита клиент должен: {endingCredit}",
                                "Успешно",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information, 
                                MessageBoxResult.OK);
                ShowMain();
                ExitProgramm();
            }
        }

        private bool CanTakeCredit(object p) => true;

        public ICommand ExitMain { get; }

        private async Task OnExitMain(object p)
        {
            ShowMain();
            ExitProgramm();
        }

        private bool CanExitMain(object p) => true;
        #endregion

        private static void ExitProgramm()
        {
            var window = System.Windows.Application.Current.Windows[0];
            if (window != null)
                window.Close();
        }

        private static void ShowMain()
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
        }


        
    }
}
