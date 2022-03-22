using PrototypeBankSystem.Application.HelpersMethodsSession;
using PrototypeBankSystem.Domain.Entities;
using PrototypeBankSystem.Persistence.DataBase;
using PrototypeBankSystem.Presentation.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    internal class AddCardViewModel : ViewModel, INotifyPropertyChanged
    {

        private readonly ClientRepository _clientRepository = new();

        private readonly MainWindow _mainWindow = new();

        public AddCardViewModel()
        {
            AddCard = new LamdaCommand(OnAddCard, CanAddCard);
            ExitMain = new LamdaCommand(OnExitMain, CanExitMain);
        }

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
            get
            {
                var mounth = DateTime.UtcNow.Month;
                var year = DateTime.UtcNow.Year + 4;
                _textDateEnd = $"{mounth}/{year}";
                return _textDateEnd;
            }
            set => Set(ref _textDateEnd, value);
        }
        #endregion

        public ICommand AddCard { get; }

        private async void OnAddCard(object p)
        {
           
            //_ = _clientRepository.CreateCard(new CreditCard(client.ID, _textNumberCard, $"{_textLastName} {_textFirstName}"));
                  

            MessageBox.Show($"Клиент успешно внесен в базу",
                            "Успешно",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information,
                            MessageBoxResult.OK);
            _mainWindow.TransitionWithClosureToMain();
           
           
        }

        private bool CanAddCard(object p) => true;

        public ICommand ExitMain { get; }

        private void OnExitMain(object p)
        {
            _mainWindow.TransitionWithClosureToMain();
        }

        private bool CanExitMain(object p) => true;
    }
}
