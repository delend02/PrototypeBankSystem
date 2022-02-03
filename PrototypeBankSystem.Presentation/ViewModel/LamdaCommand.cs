﻿using System;
using System.Threading.Tasks;

namespace PrototypeBankSystem.Presentation.ViewModel
{
    internal class LamdaCommand : Command
    {

        private readonly Func<object, Task> _Execute;

        private readonly Func<object, bool> _CanExecute;



        public LamdaCommand(Func<object, Task> Execute, Func<object, bool>? CanExecute = null) {

            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));

            _CanExecute = CanExecute ?? throw new ArgumentNullException(nameof(CanExecute));


        }


        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;


        public override void Execute(object parameter) => _Execute(parameter);
        
    }
}
