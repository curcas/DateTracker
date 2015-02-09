using System;
using DynamicList.Portable.Core.Interfaces.Database;
using Xamarin.Forms;
using System.Collections.Generic;
using DynamicList.Portable.Entities;

namespace DynamicList.Portable.Repositories
{
	public class PropertyRepository
	{
		private ISQLite Database;

		public PropertyRepository ()
		{
			Database = DependencyService.Get<ISQLite> ();
		}

		public IList<Property> GetAll(){
			var con = Database.GetConnection ();
			return con.Query<Property> ("SELECT * FROM Properties", new object[]{ });
		}

		public void SaveOrUpdate(Property property){
			var con = Database.GetConnection ();

			if (property.Id == 0) {
				con.Execute ("INSERT INTO Properties (Name, Type) VALUES (?,?)", new object[]{ property.Name, property.Type });
			} else {
				con.Execute ("UPDATE Properties SET Name = ?, Type = ? WHERE Id = ?", new object[]{ property.Name, property.Type, property.Id });
			}
		}

		public void Delete(int id)
		{
			var con = Database.GetConnection ();
			con.Execute ("DELETE FROM Properties WHERE Id = ?", new object[]{ id });
		}
	}
}
