using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
	class Session
	{
		public Session(string pmovie, string phall, DateTime pdate, TimeSpan ptime, int pfreeseats, int pcost)
		{
			this.Movie = pmovie;
			this.Hall = phall;
			this.Date = pdate;
			this.Time = ptime;
			this.FreeSeats = pfreeseats;
			this.Cost = pcost;
		}

		public string Movie { get; set; }
		public string Hall { get; set; }
		public DateTime Date { get; set; }
		public TimeSpan Time { get; set; }
		public int FreeSeats { get; set; }
		public int Cost { get; set; }
	}
}
