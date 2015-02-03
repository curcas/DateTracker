using System;
using SQLite.Net;

namespace DynamicList.Portable.Core.Interfaces.Database
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
		bool Exists();
		void DropDatabase();
	}
}

