using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DateTracker
{
	public class DateRepository
	{
		private ISQLite Database;

		public DateRepository ()
		{
			Database = DependencyService.Get<ISQLite> ();
		}

		public IList<Arrangement> GetByDate(DateTime date){
			var con = Database.GetConnection ();
			return con.Query<Arrangement> ("SELECT * FROM Arrangements WHERE Date = ?", new object[]{ date.ToString ("yyyy-MM-dd 00:00:00.000") });
		}

		public void Delete(int id)
		{
			var con = Database.GetConnection ();
			con.Execute ("DELETE FROM Arrangements WHERE Id = ?", new object[]{ id });
		}
	}
}
