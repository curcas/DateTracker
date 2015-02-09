using System;
using Xamarin.Forms;
using DynamicList.Portable.Repositories;
using DynamicList.Portable.Entities;
using DynamicList.Portable.Layouting;

namespace DynamicList.Portable.Views
{
	public class PropertyListView : ContentPage, DeletableView<Property>
	{
		public ListView List;

		private readonly PropertyRepository _PropertyRepository;

		public PropertyListView ()
		{
			_PropertyRepository = new PropertyRepository ();

			List = new ListView ();
			List.ItemTemplate = new DataTemplate (typeof(UserCell<Property>));
			List.ItemSelected += onListItemSelected;

			var addButton = new Button ();
			addButton.Text = "Add Property";
			addButton.Clicked += OnAddClicked;

			Content = new StackLayout{
				Children = {
					List,
					addButton
				}
			};
		}

		protected override void OnAppearing ()
		{
			List.ItemsSource = _PropertyRepository.GetAll ();
		}

		void onListItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var view = new PropertyView (List.SelectedItem as Property);
			Navigation.PushAsync (view);
		}

		void OnAddClicked (object sender, EventArgs e)
		{
			var view = new PropertyView (new Property());
			Navigation.PushAsync (view);
		}

		public void Delete(Property item){
			_PropertyRepository.Delete (item.Id);
			List.ItemsSource = _PropertyRepository.GetAll ();
		}
	}
}

