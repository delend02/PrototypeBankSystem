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

    }
}
