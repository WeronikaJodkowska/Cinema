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
	/// <summary>
	/// Логика взаимодействия для ActorInfo.xaml
	/// </summary>
	public partial class GetActorInfo : Window
	{
		Main main;
		public GetActorInfo(Main main)
		{
			InitializeComponent();
			this.main = main;
			BindComboBoxActorName(Name);
			BindComboBoxActorSurname(SurName);
		}

		private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.Close();
			main.Show();
		}

		public void BindComboBoxActorSurname(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT SURNAME FROM ACTOR", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "ACTOR");
			SurName.ItemsSource = ds.Tables[0].DefaultView;
			SurName.DisplayMemberPath = ds.Tables[0].Columns["SURNAME"].ToString();
		}

		public void BindComboBoxActorName(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("SELECT NAME FROM ACTOR", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "ACTOR");
			Name.ItemsSource = ds.Tables[0].DefaultView;
			Name.DisplayMemberPath = ds.Tables[0].Columns["NAME"].ToString();
		}

		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			ImageClass image = null;
			using (SqlConnection cn = Connector.GetConnection())
			{
				if (Name.Text != "" && SurName.Text != "")
				{
					SqlCommand cmd1 = cn.CreateCommand();
					cmd1.CommandText = "SELECT IMAGE FROM ACTOR WHERE NAME = @name";

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
					System.IO.MemoryStream ms = new System.IO.MemoryStream(image.Image);
					ms.Seek(0, System.IO.SeekOrigin.Begin);
					BitmapImage newBitmapImage = new BitmapImage();
					newBitmapImage.BeginInit();
					newBitmapImage.StreamSource = ms;
					newBitmapImage.EndInit();
					image1.Source = newBitmapImage;
					#endregion
				}
				SqlCommand cmd = new SqlCommand("GetActorInfo", cn);
				cmd.CommandType = CommandType.StoredProcedure;

				if (Name.Text != "" && SurName.Text != "")
				{
					cmd.Parameters.AddWithValue("@name", Name.Text);
					cmd.Parameters.AddWithValue("@surname", SurName.Text);
				}

				cn.Open();
				SqlDataReader data = cmd.ExecuteReader();
				if (data.HasRows)
				{
					while (data.Read())
					{
						Actor ap = new Actor(data[0].ToString(), data[1].ToString(),
							data[2].ToString(), Convert.ToInt32(data[3].ToString()));
						this.Actor.Items.Add(ap);
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

