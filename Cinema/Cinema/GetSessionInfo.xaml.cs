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
    /// Логика взаимодействия для GetSessionInfo.xaml
    /// </summary>
    public partial class GetSessionInfo : Window
    {
		Main main;
        public GetSessionInfo(Main main)
        {
            InitializeComponent();
			this.main = main;
        }

		private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.Close();
			main.Show();
		}

		private void LoadSession_Click(object sender, RoutedEventArgs e)
		{
			using (SqlConnection cn = Connector.GetConnection())
			{
				SqlCommand cmd = new SqlCommand("GetSessionInfo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				if (Date.Text != "")
				{
					cmd.Parameters.AddWithValue("@date", Date.Text);
				}

				cn.Open();
				SqlDataReader data = cmd.ExecuteReader();
				if (data.HasRows)
				{
					while (data.Read())
					{
						Session ap = new Session(data[0].ToString(), data[1].ToString(),
							Convert.ToDateTime(data[2].ToString()), TimeSpan.Parse(data[3].ToString()), 
							Convert.ToInt32(data[4].ToString()), Convert.ToInt32(data[5].ToString()));
						this.Session.Items.Add(ap);
					}
					cn.Close();
				}
				else
				{
					MessageBox.Show("No rows found.");
				}

			}
		}
	}
}
