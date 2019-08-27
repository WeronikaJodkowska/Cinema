using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using WpfApplication2;

namespace Cinema_Administrator
{
	/// <summary>
	/// Логика взаимодействия для InsertCinema.xaml
	/// </summary>
	public partial class InsertCinema : Window
	{
		MainWindow main;

		public InsertCinema(MainWindow main)
		{
			InitializeComponent();
			this.main = main;
		}

		private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.Close();
			main.Show();
		}

		private void Cinema(object sender, RoutedEventArgs e)
		{
			try
			{
				if (Validator.ValidTextBoxes(this.Name.Text, this.Address.Text, this.Region.Text, this.Website.Text, this.TicketOffice.Text, this.Halls.Text))
				{
					using (SqlConnection cn = Connector.GetConnection())
					{
						cn.Open();
						SqlCommand cmd = new SqlCommand("InsertCinema", cn);
						cmd.CommandType = System.Data.CommandType.StoredProcedure;

						SqlParameter name = new SqlParameter();
						name.ParameterName = "@name";
						name.Value = this.Name.Text;

						SqlParameter address = new SqlParameter();
						address.ParameterName = "@address";
						address.Value = this.Address.Text;

						SqlParameter region = new SqlParameter();
						region.ParameterName = "@region";
						region.Value = this.Region.Text;

						SqlParameter website = new SqlParameter();
						website.ParameterName = "@website";
						website.Value = this.Website.Text;

						SqlParameter ticketoffice = new SqlParameter();
						ticketoffice.ParameterName = "@ticketoffice";
						ticketoffice.Value = this.TicketOffice.Text;

						SqlParameter halls = new SqlParameter();
						halls.ParameterName = "@halls";
						halls.Value = this.Halls.Text;

						cmd.Parameters.Add(name);
						cmd.Parameters.Add(address);
						cmd.Parameters.Add(region);
						cmd.Parameters.Add(website);
						cmd.Parameters.Add(ticketoffice);
						cmd.Parameters.Add(halls);

						SqlParameter rc = new SqlParameter();
						rc.ParameterName = "@rc";
						rc.SqlDbType = System.Data.SqlDbType.Bit;
						rc.Direction = System.Data.ParameterDirection.Output;
						cmd.Parameters.Add(rc);

						cmd.ExecuteNonQuery();

						cn.Close();

						if ((bool)cmd.Parameters["@rc"].Value)
						{
							MessageBox.Show("Добавление произошло успешно!");
							MainWindow mainWnd = new MainWindow();
							mainWnd.Show();
							this.Close();
						}
						else MessageBox.Show("Ошибка добавления!");
					}
				}
				else MessageBox.Show("Введите данные!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
