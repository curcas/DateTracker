using System;
using SQLite.Net;

namespace DateTracker
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

