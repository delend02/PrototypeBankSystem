using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;
using PrototypeBankSystem.Persistence.DataBase;
using PrototypeBankSystem.Presentation;
using PrototypeBankSystem.Presentation.View;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    internal class ClientManagementViewModel : ViewModel, INotifyPropertyChanged
    {
        //private readonly IRepository<Client> _clientRepository;
        private readonly ClientRepository _clientRepository = new();
        public ClientManagementViewModel()
        {
            _clientRepository.GetAll();
            _listViewClient = (ObservableCollection<Client>)_clientRepository.GetAll();
            RewindTime = new LamdaCommand(OnRewindTime, CanRewindTime);
            ExitMain = new LamdaCommand(OnExitMain, CanExitMain);
            SendSMS = new LamdaCommand(OnSendSMS, CanSendSMS);
            NotSendSMS = new LamdaCommand(OnNotSendSMS, CanNotSendSMS);

        }

        static ClientManagementViewModel()
        {
            _currentTime = DateTime.Now;
        }

        private static DateTime _currentTime;

        public DateTime CurrentTime
        {
            get => _currentTime;
            
            set => Set(ref _currentTime, value);
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

        private async Task OnRewindTime(object p)
        {
            CurrentTime = CurrentTime.AddDays(5);
        }

        private bool CanRewindTime(object p) => true;

        public ICommand ExitMain { get; }

        private async Task OnExitMain(object p)
        {
            ShowMain();
            ExitProgramm();
        }

        private bool CanExitMain(object p) => true;

        public ICommand SendSMS { get; }

        private bool _CanCheck = false;

        private async Task OnSendSMS(object p)
        {
            _CanCheck = true;
        }

        private bool CanSendSMS(object p) => !_CanCheck;

        public ICommand NotSendSMS { get; }

        private async Task OnNotSendSMS(object p)
        {
            _CanCheck = false;
        }

        private bool CanNotSendSMS(object p) => _CanCheck;
        #endregion

        private void ExitProgramm()
        {
            var window = System.Windows.Application.Current.Windows[0];
            if (window != null)
                window.Close();
        }

        private void ShowMain()
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
        }

    }
}
