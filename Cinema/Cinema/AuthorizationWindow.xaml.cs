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
using System.Windows.Shapes;
using WpfApplication2;

namespace Cinema
{
	/// <summary>
	/// Логика взаимодействия для AuthorizationWindow.xaml
	/// </summary>
	public partial class AuthorizationWindow : Window
	{
		public AuthorizationWindow()
		{
			InitializeComponent();
		}

		private void Login(object sender, RoutedEventArgs e)
		{
			try
			{
				if (Validator.ValidTextBoxes(this.LOGIN.Text, this.Password.Password))
				{
					using (SqlConnection cn = Connector.GetConnection())
					{
						cn.Open();
						SqlCommand cmd = new SqlCommand("Authorisation", cn);
						cmd.CommandType = System.Data.CommandType.StoredProcedure;

						SqlParameter login = new SqlParameter();
						login.ParameterName = "@login";
						login.Value = this.LOGIN.Text;

						SqlParameter pass = new SqlParameter();
						pass.ParameterName = "@password";
						pass.Value = this.Password.Password;

						cmd.Parameters.Add(login);
						cmd.Parameters.Add(pass);

						SqlParameter rc = new SqlParameter();
						rc.ParameterName = "@rc";
						rc.SqlDbType = System.Data.SqlDbType.Bit;
						rc.Direction = System.Data.ParameterDirection.Output;
						cmd.Parameters.Add(rc);

						cmd.ExecuteNonQuery();

						cn.Close();

						if ((bool) cmd.Parameters["@rc"].Value)
						{
							Main mainWnd = new Main();
							mainWnd.Show();
							this.Close();
						}
						else MessageBox.Show("Ошибка авторизации!");
					}
				}
				else MessageBox.Show("Введите логин и пароль!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void Registration(object sender, RoutedEventArgs e)
		{
			RegistrationWindow regWind = new RegistrationWindow();
			regWind.Show();
			this.Close();
		}

		private void InsertPurchase(object sender, RoutedEventArgs e)
		{
			try
			{
				using (SqlConnection cn = Connector.GetConnection())
				{
					cn.Open();
					SqlCommand cmd = new SqlCommand("InsertPurchase", cn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					SqlParameter login = new SqlParameter();
					login.ParameterName = "@login";
					login.Value = this.LOGIN.Text;

					SqlParameter password = new SqlParameter();
					password.ParameterName = "@password";
					password.Value = this.Password.Password;

					SqlParameter date = new SqlParameter();
					date.ParameterName = "@date";
					date.Value = DateTime.Now;

					cmd.Parameters.Add(login);
					cmd.Parameters.Add(password);
					cmd.Parameters.Add(date);

					SqlParameter rc = new SqlParameter("@rc", SqlDbType.VarChar, 10);
					rc.Direction = ParameterDirection.Output;

					cmd.Parameters.Add(rc);

					cmd.ExecuteNonQuery();

					cn.Close();

					MessageBox.Show("Ваш пароль для покупки: " + rc.Value.ToString());

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
