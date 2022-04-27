using PrototypeBankSystem.Application.HelpersMethodsSession;
using PrototypeBankSystem.Application.Models.Api;
using PrototypeBankSystem.Presentation.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    internal class LastActionViewModel : ViewModel, INotifyPropertyChanged
    {
        private readonly MainWindow _mainWindow = new();

        public LastActionViewModel()
        {
            ExitMain = new LamdaCommand(OnExitMain, CanExitMain);
        }

        #region ListView
        private ObservableCollection<string> _listViewAction = new();

        public ObservableCollection<string> ListViewAction
        {
            get => _listViewAction;
            set => Set(ref _listViewAction, value);
        }

        #endregion

        #region SelectedItem

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

        }
    }
}
