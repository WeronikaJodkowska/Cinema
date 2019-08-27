using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Data.SqlClient;
using System.Media;


namespace Cinema
{
	public class MainCtrl
	{
		public static void GetActorInfo_Click(Main main)
		{
			try
			{
				GetActorInfo window = new GetActorInfo(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void TicketOrder_click(Main main)
		{
			try
			{
				Ticket_order window = new Ticket_order(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void GetCinemaInfo_Click(Main main)
		{
			try
			{
				GetCinemaInfo window = new GetCinemaInfo(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void Exit(Main main)
		{
			try
			{
				AuthorizationWindow window = new AuthorizationWindow();
				window.Show();
				main.Close();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void GetMovieInfo_Click(Main main)
		{
			try
			{
				GetMovieInfo window = new GetMovieInfo(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void GetSessionInfo_Click(Main main)
		{
			try
			{
				GetSessionInfo window = new GetSessionInfo(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		public static void FullTextSearch_Click(Main main)
		{
			try
			{
				FullTextSearch window = new FullTextSearch(main);
				window.Show();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}
	}
}
