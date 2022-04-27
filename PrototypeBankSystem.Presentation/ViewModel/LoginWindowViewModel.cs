using System.ComponentModel;
using System.Windows.Input;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    internal class LoginWindowViewModel : ViewModel, INotifyPropertyChanged
    {
        public LoginWindowViewModel()
        {
            LoginToTheBank = new LamdaCommand(OnLoginToTheBank, CanLoginToTheBank);
            Exit = new LamdaCommand(OnExit, CanExit);
        }

        #region TextBox

        #endregion

        #region Button
        public ICommand LoginToTheBank { get; }

        private void OnLoginToTheBank(object p)
        {
            
        }

        private bool CanLoginToTheBank(object p) => true;

        public ICommand Exit { get; }

        private void OnExit(object p)
        {
            ExitProgramm();
        }

        private bool CanExit(object p) => true;
        #endregion

        private static void ExitProgramm()
        {
            var window = System.Windows.Application.Current.Windows[0];
            if (window != null)
                window.Close();
        }
    }
}
