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

namespace Cinema
{
	/// <summary>
	/// Логика взаимодействия для FullTextSearch.xaml
	/// </summary>
	public partial class FullTextSearch : Window
	{
		Main main;
		public FullTextSearch(Main main)
		{
			InitializeComponent();
			this.main = main;
		}

		private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.Close();
			main.Show();
		}

		private void FullTextSearch_Click(object sender, RoutedEventArgs e)
		{
			using (SqlConnection cn = Connector.GetConnection())
			{
				SqlCommand cmd = new SqlCommand("FullTextSearch", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@plot", SearchText.Text);

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
						this.FullText.Items.Add(ap);
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
