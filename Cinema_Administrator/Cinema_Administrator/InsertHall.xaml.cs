using System;
using System.Collections.Generic;
using System.Data;
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
	/// Логика взаимодействия для InsertHall.xaml
	/// </summary>
	public partial class InsertHall : Window
	{
		MainWindow main;
		public InsertHall(MainWindow main)
		{
			InitializeComponent();
			this.main = main;
			BindCinema(CinemaName);
		}

		private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.Close();
			main.Show();
		}

		public void BindCinema(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT NAME FROM CINEMA", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "CINEMA");
			CinemaName.ItemsSource = ds.Tables[0].DefaultView;
			CinemaName.DisplayMemberPath = ds.Tables[0].Columns["NAME"].ToString();
		}

		private void Hall(object sender, RoutedEventArgs e)
		{
			try
			{
				if (Validator.ValidTextBoxes(this.Name.Text, this.CinemaName.Text, this.Rows.Text, this.Seats.Text))
				{
					using (SqlConnection cn = Connector.GetConnection())
					{
						cn.Open();
						SqlCommand cmd = new SqlCommand("InsertHall", cn);
						cmd.CommandType = System.Data.CommandType.StoredProcedure;

						SqlParameter name = new SqlParameter();
						name.ParameterName = "@name";
						name.Value = this.Name.Text;

						SqlParameter cinema = new SqlParameter();
						cinema.ParameterName = "@cinema";
						cinema.Value = this.CinemaName.Text;

						SqlParameter rows = new SqlParameter();
						rows.ParameterName = "@rows";
						rows.Value = this.Rows.Text;

					    SqlParameter seats = new SqlParameter();
					    seats.ParameterName = "@seats";
					    seats.Value = this.Seats.Text;

					    cmd.Parameters.Add(name);
						cmd.Parameters.Add(cinema);
						cmd.Parameters.Add(rows);
						cmd.Parameters.Add(seats);

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
