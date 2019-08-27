using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
	public class Actor
	{
		public Actor(string pname, string psurname, string pcountry, int page)
		{
			this.Name = pname;
			this.SurName = psurname;
			this.Country = pcountry;
			this.Age = page;
		}
		public string Name { get; set; }
		public string SurName { get; set; }
		public string Country { get; set; }
		public int Age { get; set; }
		public byte[] Image { get; set; }
	}
}
