using PrototypeBankSystem.BLL.Entities;
using PrototypeBankSystem.WPF.View;
using System;
using System.Collections.ObjectModel;

namespace PrototypeBankSystem.WPF.HelpersMethodsSession
{
    internal static class ProgramOperation
    {
        public static void TransitionWithClosureToMain(this MainWindow session)
        {
            var window = System.Windows.Application.Current.Windows[0];
            if (window != null)
                window.Close();

            session.Show();
        }
    }
}
