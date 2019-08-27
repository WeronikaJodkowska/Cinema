using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cinema_Administrator
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		private void InsertCinema_Click(object sender, RoutedEventArgs e)
		{
			MainWindowCtrl.InsertCinema_Click(this);
			this.Hide();
		}

		private void InsertActor_Click(object sender, RoutedEventArgs e)
		{
			MainWindowCtrl.InsertActor_Click(this);
			this.Hide();
		}

		private void InsertDirector_Click(object sender, RoutedEventArgs e)
		{
			MainWindowCtrl.InsertDirector_Click(this);
			this.Hide();
		}

		private void InsertMovie_Click(object sender, RoutedEventArgs e)
		{
			MainWindowCtrl.InsertMovie_Click(this);
			this.Hide();
		}

		private void InsertHall_Click(object sender, RoutedEventArgs e)
		{
			MainWindowCtrl.InsertHall_Click(this);
			this.Hide();
		}

		private void DeleteMovie_Click(object sender, RoutedEventArgs e)
		{
			MainWindowCtrl.DeleteMovie_Click(this);
			this.Hide();
		}

		private void Update_Click(object sender, RoutedEventArgs e)
		{
			MainWindowCtrl.Update_Click(this);
			this.Hide();
		}

		private void UpdateMovie_Click(object sender, RoutedEventArgs e)
		{
			MainWindowCtrl.UpdateMovie_Click(this);
			this.Hide();
		}

		private void InsertSession_Click(object sender, RoutedEventArgs e)
		{
			MainWindowCtrl.InsertSession_Click(this);
			this.Hide();
		}

		private void XML_Click(object sender, RoutedEventArgs e)
		{
			MainWindowCtrl.XML_Click(this);
			this.Hide();
		}
	}
}

