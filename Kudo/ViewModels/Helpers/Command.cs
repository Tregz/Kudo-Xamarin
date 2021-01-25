﻿using System;
using System.Windows.Input;

namespace Kudo
{
    public sealed class Command<T> : Command
    {
        public Command(Action<T> execute) : base(o => execute((T)o))
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
        }

        public Command(Action<T> execute, Func<T, bool> canExecute) :
            base(o => execute((T)o), o => canExecute((T)o))
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }
    }

    public class Command : ICommand
    {
        readonly Func<object, bool> canExecute;
        readonly Action<object> execute;

        public Command(Action<object> execute)
        {
            this.execute = execute ??
                throw new ArgumentNullException(nameof(execute));
        }

        public Command(Action execute) : this(o => execute())
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
        }

        public Command(Action<object> execute, Func<object, bool> canExecute) :
            this(execute)
        {
            this.canExecute = canExecute ??
                throw new ArgumentNullException(nameof(canExecute));
        }

        public Command(Action execute, Func<bool> canExecute) :
            this(o => execute(), o => canExecute())
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
                return canExecute(parameter);

            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public void ChangeCanExecute() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        
    }
}
