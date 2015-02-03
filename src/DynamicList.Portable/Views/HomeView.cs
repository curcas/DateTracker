using System;
using Xamarin.Forms;
using DynamicList.Portable.Entities;
using DynamicList.Portable.Repositories;
using DynamicList.Portable.Layouting;
using System.ComponentModel;

namespace DynamicList.Portable.Views
{
	public interface DeletableView<T>
	{
		void Delete (T item);
	}


	public class HomeView : ContentPage, DeletableView<ListEntry>
	{
		private Button BackButton;
		private Button ForwardButton;
		private DatePicker DatePicker;
		private ListView List;

		private readonly ListEntryRepository _ListEntryRepository;


		public HomeView ()
		{
			_ListEntryRepository = new ListEntryRepository ();


			List = new ListView ();
			List.ItemTemplate = new DataTemplate (typeof(UserCell<ListEntry>));
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
				List.ItemsSource = _ListEntryRepository.GetByDate (DatePicker.Date);
			}
		}

		public void Delete(ListEntry item){
			_ListEntryRepository.Delete (item.Id);
			List.ItemsSource = _ListEntryRepository.GetByDate (DatePicker.Date);
		}
	}
}

