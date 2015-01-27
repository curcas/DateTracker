using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DateTracker
{
	public class Entry{
		public int ID {
			get;
			set;
		}
		public string NAME {
			get;
			set;
		}
	}

	public class DateRepository
	{
		private ISQLite Database;

		public DateRepository ()
		{
			Database = DependencyService.Get<ISQLite> ();
			var con = Database.GetConnection ();

			//con.Execute ("CREATE TABLE TEST ( ID INT PRIMARY KEY     NOT NULL,  NAME           TEXT    NOT NULL )");
			//con.Execute ("INSERT INTO TEST(ID, NAME) VALUES (1, 'test'), (2, 'test1'), (3, 'test2')");

			//var result = con.ExecuteScalar<Entry> ("SELECT * FROM TEST");
		}


		public IList<Arrangement> GetByDate(DateTime date){
			var list = new List<Arrangement> ();

			Random r = new Random ();
			for (int i = 0; i < r.Next(0, 10); i++) {
				list.Add (new Arrangement{
					Id = i,
					Date = date,
					Name = i.ToString()
				});
			}

			return list;
		}
	}
}

