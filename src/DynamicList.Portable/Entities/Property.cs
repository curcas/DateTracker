using System;
using SQLite.Net.Attributes;

namespace DynamicList.Portable.Entities
{
	public class Property
	{
		[AutoIncrement]
		public int Id {	get; set; }
		public string Name { get; set; }
		public int Type { get; set; }
	}
}

