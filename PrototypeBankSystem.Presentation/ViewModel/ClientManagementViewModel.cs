using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PrototypeBankSystem.Application.HelpersMethodsSession;
using PrototypeBankSystem.Domain.Entities;
using PrototypeBankSystem.Presentation.View;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    internal class ClientManagementViewModel : ViewModel, INotifyPropertyChanged
    {
        private readonly MainWindow _mainWindow = new();

        public ClientManagementViewModel()
        {
            ExitMain = new LamdaCommand(OnExitMain, CanExitMain);
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
        public ICommand ExitMain { get; }

        private void OnExitMain(object p)
        {
            _mainWindow.TransitionWithClosureToMain();
        }

        private bool CanExitMain(object p) => true;
        #endregion

    }
}
