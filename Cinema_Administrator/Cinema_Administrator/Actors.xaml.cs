using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Actors.xaml
    /// </summary>
    public partial class Actors : Window
    {
		//InsertMovie movie;
		//InsertMovie movie;
		public Actors()
        {
            InitializeComponent();
			//this.movie = movie;
		}

		//private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		//{
		//	Hide();
		//	//new InsertMovie(movie).ShowDialog();
		//	ShowDialog();

		//}

		private void Actor(object sender, RoutedEventArgs e)
		{
			try
			{
				//if (Validator.ValidTextBoxes(this.Name.Text, this.CinemaName.Text))
				//{
				using (SqlConnection cn = Connector.GetConnection())
				{
					cn.Open();
					SqlCommand cmd = new SqlCommand("InsertActorMovie", cn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					SqlParameter name = new SqlParameter();
					name.ParameterName = "@name";
					name.Value = this.Name1.Text;
					name.Value = this.Name2.Text;
					name.Value = this.Name3.Text;
					name.Value = this.Name4.Text;
					name.Value = this.Name5.Text;

					//int.Parse(CinemaName.Text);

					SqlParameter cinema = new SqlParameter();
					cinema.ParameterName = "@cinema";
					cinema.Value = this.SurName1.Text;

					cmd.Parameters.Add(name);
					cmd.Parameters.Add(cinema);

					SqlParameter rc = new SqlParameter();
					rc.ParameterName = "@rc";
					rc.SqlDbType = System.Data.SqlDbType.Bit;
					rc.Direction = System.Data.ParameterDirection.Output;
					cmd.Parameters.Add(rc);

					cmd.ExecuteNonQuery();

					cn.Close();

					if ((bool)cmd.Parameters["@rc"].Value)
					{
						MessageBox.Show("Inserting completed successfully!");
						MainWindow mainWnd = new MainWindow();
						mainWnd.Show();
						this.Close();
					}
					else MessageBox.Show("Inserting error");
				}
				//}
				//else MessageBox.Show("Enter data!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
