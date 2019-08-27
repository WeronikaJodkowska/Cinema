using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using WpfApplication2;


namespace Cinema_Administrator
{
	/// <summary>
	/// Логика взаимодействия для InsertDirector.xaml
	/// </summary>
	public partial class InsertDirector : Window
	{
		DataSet ds;
		string strName, imageName;

		MainWindow main;

		public InsertDirector(MainWindow main)
		{
			InitializeComponent();
			this.main = main;
			BindComboBox(Country);
		}

		public void BindComboBox(ComboBox comboBoxName)
		{
			SqlConnection cn = Connector.GetConnection();
			SqlDataAdapter da = new SqlDataAdapter("Select NAME FROM COUNTRY", cn);
			DataSet ds = new DataSet();
			da.Fill(ds, "COUNTRY");
			Country.ItemsSource = ds.Tables[0].DefaultView;
			Country.DisplayMemberPath = ds.Tables[0].Columns["NAME"].ToString();
		}

		private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.Close();
			main.Show();

		}

		private void Director(object sender, RoutedEventArgs e)
		{
			try
			{
				if (Validator.ValidTextBoxes(this.Name.Text, this.Surname.Text, this.Country.Text, this.Age.Text))
				{
					if (imageName != "")
					{
						FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
						byte[] imgByteArr = new byte[fs.Length];
						fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
						fs.Close();

						using (SqlConnection cn = Connector.GetConnection())
						{
							cn.Open();
							SqlCommand cmd = new SqlCommand("InsertDirector", cn);
							cmd.CommandType = System.Data.CommandType.StoredProcedure;

							SqlParameter name = new SqlParameter();
							name.ParameterName = "@name";
							name.Value = this.Name.Text;

							SqlParameter surname = new SqlParameter();
							surname.ParameterName = "@surname";
							surname.Value = this.Surname.Text;

							SqlParameter country = new SqlParameter();
							country.ParameterName = "@country";
							country.Value = this.Country.Text;

							SqlParameter age = new SqlParameter();
							age.ParameterName = "@age";
							age.Value = this.Age.Text;

							cmd.Parameters.Add(name);
							cmd.Parameters.Add(surname);
							cmd.Parameters.Add(country);
							cmd.Parameters.Add(age);
							cmd.Parameters.Add(new SqlParameter("image", imgByteArr));

							SqlParameter rc = new SqlParameter();
							rc.ParameterName = "@rc";
							rc.SqlDbType = System.Data.SqlDbType.Bit;
							rc.Direction = System.Data.ParameterDirection.Output;
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
				fldlg.Filter = "Image File (*.jpg;*.jpeg;*.bmp;*.gif)|*.jpg;*.jpeg;*.bmp;*.gif";
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
