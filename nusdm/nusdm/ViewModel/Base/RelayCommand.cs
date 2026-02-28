using System;
using System.Windows.Input;

namespace nusdm
{
	public class RelayCommand : ICommand
	{
		private readonly Func<bool>? canExecuteEvaluator;
		private readonly Action methodToExecute;

		public RelayCommand(Action methodToExecute, Func<bool>? canExecuteEvaluator = null)
		{
			this.methodToExecute = methodToExecute;
			this.canExecuteEvaluator = canExecuteEvaluator;
		}

		public event EventHandler? CanExecuteChanged;

		public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

		public bool CanExecute(object? parameter)
		{
			if (this.canExecuteEvaluator == null)
			{
				return true;
			}
			return this.canExecuteEvaluator.Invoke();
		}

		public void Execute(object? parameter)
		{
			this.methodToExecute.Invoke();
		}
	}
}
