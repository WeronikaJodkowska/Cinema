using System.Media;
using System.Windows;
using System.Windows.Threading;


namespace Cinema
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class Main : Window

	{
		public Main()
		{
			InitializeComponent();

		}


		private void FullTextSearch_Click(object sender, RoutedEventArgs e)
		{
			MainCtrl.FullTextSearch_Click(this);
			this.Hide();
		}

		private void GetActorInfo_Click(object sender, RoutedEventArgs e)
		{
			MainCtrl.GetActorInfo_Click(this);
			this.Hide();
		}

		private void TicketOrder_click(object sender, RoutedEventArgs e)
		{
			MainCtrl.TicketOrder_click(this);
			this.Hide();
		}

		private void GetCinemaInfo_Click(object sender, RoutedEventArgs e)
		{
			MainCtrl.GetCinemaInfo_Click(this);
			this.Hide();
		}

		private void Exit(object sender, RoutedEventArgs e)
		{
			MainCtrl.Exit(this);
		}


		private void GetMovieInfo_Click(object sender, RoutedEventArgs e)
		{
			MainCtrl.GetMovieInfo_Click(this);
			this.Hide();
		}

		private void GetSessionInfo_Click(object sender, RoutedEventArgs e)
		{
			MainCtrl.GetSessionInfo_Click(this);
			this.Hide();
		}
	}
}
