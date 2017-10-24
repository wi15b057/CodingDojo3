using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodingDojo3.Command
{
    public class RelayCommand : ICommand
    {

        Action execute;
        Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;

        }
        bool ICommand.CanExecute(object parameter)
        {
            return canExecute();
        }

        void ICommand.Execute(object parameter)
        {
            execute();
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


    }
}