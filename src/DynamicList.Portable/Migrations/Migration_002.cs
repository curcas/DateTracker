using System;
using System.Collections.Generic;

namespace DynamicList.Portable.Migrations
{
	public class Migration_002
	{
		public IList<string> GetSteps(){
			var steps = new List<string>();

			steps.Add (@"CREATE TABLE Properties (Id INTEGER PRIMARY KEY AUTOINCREMENT,
												Name TEXT NOT NULL,
												Type INTEGER NOT NULL)");
			return steps;
		}
	}
}

