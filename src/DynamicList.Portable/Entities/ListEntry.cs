using System;
using SQLite.Net.Attributes;
using System.Collections.Generic;

namespace DynamicList.Portable.Entities
{
	public class ListEntry
	{
		[AutoIncrement]
		public int Id {	get; set; }
		public DateTime Date { get; set; }
		public string Title { get; set; }
		public IList<Property> Properties {	get; set; }

		public ListEntry(){
		}

		public ListEntry(DateTime date){
			Date = date;
		}
	}
}

