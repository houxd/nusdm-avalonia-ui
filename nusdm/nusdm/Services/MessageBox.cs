using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Layout;
using System.Threading.Tasks;

namespace nusdm
{
	/// <summary>Minimal cross-platform message box built on top of Avalonia.</summary>
	public static class MessageBox
	{
		public static async Task ShowErrorAsync(string title, string message)
		{
			var window = new Window
			{
				Title = title,
				Width = 420,
				Height = 150,
				WindowStartupLocation = WindowStartupLocation.CenterScreen,
				CanResize = false,
			};

			var btn = new Button { Content = "OK", HorizontalAlignment = HorizontalAlignment.Center, Margin = new Thickness(0, 8, 0, 0) };
			var panel = new StackPanel
			{
				Margin = new Thickness(20),
				Spacing = 8,
				Children =
				{
					new TextBlock { Text = message, TextWrapping = Avalonia.Media.TextWrapping.Wrap },
					btn
				}
			};

			window.Content = panel;
			btn.Click += (_, _) => window.Close();

			var owner = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
			if (owner != null)
				await window.ShowDialog(owner);
			else
				window.Show();
		}
	}
}
