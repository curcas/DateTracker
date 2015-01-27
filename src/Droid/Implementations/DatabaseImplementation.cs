using System;

[assembly: Xamarin.Forms.Dependency (typeof (DateTracker.Droid.DatabaseImplementation))]
namespace DateTracker.Droid
{
	public class DatabaseImplementation : IDatabase
	{
		private static string DatabaseName = "Database.db3";

		public string Path {
			get {
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				return System.IO.Path.Combine(documentsPath, DatabaseName);
			}
		}
	}
}

