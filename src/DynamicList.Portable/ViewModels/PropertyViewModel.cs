using System;
using DynamicList.Portable.Entities;

namespace DynamicList.Portable.ViewModels
{
	public class PropertyViewModel
	{
		public int Id {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public int Type {
			get;
			set;
		}

		public Property GetEntity(){
			return new Property {
				Id = Id,
				Name = Name,
				Type = Type
			};
		}
	}
}

