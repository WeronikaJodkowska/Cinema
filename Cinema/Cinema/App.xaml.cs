using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Cinema
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static string CurrentUser = string.Empty;
		public static string Hashed = string.Empty;
		public static string CurrentId = string.Empty;
		public static int CurrentX = 0;
		double screeHeight = SystemParameters.FullPrimaryScreenHeight;

		public App()
		{
			InitializeComponent();
		}
	}
}



