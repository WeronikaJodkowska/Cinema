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
	/// Логика взаимодействия для InsertMovie.xaml
	/// </summary>
	public partial class InsertMovie : Window
	{
		MainWindow main;
		string strName, imageName;
		public InsertMovie(MainWindow main)
		{
			InitializeComponent();
			this.main = main;
			BindComboBoxCountry(Country);
			BindComboBoxGenre(Genre);
			BindComboBoxActorName(Actor_name);
			BindComboBoxActorSurname(Actor_surname);
			BindComboBoxDirectorName(Director_name);
			BindComboBoxDirectorSurname(Director_surname);
		}

		public void BindComboBoxCountry(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("Select NAME FROM COUNTRY WITH(INDEX(INDEX_COUNTRY))", cn);
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

		public void BindComboBoxDirectorSurname(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT SURNAME FROM DIRECTOR", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "DIRECTOR");
		    Director_surname.ItemsSource = ds.Tables[0].DefaultView;
			Director_surname.DisplayMemberPath = ds.Tables[0].Columns["SURNAME"].ToString();
		}

		public void BindComboBoxDirectorName(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT NAME FROM DIRECTOR", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "DIRECTOR");
			Director_name.ItemsSource = ds.Tables[0].DefaultView;
			Director_name.DisplayMemberPath = ds.Tables[0].Columns["NAME"].ToString();
		}

		public void BindComboBoxActorSurname(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT SURNAME FROM ACTOR", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "ACTOR");
			Actor_surname.ItemsSource = ds.Tables[0].DefaultView;
			Actor_surname.DisplayMemberPath = ds.Tables[0].Columns["SURNAME"].ToString();
		}

		public void BindComboBoxActorName(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT NAME FROM ACTOR", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "ACTOR");
			Actor_name.ItemsSource = ds.Tables[0].DefaultView;
			Actor_name.DisplayMemberPath = ds.Tables[0].Columns["NAME"].ToString();
		}

		private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.Close();
			main.Show();
		}

		private void Movie(object sender, RoutedEventArgs e)
		{
			try
			{
				if (Validator.ValidTextBoxes(this.Name.Text, this.Country.Text, this.Genre.Text, this.Running_time.Text, this.Director_name.Text, this.Director_surname.Text, this.Screenplay.Text, this.Composer.Text, this.Actor_name.Text, this.Actor_surname.Text, this.Plot.Text))
				{
					if (imageName != "")
					{
						//Initialize a file stream to read the image file
						FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);

						//Initialize a byte array with size of stream
						byte[] imgByteArr = new byte[fs.Length];

						//Read data from the file stream and put into the byte array
						fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));

						//Close a file stream
						fs.Close();

						using (SqlConnection cn = Connector.GetConnection())
						{
							cn.Open();
							SqlCommand cmd = new SqlCommand("InsertMovie", cn);
							cmd.CommandType = System.Data.CommandType.StoredProcedure;

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
							cmd.Parameters.Add(new SqlParameter("image", imgByteArr));

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
				}
				else MessageBox.Show("Введите данные!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		private void btnBrowse_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				FileDialog fldlg = new OpenFileDialog();
				fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
				fldlg.Filter = "Image File (*.jpg;*.jpeg;*.bmp;*.gif;)|*.jpg;*.jpeg;*.bmp;*.gif;";
				fldlg.ShowDialog();
				{
					strName = fldlg.SafeFileName;
					imageName = fldlg.FileName;
					ImageSourceConverter isc = new ImageSourceConverter();
					image1.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));
				}
				fldlg = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}
		}
	}
}
