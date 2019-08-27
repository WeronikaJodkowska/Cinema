using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
	static class Connector
	{
		const string path = @"Data Source=DESKTOP-6HPGSAL;Initial Catalog=Cinema;Integrated Security=True;User Id=CLIENT_LOG; Password=2222";

		static public SqlConnection GetConnection()
		{
			return new SqlConnection(path);
		}
	}
}
