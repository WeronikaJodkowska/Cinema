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
	/// Логика взаимодействия для InsertSession.xaml
	/// </summary>
	public partial class InsertSession : Window
	{
		MainWindow main;

		public InsertSession(MainWindow main)
		{
			InitializeComponent();
			this.main = main;
			BindMovie(Movie);
			BindCinema(Cinema);
			BindHall(Hall);
		}

		private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.Close();
			main.Show();
		}

		public void BindMovie(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT NAME FROM MOVIE", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "MOVIE");
			Movie.ItemsSource = ds.Tables[0].DefaultView;
			Movie.DisplayMemberPath = ds.Tables[0].Columns["NAME"].ToString();
		}

		public void BindCinema(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT NAME FROM CINEMA", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "CINEMA");
			Cinema.ItemsSource = ds.Tables[0].DefaultView;
			Cinema.DisplayMemberPath = ds.Tables[0].Columns["NAME"].ToString();
		}

		public void BindHall(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT NAME FROM HALL", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "HALL");
			Hall.ItemsSource = ds.Tables[0].DefaultView;
			Hall.DisplayMemberPath = ds.Tables[0].Columns["NAME"].ToString();
		}

		private void Session(object sender, RoutedEventArgs e)
		{
			try
			{
				if (Validator.ValidTextBoxes(this.Movie.Text, this.Cinema.Text, this.Hall.Text, this.Cost.Text, this.Time.Text))
				{
					using (SqlConnection cn = Connector.GetConnection())
					{
						cn.Open();
						SqlCommand cmd = new SqlCommand("InsertSession", cn);
						cmd.CommandType = CommandType.StoredProcedure;

						SqlParameter movie = new SqlParameter();
						movie.ParameterName = "@movie";
						movie.Value = this.Movie.Text;

						SqlParameter cinema = new SqlParameter();
						cinema.ParameterName = "@cinema";
						cinema.Value = this.Cinema.Text;

						SqlParameter hall = new SqlParameter();
						hall.ParameterName = "@hall";
						hall.Value = this.Hall.Text;

						SqlParameter date = new SqlParameter();
						date.ParameterName = "@date";
						date.Value = this.Date.SelectedDate;

						SqlParameter cost = new SqlParameter();
						cost.ParameterName = "@cost";
						cost.Value = this.Cost.Text;
						 
						SqlParameter time = new SqlParameter();
						time.ParameterName = "@time";
						time.Value = TimeSpan.Parse(Time.Text);

						cmd.Parameters.Add(movie);
						cmd.Parameters.Add(cinema);
						cmd.Parameters.Add(hall);
						cmd.Parameters.Add(date);
						cmd.Parameters.Add(cost);
						cmd.Parameters.Add(time);

						SqlParameter rc = new SqlParameter();
						rc.ParameterName = "@rc";
						rc.SqlDbType = SqlDbType.Bit;
						rc.Direction = ParameterDirection.Output;
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
