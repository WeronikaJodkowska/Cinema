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
	/// Логика взаимодействия для Delete.xaml
	/// </summary>
	public partial class Delete : Window
	{
		MainWindow main;
		public Delete(MainWindow main)
		{
			this.main = main;
			InitializeComponent();
			BindComboBoxCinemaName(CinemaName);
			BindComboBoxCinemaRegion(Region);
			BindComboBoxMovieName(Name);
			BindComboBoxMovieRelease(Release);
		}

		private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.Close();
			main.Show();
		}

		public void BindComboBoxCinemaName(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT NAME FROM CINEMA", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "CINEMA");
			CinemaName.ItemsSource = ds.Tables[0].DefaultView;
			CinemaName.DisplayMemberPath = ds.Tables[0].Columns["NAME"].ToString();
		}

		public void BindComboBoxCinemaRegion(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT REGION FROM CINEMA", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "CINEMA");
			Region.ItemsSource = ds.Tables[0].DefaultView;
			Region.DisplayMemberPath = ds.Tables[0].Columns["REGION"].ToString();
		}


		public void BindComboBoxMovieName(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT NAME FROM MOVIE", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "MOVIE");
			Name.ItemsSource = ds.Tables[0].DefaultView;
			Name.DisplayMemberPath = ds.Tables[0].Columns["NAME"].ToString();
		}

		public void BindComboBoxMovieRelease(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT RELEASE FROM MOVIE", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "MOVIE");
			Release.ItemsSource = ds.Tables[0].DefaultView;
			Release.DisplayMemberPath = ds.Tables[0].Columns["RELEASE"].ToString();
		}

		private void DeleteMovie(object sender, RoutedEventArgs e)
		{
			try
			{
				using (SqlConnection cn = Connector.GetConnection())
				{
					cn.Open();
					SqlCommand cmd = new SqlCommand("DeleteMovie", cn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					SqlParameter name = new SqlParameter();
					name.ParameterName = "@name";
					name.Value = this.Name.Text;

					SqlParameter release = new SqlParameter();
					release.ParameterName = "@release";
					release.Value = this.Release.Text;

					cmd.Parameters.Add(name);
					cmd.Parameters.Add(release);

					SqlParameter rc = new SqlParameter();
					rc.ParameterName = "@rc";
					rc.SqlDbType = System.Data.SqlDbType.Bit;
					rc.Direction = System.Data.ParameterDirection.Output;
					cmd.Parameters.Add(rc);

					cmd.ExecuteNonQuery();

					cn.Close();

					if ((bool)cmd.Parameters["@rc"].Value)
					{
						MessageBox.Show("Удаление произошло успешно!");
						MainWindow mainWnd = new MainWindow();
						mainWnd.Show();
						this.Close();
					}
					else MessageBox.Show("Ошибка удаления. Проверьте введённые данные.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void DeleteCinema(object sender, RoutedEventArgs e)
		{
			try
			{
				if (Validator.ValidTextBoxes(this.CinemaName.Text, this.Region.Text))
				{
					using (SqlConnection cn = Connector.GetConnection())
					{
						cn.Open();
						SqlCommand cmd = new SqlCommand("DeleteCinema", cn);
						cmd.CommandType = System.Data.CommandType.StoredProcedure;

						SqlParameter name = new SqlParameter();
						name.ParameterName = "@name";
						name.Value = this.CinemaName.Text;

						SqlParameter region = new SqlParameter();
						region.ParameterName = "@region";
						region.Value = this.Region.Text;

						cmd.Parameters.Add(name);
						cmd.Parameters.Add(region);

						SqlParameter rc = new SqlParameter();
						rc.ParameterName = "@rc";
						rc.SqlDbType = System.Data.SqlDbType.Bit;
						rc.Direction = System.Data.ParameterDirection.Output;
						cmd.Parameters.Add(rc);

						cmd.ExecuteNonQuery();

						cn.Close();

						if ((bool)cmd.Parameters["@rc"].Value)
						{
							MessageBox.Show("Удаление произошло успешно!");
							MainWindow mainWnd = new MainWindow();
							mainWnd.Show();
							this.Close();
						}
						else MessageBox.Show("Ошибка удаления. Проверьте введённые данные.");
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
