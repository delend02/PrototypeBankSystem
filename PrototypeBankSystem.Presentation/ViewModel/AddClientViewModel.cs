using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using PrototypeBankSystem.Domain.Entities;
using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Presentation.View;
using System.Collections.Generic;
using PrototypeBankSystem.Persistence.DataBase;
using PrototypeBankSystem.Presentation.Notification;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    internal class AddClientViewModel : ViewModel, INotifyPropertyChanged
    {
        //private readonly IRepository<Client> _clientRepository;
        private readonly ClientRepository _clientRepository = new();
        public AddClientViewModel()
        {
            AddClient = new LamdaCommand(OnAddClient, CanAddClient);
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
            set 
            {
                Set(ref _textNumberCard, value); 
            }
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

        #region TextBox
        private string? _textFirstName;

        public string TextFirstName
        {
            get => _textFirstName ?? "";
            set => Set(ref _textFirstName, value);
        }

        private string? _textLastName;

        public string TextLastName
        {
            get => _textLastName ?? "";
            set => Set(ref _textLastName, value);
        }

        private string? _textSurName;

        public string TextSurName
        {
            get => _textSurName ?? "";
            set => Set(ref _textSurName, value);
        }

        private string _textAge;

        public string TextAge
        {
            get => _textAge;
            set {
                int a = 0;

                if (value == "0" ^ !value.All(char.IsDigit))
                {
                    return;
                }

                if (value != "")
                {
                    a = int.Parse(value);
                }

                if (a < 100)
                {
                    Set(ref _textAge, value);
                }
            }
        }

        private string? _textPhone;
        public string TextPhone
        {
            get => _textPhone ?? "";
            set => Set(ref _textPhone, value);
        }

        #endregion

        #region ComboBox
        private string? _enumerationsPrivilege;

        public string EnumerationsPrivilege
        {
            get => _enumerationsPrivilege ?? "";
            set => Set(ref _enumerationsPrivilege, value);
        }

        public ObservableCollection<string> BoxEnumerationsPrivilege { get; } = new ObservableCollection<string> {
            "V.I.P",
            "Юридическое лицо",
            "Физическое лицо"
        };
        #endregion

        #region Button
        public ICommand AddClient { get; }

        private async Task OnAddClient(object p)
        {
            var notifi = new MessageBoxNotifi();
            string text = null;

            if (_textFirstName == null || _textLastName == null || _textSurName == null || TextAge == null || _textPhone == null || _enumerationsPrivilege == null)
            {
                text = "Есть незаполенные поля, заполните и попробуйте снова";
                ShowNotifi += notifi.Error;
            }    
            else
            {
                _clientRepository.Create(new Client(_textFirstName, _textLastName, _textSurName, int.Parse(_textAge), _textPhone, _enumerationsPrivilege,
                    new CreditCard(_textNumberCard, $"{_textLastName} {_textFirstName}", DateTime.UtcNow, DateTime.UtcNow.AddYears(4))));

                text = "Пользователь успешно добавился в базу клиентов";
                ShowNotifi += notifi.Information;
                
                ShowMain();
                ExitProgramm();
            }


            ShowNotifi?.Invoke(text);
        }


        private bool CanAddClient(object p) => true;

        public ICommand ExitMain { get; }

        private async Task OnExitMain(object p)
        {
            ShowMain();
            ExitProgramm();
        }

        private bool CanExitMain(object p) => true;
        #endregion



        private static void ExitProgramm()
        {
            var window = System.Windows.Application.Current.Windows[0];
            if (window != null)
                window.Close();
        }

        private static void ShowMain()
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
        }
    }
}
