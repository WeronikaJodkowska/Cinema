using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Administrator
{
	class MainWindowCtrl
	{
		public static void InsertCinema_Click(MainWindow main)
		{
			try
			{
				InsertCinema window = new InsertCinema(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void InsertActor_Click(MainWindow main)
		{
			try
			{
				InsertActor window = new InsertActor(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void InsertDirector_Click(MainWindow main)
		{
			try
			{
				InsertDirector window = new InsertDirector(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void InsertMovie_Click(MainWindow main)
		{
			try
			{
				InsertMovie window = new InsertMovie(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void InsertHall_Click(MainWindow main)
		{
			try
			{
				InsertHall window = new InsertHall(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void DeleteMovie_Click(MainWindow main)
		{
			try
			{
				Delete window = new Delete(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void Update_Click(MainWindow main)
		{
			try
			{
				UpdateCinema window = new UpdateCinema(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void UpdateMovie_Click(MainWindow main)
		{
			try
			{
				UpdateMovie window = new UpdateMovie(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void InsertSession_Click(MainWindow main)
		{
			try
			{
				InsertSession window = new InsertSession(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void XML_Click(MainWindow main)
		{
			try
			{
				XMLWork window = new XMLWork(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

	}
}
