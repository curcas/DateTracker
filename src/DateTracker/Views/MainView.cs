using System;
using Xamarin.Forms;

namespace DateTracker
{
	public class MainView : TabbedPage
	{
		public MainView ()
		{
			Children.Add(new HomeView{
				Title = "Home"
			});
			Children.Add(new HomeView{
				Title = "Home2"
			});
		}
	}
}

