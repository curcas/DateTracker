using System;
using DynamicList.Portable.Entities;

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

		public ListEntryViewModel ()
		{
		}

		public ListEntry GetEntity(){
			return new ListEntry {
				Id = Id,
				Title = Title,
				Date = Date
			};
		}
	}
}

