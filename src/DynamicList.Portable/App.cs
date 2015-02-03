using System;
using Xamarin.Forms;
using DynamicList.Portable.Views;
using DynamicList.Portable.Core.Interfaces.Database;
using DynamicList.Portable.Migrations;

namespace DynamicList.Portable
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new MainView ();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
			DependencyService.Get<ISQLite> ().DropDatabase ();
			var migrationHelper = new MigrationHelper ();
			migrationHelper.Migrate ();
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

