using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Cinema
{
	// <summary>
	// Логика взаимодействия для GetMovieInfo.xaml
	//</summary>
	public partial class GetMovieInfo : Window
	{
		Main main;
		public GetMovieInfo(Main main)
		{
			InitializeComponent();
			this.main = main;
			BindMovie(Name);

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
			Name.ItemsSource = ds.Tables[0].DefaultView;
			Name.DisplayMemberPath = ds.Tables[0].Columns["NAME"].ToString();
		}


		private void LoadCinema_Click(object sender, RoutedEventArgs e)
		{
			ImageClass image = null;
			using (SqlConnection cn = Connector.GetConnection())
			{
				if (Name.Text != "")
				{
					SqlCommand cmd1 = cn.CreateCommand();
					cmd1.CommandText = "SELECT IMAGE FROM MOVIE WHERE NAME = @name";

					cmd1.Parameters.Add(new SqlParameter("@name", Name.Text));
					cn.Open();

					SqlDataReader dr = cmd1.ExecuteReader();

					if (dr.Read())
					{
						image = new ImageClass();
						image.Image = dr.GetValue(0) as byte[];
					}
					else
					{
						MessageBox.Show("Haven't find the id in sql server");
					}
					cn.Close();
				}
				if (image != null)
				{
					#region read the image from a bytes array
					MemoryStream ms = new MemoryStream(image.Image);
					ms.Seek(0, SeekOrigin.Begin);
					BitmapImage newBitmapImage = new BitmapImage();
					newBitmapImage.BeginInit();
					newBitmapImage.StreamSource = ms;
					newBitmapImage.EndInit();
					image1.Source = newBitmapImage;
					#endregion
				}
				SqlCommand cmd = new SqlCommand("GetMovieInfo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				if (Name.Text != "")
				{
					cmd.Parameters.AddWithValue("@name", Name.Text);
				}

				cn.Open();
				SqlDataReader data = cmd.ExecuteReader();
				if (data.HasRows)
				{
					while (data.Read())
					{
						Movie ap = new Movie(data[0].ToString(), data[1].ToString(),
							data[2].ToString(), data[3].ToString(), Convert.ToInt32(data[4].ToString()),
							data[5].ToString(), data[6].ToString(), data[7].ToString(), data[8].ToString(),
							data[9].ToString(), data[10].ToString(), data[11].ToString());
						this.Cinema.Items.Add(ap);
					}
					cn.Close();
				}
				else
				{
					MessageBox.Show("Ничего не найдено! Проверьте правильность введённых данных.");
				}
			}
		}
	}
}
