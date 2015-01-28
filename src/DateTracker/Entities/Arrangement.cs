using System;
using SQLite.Net.Attributes;

namespace DateTracker
{
	public class Arrangement
	{
		[AutoIncrement]
		public int Id {	get; set; }
		public DateTime Date { get; set; }
		public string Name { get; set; }
	}
}

