using System;
using System.Collections.Generic;

namespace DateTracker
{
	public class Migration_002
	{
		public IList<string> GetSteps(){
			var steps = new List<string>();

			steps.Add ("INSERT INTO Arrangements (Name, Date) VALUES ('Curdin', '2015-01-26 00:00:00.000'), ('Remo', '2015-01-26 00:00:00.000'), ('Martin', '2015-01-27 00:00:00.000')");

			return steps;
		}
	}
}

