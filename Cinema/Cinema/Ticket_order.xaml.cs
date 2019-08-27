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

namespace Cinema
{
    /// <summary>
    /// Логика взаимодействия для Ticket_order.xaml
    /// </summary>
    public partial class Ticket_order : Window
    {
		Main main;

		public Ticket_order(Main main)
        {
            InitializeComponent();
			this.main = main;
			BindMovie(Movie);
			BindCinema(Cinema);
			BindHall(Hall);
			BindTime(Time);
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

		public void BindTime(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT TIME FROM SESSION", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "SESSION");
			Time.ItemsSource = ds.Tables[0].DefaultView;
			Time.DisplayMemberPath = ds.Tables[0].Columns["TIME"].ToString();
		}

		private void Purchase(object sender, RoutedEventArgs e)
		{
			try
			{
				using (SqlConnection cn = Connector.GetConnection())
				{
					cn.Open();
					SqlCommand cmd = new SqlCommand("InsertTicket", cn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

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

					SqlParameter time = new SqlParameter();
					time.ParameterName = "@time";
					time.Value = TimeSpan.Parse(Time.Text);

					SqlParameter pass = new SqlParameter();
					pass.ParameterName = "@pass";
					pass.Value = this.Pass.Text;

					#region RowSeat
					SqlParameter row1 = new SqlParameter();
					row1.ParameterName = "@row1";
					row1.Value = this.Row1.Text;

					SqlParameter row2 = new SqlParameter();
					row2.ParameterName = "@row2";
					row2.Value = this.Row2.Text;

					SqlParameter row3 = new SqlParameter();
					row3.ParameterName = "@row3";
					row3.Value = this.Row3.Text;

					SqlParameter row4 = new SqlParameter();
					row4.ParameterName = "@row4";
					row4.Value = this.Row4.Text;

					SqlParameter row5 = new SqlParameter();
					row5.ParameterName = "@row5";
					row5.Value = this.Row5.Text;

					SqlParameter row6 = new SqlParameter();
					row6.ParameterName = "@row6";
					row6.Value = this.Row6.Text;

					SqlParameter row7 = new SqlParameter();
					row7.ParameterName = "@row7";
					row7.Value = this.Row7.Text;

					SqlParameter row8 = new SqlParameter();
					row8.ParameterName = "@row8";
					row8.Value = this.Row8.Text;

					SqlParameter row9 = new SqlParameter();
					row9.ParameterName = "@row9";
					row9.Value = this.Row9.Text;

					SqlParameter row10 = new SqlParameter();
					row10.ParameterName = "@row10";
					row10.Value = this.Row10.Text;

					SqlParameter seat1 = new SqlParameter();
					seat1.ParameterName = "@seat1";
					seat1.Value = this.Seat1.Text;

					SqlParameter seat2 = new SqlParameter();
					seat2.ParameterName = "@seat2";
					seat2.Value = this.Seat2.Text;

					SqlParameter seat3 = new SqlParameter();
					seat3.ParameterName = "@seat3";
					seat3.Value = this.Seat3.Text;

					SqlParameter seat4 = new SqlParameter();
					seat4.ParameterName = "@seat4";
					seat4.Value = this.Seat4.Text;

					SqlParameter seat5 = new SqlParameter();
					seat5.ParameterName = "@seat5";
					seat5.Value = this.Seat5.Text;

					SqlParameter seat6 = new SqlParameter();
					seat6.ParameterName = "@seat6";
					seat6.Value = this.Seat6.Text;

					SqlParameter seat7 = new SqlParameter();
					seat7.ParameterName = "@seat7";
					seat7.Value = this.Seat7.Text;

					SqlParameter seat8 = new SqlParameter();
					seat8.ParameterName = "@seat8";
					seat8.Value = this.Seat8.Text;

					SqlParameter seat9 = new SqlParameter();
					seat9.ParameterName = "@seat9";
					seat9.Value = this.Seat9.Text;

					SqlParameter seat10 = new SqlParameter();
					seat10.ParameterName = "@seat10";
					seat10.Value = this.Seat10.Text;
					#endregion RowSeat

					#region IfRow
					if (Row1.Text.Length == 0)
					{
						row1.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(row1);
					}


					if (Row2.Text.Length == 0)
					{
						row2.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(row2);
					}

					if (Row3.Text.Length == 0)
					{
						row3.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(row3);
					}

					if (Row4.Text.Length == 0)
					{
						row4.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(row4);
					}

					if (Row5.Text.Length == 0)
					{
						row5.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(row5);
					}
					
					if (Row6.Text.Length == 0)
					{
						row6.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(row6);
					}

					if (Row7.Text.Length == 0)
					{
						row7.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(row7);
					}

					if (Row8.Text.Length == 0)
					{
						row8.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(row8);
					}

					if (Row9.Text.Length == 0)
					{
						row9.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(row9);
					}

					if (Row10.Text.Length == 0)
					{
						row10.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(row10);
					}
					#endregion IfRow


					#region IfSeat
					if (Seat1.Text.Length == 0)
					{
						seat1.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(seat1);
					}


					if (Seat2.Text.Length == 0)
					{
						seat2.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(seat2);
					}

					if (Seat3.Text.Length == 0)
					{
						seat3.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(seat3);
					}

					if (Seat4.Text.Length == 0)
					{
						seat4.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(seat4);
					}

					if (Seat5.Text.Length == 0)
					{
						seat5.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(seat5);
					}

					if (Seat6.Text.Length == 0)
					{
						seat6.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(seat6);
					}

					if (Seat7.Text.Length == 0)
					{
						seat7.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(seat7);
					}

					if (Seat8.Text.Length == 0)
					{
						seat8.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(seat8);
					}

					if (Seat9.Text.Length == 0)
					{
						seat9.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(seat9);
					}

					if (Seat10.Text.Length == 0)
					{
						seat10.Value = DBNull.Value;
					}
					else
					{
						cmd.Parameters.Add(seat10);
					}
					#endregion IfSeat

					cmd.Parameters.Add(movie);
					cmd.Parameters.Add(cinema);
					cmd.Parameters.Add(hall);
					cmd.Parameters.Add(date);
					cmd.Parameters.Add(time);
					cmd.Parameters.Add(pass);

					SqlParameter rc = new SqlParameter();
					rc.ParameterName = "@rc";
					rc.SqlDbType = SqlDbType.Bit;
					rc.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(rc);

					cmd.ExecuteNonQuery();

					cn.Close();

					if ((bool)cmd.Parameters["@rc"].Value)
					{
						MessageBox.Show("Покупка совершена успешно!");
						this.Show();
					}
					else MessageBox.Show("Ошибка. Проверьте введённые данные.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void FreeSeats(object sender, RoutedEventArgs e)
		{
			try
			{
				using (SqlConnection cn = Connector.GetConnection())
				{
					cn.Open();
					SqlCommand cmd = new SqlCommand("SelectFreeSeats", cn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

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

					SqlParameter time = new SqlParameter();
					time.ParameterName = "@time";
					time.Value = TimeSpan.Parse(Time.Text);

					cmd.Parameters.Add(movie);
					cmd.Parameters.Add(cinema);
					cmd.Parameters.Add(hall);
					cmd.Parameters.Add(date);
					cmd.Parameters.Add(time);

					SqlParameter rc = new SqlParameter("@freeseats", SqlDbType.Int);
					rc.Direction = ParameterDirection.Output;

					cmd.Parameters.Add(rc);

					cmd.ExecuteNonQuery();

					cn.Close();

					Seats.Text = rc.Value.ToString();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void SelectPrice(object sender, RoutedEventArgs e)
		{
			try
			{
				using (SqlConnection cn = Connector.GetConnection())
				{
					cn.Open();
					SqlCommand cmd = new SqlCommand("SelectPrice", cn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					SqlParameter pass = new SqlParameter();
					pass.ParameterName = "@pass";
					pass.Value = this.Pass.Text;

					cmd.Parameters.Add(pass);

					SqlParameter rc = new SqlParameter("@price", SqlDbType.Int);
					rc.Direction = ParameterDirection.Output;

					cmd.Parameters.Add(rc);

					cmd.ExecuteNonQuery();

					cn.Close();

					Price.Text = rc.Value.ToString();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
