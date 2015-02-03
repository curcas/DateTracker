using System;
using SQLite.Net.Attributes;

namespace DynamicList.Portable.Entities
{
	public class ListEntry
	{
		[AutoIncrement]
		public int Id {	get; set; }
		public DateTime Date { get; set; }
		public string Name { get; set; }
	}
}

