﻿using System;
using Xamarin.Forms;

namespace DynamicList.Portable.Views
{
	public class MainView : TabbedPage
	{
		public MainView ()
		{
			Children.Add (new HomeView {
				Title = "Home"
			});
			Children.Add (new PropertyListView {
				Title = "Properties"
			});
		}
	}
}
