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

namespace Cinema_Administrator
{
	/// <summary>
	/// Логика взаимодействия для XMLWork.xaml
	/// </summary>
	public partial class XMLWork : Window
	{
		MainWindow main;
		private string FileName { get; set; }
		private string FileNameExport { get; set; }

		public XMLWork(MainWindow main)
		{
			InitializeComponent();
			this.main = main;
		}

		private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.Close();
			main.Show();

		}

		private void ChoosePathOfXML(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.CheckFileExists = true;
			dlg.Multiselect = false;
			if (dlg.ShowDialog() == true)
			{
				this.FileName = dlg.FileName;
				this.Path.Text = dlg.FileName;
				this.AddFromXML.IsEnabled = true;
			}
		}

		private void AddCinemaFromXLMFile(object sender, RoutedEventArgs e)
		{
			try
			{
				using (SqlConnection cn = Connector.GetConnection())
				{
					cn.Open();
					SqlCommand cmd = new SqlCommand("ImportFromXML", cn);
					cmd.CommandType = CommandType.StoredProcedure;

					SqlParameter path = new SqlParameter();
					path.ParameterName = "@path";
					path.SqlDbType = SqlDbType.NVarChar;
					path.Size = 256;
					path.Value = this.FileName;

					cmd.Parameters.Add(path);

					SqlParameter rc = new SqlParameter();
					rc.ParameterName = "@rc";
					rc.SqlDbType = SqlDbType.Bit;
					rc.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(rc);

					cmd.ExecuteNonQuery();
					cn.Close();

					if ((bool)cmd.Parameters["@rc"].Value)
						MessageBox.Show("Импорт из XML произошёл успешно!");
					else
					    MessageBox.Show("Ошибка импорта из XML!");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ChoosePathToXML(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.CheckFileExists = true;
			dlg.Multiselect = false;
			if (dlg.ShowDialog() == true)
			{
				this.FileNameExport = dlg.FileName;
				this.PathIn.Text = dlg.FileName;
				this.AddInXML.IsEnabled = true;
			}
		}

		private void OnExportToXML(object sender, RoutedEventArgs e)
		{
			try
			{
				using (SqlConnection cn = Connector.GetConnection())
				{
					cn.Open();
					SqlCommand cmd = new SqlCommand("ExportToXML", cn);
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@path", this.FileNameExport);

					SqlParameter rc = new SqlParameter();
					rc.ParameterName = "@rc";
					rc.SqlDbType = SqlDbType.Bit;
					rc.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(rc);

					cmd.ExecuteNonQuery();
					cn.Close();

					if ((bool)cmd.Parameters["@rc"].Value)
						MessageBox.Show("Экспорт в XML произошёл успешно!");
					else
						MessageBox.Show("Ошибка экспорта в XML!");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
