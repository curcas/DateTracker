using System;
using System.Collections.Generic;
using Xamarin.Forms;
using DynamicList.Portable.Core.Interfaces.Database;

namespace DynamicList.Portable.Migrations
{
	public class MigrationHelper
	{
		private readonly Dictionary<int, IList<string>> Migrations;

		public MigrationHelper ()
		{
			Migrations = new Dictionary<int, IList<string>> ();
			Migrations.Add (1, new Migration_001 ().GetSteps ());
			Migrations.Add (2, new Migration_002 ().GetSteps ());
		}

		public void Migrate(){
			var database = DependencyService.Get<ISQLite> ();
			SQLite.Net.SQLiteConnection connection = null;

			if (!database.Exists ()) {
				connection = database.GetConnection ();

				connection.BeginTransaction ();
				connection.Execute (@"CREATE TABLE DBVersion (Version INT NOT NULL,
										ExecutionTime TEXT NOT NULL)");
				connection.Execute ("INSERT INTO DBVersion (Version, ExecutionTime) VALUES (?,?)", new object[]{ 0, DateTime.Now });
				connection.Commit ();
			}

			if (connection == null) {
				connection = database.GetConnection ();
			}

			foreach (var migration in Migrations) {
				int currentVersion = connection.ExecuteScalar<int> ("SELECT Version FROM DBVersion ORDER BY Version DESC LIMIT 1");

				if (migration.Key == (currentVersion + 1)) {
					connection.BeginTransaction ();

					foreach (var step in migration.Value) {
						connection.Execute (step);
					}

					connection.Execute ("INSERT INTO DBVersion (Version, ExecutionTime) VALUES (?,?)", new object[]{ migration.Key, DateTime.Now });
					connection.Commit ();
				}
			}
		}
	}
}

