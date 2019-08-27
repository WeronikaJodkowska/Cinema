using Microsoft.Win32;
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
using System.Windows.Shapes;
using WpfApplication2;

namespace Cinema_Administrator
{
	/// <summary>
	/// Логика взаимодействия для UpdateMovie.xaml
	/// </summary>
	public partial class UpdateMovie : Window
	{
		MainWindow main;

		public UpdateMovie(MainWindow main)
		{
			InitializeComponent();
			this.main = main;
			BindComboBoxCountry(Country);
			BindComboBoxGenre(Genre);
		}
		public void BindComboBoxCountry(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("Select NAME FROM COUNTRY", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "COUNTRY");
			Country.ItemsSource = ds.Tables[0].DefaultView;
			Country.DisplayMemberPath = ds.Tables[0].Columns["NAME"].ToString();
		}

		public void BindComboBoxGenre(ComboBox comboBoxName1)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("Select NAME FROM GENRE", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "GENRE");
			Genre.ItemsSource = ds.Tables[0].DefaultView;
			Genre.DisplayMemberPath = ds.Tables[0].Columns["NAME"].ToString();
		}

		private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.Close();
			main.Show();

		}

		private void Update(object sender, RoutedEventArgs e)
		{
			try
			{
				using (SqlConnection cn = Connector.GetConnection())
				{
					cn.Open();
					SqlCommand cmd = new SqlCommand("UpdateMovie", cn);
					cmd.CommandType = CommandType.StoredProcedure;

					SqlParameter check2 = new SqlParameter();
					check2.ParameterName = "@check2";
					check2.Value = this.check2.IsChecked == true ? true : false;

					SqlParameter check3 = new SqlParameter();
					check3.ParameterName = "@check3";
					check3.Value = this.check3.IsChecked == true ? true : false;

					SqlParameter check4 = new SqlParameter();
					check4.ParameterName = "@check4";
					check4.Value = this.check4.IsChecked == true ? true : false;

					SqlParameter check5 = new SqlParameter();
					check5.ParameterName = "@check5";
					check5.Value = this.check5.IsChecked == true ? true : false;

					SqlParameter check6 = new SqlParameter();
					check6.ParameterName = "@check6";
					check6.Value = this.check6.IsChecked == true ? true : false;

					SqlParameter check7 = new SqlParameter();
					check7.ParameterName = "@check7";
					check7.Value = this.check7.IsChecked == true ? true : false;

					SqlParameter check8 = new SqlParameter();
					check8.ParameterName = "@check8";
					check8.Value = this.check8.IsChecked == true ? true : false;

					SqlParameter check9 = new SqlParameter();
					check9.ParameterName = "@check9";
					check9.Value = this.check9.IsChecked == true ? true : false;

					SqlParameter name = new SqlParameter();
					name.ParameterName = "@name";
					name.Value = this.Name.Text;

					SqlParameter surname = new SqlParameter();
					surname.ParameterName = "@release";
					surname.Value = this.pick.SelectedDate;

					SqlParameter country = new SqlParameter();
					country.ParameterName = "@country";
					country.Value = this.Country.Text;

					SqlParameter genre = new SqlParameter();
					genre.ParameterName = "@genre";
					genre.Value = this.Genre.Text;

					SqlParameter time = new SqlParameter();
					time.ParameterName = "@runningtime";
					time.Value = this.Running_time.Text;

					SqlParameter directorname = new SqlParameter();
					directorname.ParameterName = "@directorname";
					directorname.Value = this.Director_name.Text;

					SqlParameter directorsurname = new SqlParameter();
					directorsurname.ParameterName = "@directorsurname";
					directorsurname.Value = this.Director_surname.Text;

					SqlParameter screenplay = new SqlParameter();
					screenplay.ParameterName = "@screenplay";
					screenplay.Value = this.Screenplay.Text;

					SqlParameter composer = new SqlParameter();
					composer.ParameterName = "@composer";
					composer.Value = this.Composer.Text;

					SqlParameter actorname = new SqlParameter();
					actorname.ParameterName = "@actorname";
					actorname.Value = this.Actor_name.Text;

					SqlParameter actorsurname = new SqlParameter();
					actorsurname.ParameterName = "@actorsurname";
					actorsurname.Value = this.Actor_surname.Text;

					SqlParameter plot = new SqlParameter();
					plot.ParameterName = "@plot";
					plot.Value = this.Plot.Text;

					cmd.Parameters.Add(name);
					cmd.Parameters.Add(surname);
					cmd.Parameters.Add(country);
					cmd.Parameters.Add(genre);
					cmd.Parameters.Add(time);
					cmd.Parameters.Add(directorname);
					cmd.Parameters.Add(directorsurname);
					cmd.Parameters.Add(screenplay);
					cmd.Parameters.Add(composer);
					cmd.Parameters.Add(actorname);
					cmd.Parameters.Add(actorsurname);
					cmd.Parameters.Add(plot);
					cmd.Parameters.Add(check2);
					cmd.Parameters.Add(check3);
					cmd.Parameters.Add(check4);
					cmd.Parameters.Add(check5);
					cmd.Parameters.Add(check6);
					cmd.Parameters.Add(check7);
					cmd.Parameters.Add(check8);
					cmd.Parameters.Add(check9);

					SqlParameter rc = new SqlParameter();
					rc.ParameterName = "@rc";
					rc.SqlDbType = System.Data.SqlDbType.Bit;
					rc.Direction = System.Data.ParameterDirection.Output;
					cmd.Parameters.Add(rc);

					cmd.ExecuteNonQuery();

					cn.Close();

					if ((bool)cmd.Parameters["@rc"].Value)
					{
						MessageBox.Show("Обновление произошло успешно!");
						MainWindow mainWnd = new MainWindow();
						mainWnd.Show();
						this.Close();
					}
					else MessageBox.Show("Ошибка обновления!");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
