using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PrototypeBankSystem.WPF.HelpersMethodsSession;
using PrototypeBankSystem.BLL.Entities;
using PrototypeBankSystem.WPF.View;
using PrototypeBankSystem.BLL.ApiLayer.Api;

namespace PrototypeBankSystem.WPF.ViewModel
{
    internal class ClientManagementViewModel : ViewModel, INotifyPropertyChanged
    {
        private readonly MainWindow _mainWindow = new();

        public ClientManagementViewModel()
        {
            LoadDataClient();
            ExitMain = new LamdaCommand(OnExitMain, CanExitMain);
            DeleteCard = new LamdaCommand(OnDeleteCard, CanDeleteCard);
            DeleteClient = new LamdaCommand(OnDeleteClient, CanDeleteClient);
            SaveAndExit = new LamdaCommand(OnSaveAndExit, CanSaveAndExit);
        }

        #region ComboBox
        private ObservableCollection<ClientCard> _comboBoxCard = new();

        public ObservableCollection<ClientCard> ComboBoxCard
        {
            get => _comboBoxCard;
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

        #region SelectedItem
        private Client _selectedClient;

        public Client SelectedClient
        {
            get => _selectedClient;
            set
            { 
                Set(ref _selectedClient, value);
                if (SelectedClient != null)
                    ComboBoxCard = new ObservableCollection<ClientCard>(_selectedClient.ClientCard);
            } 
        }

        private ClientCard _selectedCard;

        public ClientCard SelectedCard
        {
            get => _selectedCard;
            set => Set(ref _selectedCard, value);
        }
        #endregion

        #region Button
        public ICommand ExitMain { get; }

        private void OnExitMain(object p)
        {
            _mainWindow.TransitionWithClosureToMain();
        }

        private bool CanExitMain(object p) => true;

        public ICommand DeleteClient { get; }

        private async void OnDeleteClient(object p)
        {
            if (SelectedClient == null)
                MessageBox.Show("Для удаления, выберите клиента", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                await ApiClient.DeleteAsync(SelectedClient);
                ListViewClient.Remove(SelectedClient);
            }
        }

        private bool CanDeleteClient(object p) => true;

        public ICommand DeleteCard { get; }

        private async void OnDeleteCard(object p)
        {
            if (SelectedCard == null)
                MessageBox.Show("Для удаления, выберите карту", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                await ApiClientCards.DeleteAsync(SelectedCard);
                ComboBoxCard.Remove(SelectedCard);
            }
        }

        private bool CanDeleteCard(object p) => true;
        public ICommand SaveAndExit { get; }

        private async void OnSaveAndExit(object p)
        {
            foreach (var item in ListViewClient)
            {
                await ApiClient.UpdateAsync(item);
            }
            _mainWindow.TransitionWithClosureToMain();
        }

        private bool CanSaveAndExit(object p) => true;
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
