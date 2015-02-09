using System;
using DynamicList.Portable.Entities;
using System.Collections.Generic;

namespace DynamicList.Portable.ViewModels
{
	public class ListEntryViewModel
	{
		public int Id {
			get;
			set;
		}

		public string Title {
			get;
			set;
		}

		public DateTime Date {
			get;
			set;
		}

		public IList<Property> Properties{ get; set;}

		public ListEntry GetEntity(){
			return new ListEntry {
				Id = Id,
				Title = Title,
				Date = Date
			};
		}
	}
}

