using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
	class CinemaClass
	{
		public CinemaClass(string pname, string paddress, string pwebsite, string pregion, int pnumber, string pticket)
		{
			this.Name = pname;
			this.Address = paddress;
			this.Website = pwebsite;
			this.Region = pregion;
			this.Number = pnumber;
			this.Ticket = pticket;
		}

		public string Name { get; set; }
		public string Address { get; set; }
		public string Website { get; set; }
		public string Region { get; set; }
		public int Number { get; set; }
		public string Ticket { get; set; }
	}
}
