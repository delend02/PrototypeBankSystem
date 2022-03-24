using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PrototypeBankSystem.Application.HelpersMethodsSession;
using PrototypeBankSystem.Domain.Entities;
using PrototypeBankSystem.Persistence.DataBase;
using PrototypeBankSystem.Presentation.Services;
using PrototypeBankSystem.Presentation.View;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    internal class ClientManagementViewModel : ViewModel, INotifyPropertyChanged
    {


        //private readonly IRepository<Client> _clientRepository;
        private readonly ClientRepository _clientRepository = new();

        private readonly MainWindow _mainWindow = new();

        public ClientManagementViewModel()
        {
            RewindTime = new LamdaCommand(OnRewindTime, CanRewindTime);
            ExitMain = new LamdaCommand(OnExitMain, CanExitMain);
        }

        static ClientManagementViewModel()
        {
            _currentTime = DateTime.Now;
        }

        private static DateTime _currentTime;

        public DateTime CurrentTime
        {
            get => _currentTime;
            
            private set => Set(ref _currentTime, value);
        }


        private ObservableCollection<Client> _listViewClient = new();

        public ObservableCollection<Client> ListViewClient
        {
            get => _listViewClient;
            set => Set(ref _listViewClient, value);
        }
        #region SelectedItem
        private Client _selectedClient;

        public Client SelectedClient
        {
            get => _selectedClient;
            set => Set(ref _selectedClient, value);
        }
        #endregion
        #region Button
        public ICommand RewindTime { get; }

        private void OnRewindTime(object p)
        {
            CurrentTime = CurrentTime.AddDays(5);
            MessageService.SendMessage();
        }

        private bool CanRewindTime(object p) => true;

        public ICommand ExitMain { get; }

        private void OnExitMain(object p)
        {
            _mainWindow.TransitionWithClosureToMain();
        }

        private bool CanExitMain(object p) => true;
        #endregion

    }
}
