using PrototypeBankSystem.Presentation.View;

namespace PrototypeBankSystem.Application.HelpersMethodsSession
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
