using System;
using DynamicList.Portable.Core.Interfaces.Database;
using Xamarin.Forms;
using DynamicList.Portable.Entities;
using System.Collections.Generic;

namespace DynamicList.Portable.Repositories
{
	public class ListEntryRepository
	{
		private ISQLite Database;

		public ListEntryRepository ()
		{
			Database = DependencyService.Get<ISQLite> ();
		}

		public IList<ListEntry> GetByDate(DateTime date){
			var con = Database.GetConnection ();
			return con.Query<ListEntry> ("SELECT * FROM ListEntries WHERE Date = ?", new object[]{ date.ToString ("yyyy-MM-dd 00:00:00.000") });
		}

		public void SaveOrUpdate(ListEntry listEntry){
			var con = Database.GetConnection ();

			if (listEntry.Id == 0) {
				con.Execute ("INSERT INTO ListEntries (Title, Date) VALUES (?,?)", new object[]{ listEntry.Title, listEntry.Date.ToString ("yyyy-MM-dd 00:00:00.000") });
			} else {
				con.Execute ("UPDATE ListEntries SET Title = ?, Date = ? WHERE Id = ?", new object[]{ listEntry.Title, listEntry.Date.ToString ("yyyy-MM-dd 00:00:00.000"), listEntry.Id });
			}
		}

		public void Delete(int id)
		{
			var con = Database.GetConnection ();
			con.Execute ("DELETE FROM ListEntries WHERE Id = ?", new object[]{ id });
		}
	}
}

