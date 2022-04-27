﻿using PrototypeBankSystem.Application.HelpersMethodsSession;
using PrototypeBankSystem.Application.Models.Api;
using PrototypeBankSystem.Domain.Entities;
using PrototypeBankSystem.Presentation.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    internal class LastActionViewModel : ViewModel, INotifyPropertyChanged
    {
        private readonly MainWindow _mainWindow = new();

        public LastActionViewModel()
        {
            LoadData();
            ExitMain = new LamdaCommand(OnExitMain, CanExitMain);
        }

        #region ListView
        private ObservableCollection<History> _listViewAction = new();

        public ObservableCollection<History> ListViewAction
        {
            get => _listViewAction;
            set => Set(ref _listViewAction, value);
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

        private async void LoadData()
        {
            var history = await ApiHistory.GetAllAsync();

            ListViewAction = new ObservableCollection<History>(history);
        }
    }
}
