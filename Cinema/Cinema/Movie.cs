using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
	class Movie
	{
		public Movie(string pname, string prelease, string pcountry, string pgenre, int ptime, string pdsurname, 
			string pdname, string pscreenplay, string pcomposer, string pasurname, string paname, string pplot)
		{
			this.Name = pname;
			this.Release = prelease;
			this.Country = pcountry;
			this.Genre = pgenre;
			this.Running_time = ptime;
			this.D_Surname = pdsurname;
			this.D_Name = pdname;
			this.Screenplay = pscreenplay;
			this.Composer = pcomposer;
			this.A_Surname = pasurname;
			this.A_Name = paname;
			this.Plot = pplot;
		}
                   
		public string Name { get; set; }
		public string Release { get; set; }
		public string Country { get; set; }
		public string Genre { get; set; }
		public int Running_time { get; set; }
		public string D_Surname { get; set; }
		public string D_Name { get; set; }
		public string Screenplay { get; set; }
		public string Composer { get; set; }
		public string A_Surname { get; set; }
		public string A_Name { get; set; }
		public string Plot { get; set; }
	}
}
