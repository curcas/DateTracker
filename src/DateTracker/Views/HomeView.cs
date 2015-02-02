using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace DateTracker
{
	public interface DeletableView<T>
	{
		void Delete (T item);
	}


	public class HomeView : ContentPage, DeletableView<Arrangement>
	{
		private Button BackButton;
		private Button ForwardButton;
		private DatePicker DatePicker;
		private ListView List;

		private readonly DateRepository _DateRepository;


		public HomeView ()
		{
			_DateRepository = new DateRepository ();


			List = new ListView ();
			List.ItemTemplate = new DataTemplate (typeof(UserCell<Arrangement>));
			List.ItemAppearing += async delegate(object sender, ItemVisibilityEventArgs e) {
				var x = sender;
			};

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
				List.ItemsSource = _DateRepository.GetByDate (DatePicker.Date);
			}
		}

		public void Delete(Arrangement item){
			_DateRepository.Delete (item.Id);
			List.ItemsSource = _DateRepository.GetByDate (DatePicker.Date);
		}
	}
}

