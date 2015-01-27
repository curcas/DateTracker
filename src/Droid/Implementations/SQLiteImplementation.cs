using System;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency (typeof (DateTracker.Droid.SQLiteImplementation))]
namespace DateTracker.Droid
{
	public class SQLiteImplementation : ISQLite
	{
		public SQLite.Net.SQLiteConnection GetConnection ()
		{
			var path = DependencyService.Get<IDatabase> ().Path;

			var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			var conn = new SQLite.Net.SQLiteConnection(plat, path);

			return conn;
		}
	}
}

