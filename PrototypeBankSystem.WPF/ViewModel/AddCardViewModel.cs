using PrototypeBankSystem.WPF.HelpersMethodsSession;
using PrototypeBankSystem.BLL.Entities;
using PrototypeBankSystem.WPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PrototypeBankSystem.BLL.Services;

namespace PrototypeBankSystem.WPF.ViewModel
{
    internal class AddCardViewModel : ViewModel, INotifyPropertyChanged
    {
        private readonly MainWindow _mainWindow = new();

        public AddCardViewModel()
        {
            LoadDataClient();
            AddCard = new LamdaCommand(OnAddCard, CanAddCard);
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
            get => _selectedClient;
            set => Set(ref _selectedClient, value); 
        }
        #endregion

        #region TextBlock
        private string? _textNumberCard;

        public string TextNumberCard
        {
            get
            {
                _textNumberCard = "";
                Random random = new();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        _textNumberCard += random.Next(0, 10);
                    }
                    if (i == 3)
                        break;
                    _textNumberCard += "-";
                }
                return _textNumberCard;
            }
            set => Set(ref _textNumberCard, value);
            
        }

        private string? _textDateEnd;

        public string TextDateEnd
        {
            get => _textDateEnd = $"{DateTime.UtcNow.Month}/{DateTime.UtcNow.Year + 4}";
            set => Set(ref _textDateEnd, value);
        }
        #endregion

        #region Button

        public ICommand AddCard { get; }

        private async void OnAddCard(object p)
        {
            if (_textNumberCard != null && _selectedClient != null)
            {
                var clientCard = new ClientCard(_selectedClient.ID, _textNumberCard, 0);

                await ClientCardsServices.CreateAsync(clientCard);

                MessageBox.Show($"Карта успешно прикреплена к клиенту",
                                "Успешно",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information,
                                MessageBoxResult.OK);

                _mainWindow.TransitionWithClosureToMain();
            }
            else
            {
                MessageBox.Show($"Перед добавлением карты, выберите клиента",
                              "Предупреждение",
                              MessageBoxButton.OK,
                              MessageBoxImage.Warning,
                              MessageBoxResult.OK);
            }
        }

        private bool CanAddCard(object p) => true;

        public ICommand ExitMain { get; }

        private void OnExitMain(object p)
        {
            _mainWindow.TransitionWithClosureToMain();
        }

        private bool CanExitMain(object p) => true;
        #endregion

        private async void LoadDataClient()
        {
            ListViewClient = new ObservableCollection<Client>(await ClientServices.GetAllAsync());
        }
    }
}
