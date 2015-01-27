using System;
using Xamarin.Forms;

namespace DateTracker
{
	public class UserCell : ViewCell
	{
		public UserCell ()
		{
			var name = new Label ();
			name.SetBinding (Label.TextProperty, "Name");
			name.HorizontalOptions = LayoutOptions.StartAndExpand;
			name.VerticalOptions = LayoutOptions.Center;

			var arrow = new Label ();
			arrow.Text = ">";
			arrow.VerticalOptions = LayoutOptions.Center;

			View = new StackLayout()
			{
				Padding = new Thickness(10, 0, 10, 0),
				Orientation = StackOrientation.Horizontal,
				Children = {
					name,
					arrow
				}
			};
		}
	}
}

