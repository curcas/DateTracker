using System;
using System.Collections.Generic;

namespace DynamicList.Portable.Migrations
{
	public class Migration_001
	{
		public IList<string> GetSteps(){
			var steps = new List<string>();

			steps.Add (@"CREATE TABLE ListEntries (Id INTEGER PRIMARY KEY AUTOINCREMENT,
												Name TEXT NOT NULL,
												Date TEXT NOT NULL)");
			return steps;
		}
	}
}

