using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrototypeBankSystem.Presentation.Notification
{
    internal class MessageBoxNotifi
    {
        public string Text { get; private set; }

        public MessageBoxNotifi(string text)
        {
            Text = text;
        }

        public void Error(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void Warning(string text)
        {
            MessageBox.Show(text, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void Information(string text)
        {
            MessageBox.Show(text, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private event Action<string> showNotify;



        public event Action<string> ShowNotify
        {
            add { showNotify += value; }
            remove { showNotify -= value; }
        }
    }
}
