using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;

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
			List.ItemTemplate = new DataTemplate (typeof(UserCell));

			DatePicker = new DatePicker ();
			DatePicker.HorizontalOptions = new LayoutOptions (LayoutAlignment.Fill, true);
			DatePicker.PropertyChanged += onDateChange;
			DatePicker.Date = DateTime.Now;

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

		void onDateChange (object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Date") {
				List.ItemsSource = new DateRepository ().GetByDate (DatePicker.Date);
			}
		}
	}
}

