using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
using System.Text.RegularExpressions;
using WpfApplication2;

namespace Cinema
{
	/// <summary>
	/// Логика взаимодействия для RegistrationWindow.xaml
	/// </summary>
	public partial class RegistrationWindow : Window
	{
		public RegistrationWindow()
		{
			InitializeComponent();
		}

		private void Registration(object sender, RoutedEventArgs e)
		{
			try
			{
				if (Validator.ValidTextBoxes(this.Login.Text, this.Password.Password, this.Email.Text))
				{
					using (SqlConnection cn = Connector.GetConnection())
					{
						cn.Open();
						SqlCommand cmd = new SqlCommand("Registration", cn);
						cmd.CommandType = System.Data.CommandType.StoredProcedure;

						SqlParameter login = new SqlParameter();
						login.ParameterName = "@login";
						login.Value = this.Login.Text;

						SqlParameter pass = new SqlParameter();
						pass.ParameterName = "@password";
						pass.Value = this.Password.Password;

						SqlParameter email = new SqlParameter();
						email.ParameterName = "@email";
						email.Value = this.Email.Text;

						cmd.Parameters.Add(login);
						cmd.Parameters.Add(pass);
						cmd.Parameters.Add(email);

						SqlParameter rc = new SqlParameter();
						rc.ParameterName = "@rc";
						rc.SqlDbType = System.Data.SqlDbType.Bit;
						rc.Direction = System.Data.ParameterDirection.Output;
						cmd.Parameters.Add(rc);

						cmd.ExecuteNonQuery();

						cn.Close();

						if ((bool) cmd.Parameters["@rc"].Value)
						{
							MessageBox.Show("Регистрация прошла успешно!");
							Main mainWnd = new Main();
							mainWnd.Show();
							this.Close();
						}
						else MessageBox.Show("Ошибка регистрации!");
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
