using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using PrototypeBankSystem.Domain.Entities;
using PrototypeBankSystem.Presentation.View;
using PrototypeBankSystem.Persistence.DataBase;
using PrototypeBankSystem.Application.HelpersMethodsSession;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    internal class MoneyTransferViewModel : ViewModel, INotifyPropertyChanged
    {
        //private readonly IRepository<Client> _clientRepository;
        private readonly ClientRepository _clientRepository = new();

        private readonly MainWindow _mainWindow = new();

        public MoneyTransferViewModel()
        {
            //_listViewClient = (ObservableCollection<Client>)_clientRepository.GetAll();
            AcceptTransfer = new LamdaCommand(OnAcceptTransfer, CanAcceptTransfer);
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
        private Client _selectedClientFrom;

        public Client SelectedClientFrom
        {
            get => _selectedClientFrom;
            set => Set(ref _selectedClientFrom, value);
        }

        private Client _selectedClientTo;

        public Client SelectedClientTo
        {
            get => _selectedClientTo;
            set => Set(ref _selectedClientTo, value);
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

        private void OnAcceptTransfer(object p)
        {
            //if (_selectedClientFrom == null || _selectedClientTo == null || _sumOfTransfer == null)
            //    MessageBox.Show("Есть незаполненные/не выбранные поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            //else if (SelectedClientFrom.ClientCard.Cash < double.Parse(_sumOfTransfer))
            //    MessageBox.Show("Невозможно выполнить перевод, недостаточно средств.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            //else if (SelectedClientTo == SelectedClientFrom)
            //    MessageBox.Show("Невозможно выполнить перевод самому себе", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            //else
            //{
            //    var index = ListViewClient.IndexOf(_selectedClientFrom);
            //    ListViewClient[index].ClientCard.Cash -= double.Parse(_sumOfTransfer);

            //    index = ListViewClient.IndexOf(_selectedClientTo);
            //    ListViewClient[index].ClientCard.Cash += double.Parse(_sumOfTransfer);
            //    _clientRepository.Save(ListViewClient);

            //    MessageBox.Show($"Перевод денег успешно прошел!",
            //                    "Успешно",
            //                    MessageBoxButton.OK,
            //                    MessageBoxImage.Information,
            //                    MessageBoxResult.OK);

            //    _mainWindow.TransitionWithClosureToMain();
            //}

        }



        private bool CanAcceptTransfer(object p) => true;

        public ICommand ExitMain { get; }

        private void OnExitMain(object p)
        {
            _mainWindow.TransitionWithClosureToMain();
        }

        private bool CanExitMain(object p) => true;
        #endregion


    }
}
