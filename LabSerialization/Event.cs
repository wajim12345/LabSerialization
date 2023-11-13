using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSerialization
{
	internal class Event
	{
		public int EventNumber {  get; set; }
		public string Location { get; set; }

		public Event(int eventNumber, string location)
		{
			this.EventNumber = eventNumber;
			this.Location = location;
		}
	}
}
