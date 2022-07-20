using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using PrototypeBankSystem.BLL.Entities;
using PrototypeBankSystem.WPF.View;
using PrototypeBankSystem.WPF.HelpersMethodsSession;
using PrototypeBankSystem.API.ApiLayer.Api;

namespace PrototypeBankSystem.WPF.ViewModel
{
    internal class AddClientViewModel : ViewModel, INotifyPropertyChanged
    {
        private readonly MainWindow _mainWindow = new();

        public AddClientViewModel()
        {
            AddClient = new LamdaCommand(OnAddClient, CanAddClient);
            ExitMain = new LamdaCommand(OnExitMain, CanExitMain);
        }

        #region CheckBox

        private bool _generateCard;

        public bool GenerateCard
        { 
            get => _generateCard;
            set => Set(ref _generateCard, value); 
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
            get => _textFirstName;
            set => Set(ref _textFirstName, value);
        }

        private string? _textLastName;

        public string TextLastName
        {
            get => _textLastName;
            set => Set(ref _textLastName, value);
        }

        private string? _textSurName;

        public string TextSurName
        {
            get => _textSurName;
            set => Set(ref _textSurName, value);
        }

        private string? _textAge;

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
            get => _textPhone;
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

        private async void OnAddClient(object p)
        {
            try
            {
                if (_textFirstName == null || _textLastName == null || _textSurName == null || TextAge == null || _textPhone == null || _enumerationsPrivilege == null)
                    throw new ArgumentNullException();
                else
                {
                    var client = new Client(_textFirstName, _textLastName, _textSurName, byte.Parse(_textAge), _textPhone, _enumerationsPrivilege);

                    await ApiClient.CreateAsync(client);
                    
                    if (_generateCard)
                    {
                        var clientcard = new ClientCard(client.ID, _textNumberCard, 0);
                        await ApiClientCards.CreateAsync(clientcard);
                    }

                    MessageBox.Show($"Клиент успешно внесен в базу",
                                    "Успешно",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information,
                                    MessageBoxResult.OK);
                    _mainWindow.TransitionWithClosureToMain();
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Есть незаполненные поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
            
        }

        private bool CanAddClient(object p) => true;

        public ICommand ExitMain { get; }

        private void OnExitMain(object p)
        {
            _mainWindow.TransitionWithClosureToMain();
        }

        private bool CanExitMain(object p) => true;
        #endregion
    }
}
