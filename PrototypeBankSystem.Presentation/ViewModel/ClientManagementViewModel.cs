﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;
using PrototypeBankSystem.Presentation;
using PrototypeBankSystem.Presentation.View;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    internal class ClientManagementViewModel : ViewModel, INotifyPropertyChanged
    {
        private readonly IRepository<ClientDTO> _clientRepository;
        public ClientManagementViewModel()
        {
            _listViewClient = (ObservableCollection<ClientDTO>)_clientRepository.GetAll();
            Save = new LamdaCommand(OnSave, CanSave);
            ExitMain = new LamdaCommand(OnExitMain, CanExitMain);
        }

        private ObservableCollection<ClientDTO> _listViewClient = new();

        public ObservableCollection<ClientDTO> ListViewClient
        {
            get => _listViewClient;
            set => Set(ref _listViewClient, value);
        }

        #region Button
        public ICommand Save { get; }

        private async Task OnSave(object p)
        {
            ShowMain();
            ExitProgramm();
        }

        private bool CanSave(object p) => true;

        public ICommand ExitMain { get; }

        private async Task OnExitMain(object p)
        {
            ShowMain();
            ExitProgramm();
        }

        private bool CanExitMain(object p) => true;
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
