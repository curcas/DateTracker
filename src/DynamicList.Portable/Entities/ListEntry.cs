using System;
using SQLite.Net.Attributes;

namespace DynamicList.Portable.Entities
{
	public class ListEntry
	{
		[AutoIncrement]
		public int Id {	get; set; }
		public DateTime Date { get; set; }
		public string Title { get; set; }

		public ListEntry(){
		}

		public ListEntry(DateTime date){
			Date = date;
		}
	}
}

