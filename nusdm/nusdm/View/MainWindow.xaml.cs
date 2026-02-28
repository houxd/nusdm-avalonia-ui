using Avalonia.Controls;
using Avalonia.Input;
using System.ComponentModel;

namespace nusdm
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		#region Private Fields

		private readonly MainWindowViewModel mainWindowViewModel;

		#endregion Private Fields

		#region Public Constructors

		public MainWindow()
		{
			InitializeComponent();

			mainWindowViewModel = new MainWindowViewModel();
			mainWindowViewModel.PropertyChanged += ViewModel_PropertyChanged;

			DataContext = mainWindowViewModel;
		}

		#endregion Public Constructors

		#region Private Methods

		private void FocusFirstInListBox()
		{
			if (lbxTitles.ItemCount > 0)
			{
				lbxTitles.SelectedIndex = 0;
				lbxTitles.Focus();
			}
		}

		private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(MainWindowViewModel.Log))
			{
				sv.ScrollToEnd();
			}
		}

		private void TxtFilter_KeyDown(object? sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter || e.Key == Key.Down)
			{
				FocusFirstInListBox();
				e.Handled = true;
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				Close();
				e.Handled = true;
			}
			else if (e.KeyModifiers == KeyModifiers.None)
			{
				if ((e.Key >= Key.D0 && e.Key <= Key.D9) ||
					(e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
					(e.Key >= Key.A && e.Key <= Key.Z) ||
					e.Key == Key.Space ||
					e.Key == Key.Back)
				{
					txtFilter.Focus();
					e.Handled = false;
				}
			}

			base.OnKeyDown(e);
		}

		#endregion Private Methods
	}
}