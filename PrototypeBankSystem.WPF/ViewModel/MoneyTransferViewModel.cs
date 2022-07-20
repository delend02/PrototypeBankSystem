using PrototypeBankSystem.WPF.HelpersMethodsSession;
using PrototypeBankSystem.BLL.Entities;
using PrototypeBankSystem.WPF.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using PrototypeBankSystem.API.ApiLayer.Api;

namespace PrototypeBankSystem.WPF.ViewModel
{
    internal class MoneyTransferViewModel : ViewModel, INotifyPropertyChanged
    {
        private readonly MainWindow _mainWindow = new();

        public MoneyTransferViewModel()
        {
            LoadDataClient();
            AcceptTransfer = new LamdaCommand(OnAcceptTransfer, CanAcceptTransfer);
            ExitMain = new LamdaCommand(OnExitMain, CanExitMain);
        }

        #region ComboBox
        private ObservableCollection<ClientCard> _comboBoxCardTo = new();

        public ObservableCollection<ClientCard> ComboBoxCardTo
        {
            get => _comboBoxCardTo;
            set => Set(ref _comboBoxCardTo, value);
        }

        private ObservableCollection<ClientCard> _comboBoxCardFrom = new();

        public ObservableCollection<ClientCard> ComboBoxCardFrom
        {
            get => _comboBoxCardFrom;
            set => Set(ref _comboBoxCardFrom, value);
        }
        #endregion

        #region SelectedItem
        private ClientCard _selectedCardTo;

        public ClientCard SelectedCardTo
        {
            get => _selectedCardTo;
            set => Set(ref _selectedCardTo, value);

        }

        private ClientCard _selectedCardFrom;

        public ClientCard SelectedCardFrom
        {
            get => _selectedCardFrom;
            set => Set(ref _selectedCardFrom, value);
        }
        #endregion

        #region ListView
        private ObservableCollection<Client> _listViewClient = new();

        public ObservableCollection<Client> ListViewClient
        {
            get => _listViewClient;
            set => Set(ref _listViewClient, value);
        }

        private ObservableCollection<Client> _listViewCard = new();

        public ObservableCollection<Client> ListViewCard
        {
            get => _listViewCard;
            set => Set(ref _listViewCard, value);
        }
        #endregion

        #region SelectedItem
        private Client _selectedClientFrom;

        public Client SelectedClientFrom
        {
            get => _selectedClientFrom;
            set
            {
                Set(ref _selectedClientFrom, value);
                ComboBoxCardFrom = _selectedClientFrom.ClientCard;
            }
        }

        private Client _selectedClientTo;

        public Client SelectedClientTo
        {
            get => _selectedClientTo;
            set
            {
                Set(ref _selectedClientTo, value);
                ComboBoxCardTo = _selectedClientTo.ClientCard;
            }
        }
        #endregion

        #region TextBox
        private string _sumOfTransfer;

        public string SumOfTransfer
        {
            get => _sumOfTransfer;
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

                if (1 <= a && a <= 1_000_000_000)
                {
                    Set(ref _sumOfTransfer, value);
                }
            }
        }
        #endregion

        #region Button
        public ICommand AcceptTransfer { get; }

        private async void OnAcceptTransfer(object p)
        {
            if (_selectedClientFrom == null || _selectedClientTo == null || _sumOfTransfer == null || _selectedCardTo == null || _selectedCardFrom == null)
                MessageBox.Show("Есть незаполненные/не выбранные поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            else if (SelectedCardFrom.Cash < double.Parse(_sumOfTransfer))
                MessageBox.Show("Невозможно выполнить перевод, недостаточно средств.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            else if (SelectedClientTo == SelectedClientFrom || SelectedCardFrom == SelectedCardTo)
                MessageBox.Show("Невозможно выполнить перевод самому себе", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            else
            {
                SelectedCardFrom.Cash -= int.Parse(_sumOfTransfer);
                SelectedCardTo.Cash += int.Parse(_sumOfTransfer);

                await ApiClientCards.UpdateAsync(SelectedCardTo);
                await ApiClientCards.UpdateAsync(SelectedCardFrom);
                // await _clientRepository.UpdateClientCard(SelectedCardFrom);
                // await _clientRepository.UpdateClientCard(SelectedCardTo);

                MessageBox.Show($"Перевод денег успешно прошел!",
                                "Успешно",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information,
                                MessageBoxResult.OK);

                _mainWindow.TransitionWithClosureToMain();
            }
        }

        private bool CanAcceptTransfer(object p) => true;

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

            foreach (var clientItem in client)
                foreach (var cardItem in card)
                    if (clientItem.ID == cardItem.ClientID)
                        clientItem.ClientCard.Add(cardItem);

            ListViewClient = client;
        }
    }
}
