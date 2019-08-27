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
	/// Логика взаимодействия для GetCinemaInfo.xaml
	/// </summary>
	public partial class GetCinemaInfo : Window
	{
		Main main;
		public GetCinemaInfo(Main main)
		{
			InitializeComponent();
			this.main = main;
			BindCinema(Name);
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
			Name.ItemsSource = ds.Tables[0].DefaultView;
			Name.DisplayMemberPath = ds.Tables[0].Columns["NAME"].ToString();
		}

		private void LoadCinema_Click(object sender, RoutedEventArgs e)
		{
			using (SqlConnection cn = Connector.GetConnection())
			{
				SqlCommand cmd = new SqlCommand("GetCinemaInfo", cn);
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
						CinemaClass ap = new CinemaClass(data[0].ToString(), data[1].ToString(),
							data[2].ToString(), data[3].ToString(), Convert.ToInt32(data[4].ToString()), data[5].ToString());
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
