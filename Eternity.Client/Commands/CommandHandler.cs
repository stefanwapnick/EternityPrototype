using System;
using System.Windows.Input;

namespace Eternity.Client.Commands
{
    public class CommandHandler : ICommand
    {
        private readonly Action<object> _action;

        private readonly Predicate<object> _canExecute;

        public event EventHandler CanExecuteChanged;


        public CommandHandler(Action<object> action) : this(action, obj => true)
        {
        }

        public CommandHandler(Action<object> action, Predicate<object> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}