using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace DateTracker
{
	public class HomeView : ContentPage
	{
		private Button BackButton;
		private Button ForwardButton;
		private DatePicker DatePicker;
		private ListView List;

		public HomeView ()
		{
			List = new ListView ();
			List.ItemsSource = new [] {
				"item 1", 
				"item 2"
			};

			DatePicker = new DatePicker ();
			DatePicker.Date = DateTime.Now;
			DatePicker.HorizontalOptions = new LayoutOptions (LayoutAlignment.Fill, true);
			DatePicker.PropertyChanged += delegate(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
				//todo list change
			};

			BackButton = new Button ();
			BackButton.Text = "<";
			BackButton.Clicked += delegate(object sender, EventArgs e) {
				DatePicker.Date = DatePicker.Date.AddDays(-1);
			};

			ForwardButton = new Button ();
			ForwardButton.Text = ">";
			ForwardButton.Clicked += delegate(object sender, EventArgs e) {
				DatePicker.Date = DatePicker.Date.AddDays(1);
			};

			Content = new StackLayout{
				Children = {
					new StackLayout{
						Orientation = StackOrientation.Horizontal,
						Children = {
							BackButton,
							DatePicker,
							ForwardButton
						}
					},
					List
				}
			};
		}
	}
}

