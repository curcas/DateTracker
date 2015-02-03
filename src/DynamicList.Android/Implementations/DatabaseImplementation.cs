using System;
using DynamicList.Portable.Core.Interfaces.Database;

[assembly: Xamarin.Forms.Dependency (typeof (DynamicList.Android.Implementations.DatabaseImplementation))]
namespace DynamicList.Android.Implementations
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

