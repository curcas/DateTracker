using System;
using DynamicList.Portable.ViewModels;
using DynamicList.Portable.Entities;
using Xamarin.Forms;
using DynamicList.Portable.Repositories;

namespace DynamicList.Portable.Views
{
	public class ListEntryView : ContentPage
	{
		private ListEntryViewModel _listEntryViewModel;

		public ListEntryView (ListEntry listEntry)
		{
			Model.Date = listEntry.Date;
			Model.Title = listEntry.Title;
			Model.Id = listEntry.Id;

			CreateLayout ();
		}

		private void CreateLayout(){
			BindingContext = Model;

			var titleLabel = new Label{
				Text = "Title"
			};

			var title = new Entry ();
			title.SetBinding (Entry.TextProperty, "Title");

			var saveButton = new Button {
				Text = "Save"
			};
			saveButton.Clicked += OnSave;

			Content = new StackLayout {
				Spacing = 20,
				Padding = 50,
				VerticalOptions = LayoutOptions.Center,
				Children = {
					titleLabel,
					title,
					saveButton
				}
			};

		}

		void OnSave (object sender, EventArgs e)
		{
			var repository = new ListEntryRepository ();
			repository.SaveOrUpdate (Model.GetEntity ());

			Navigation.PopAsync ();
		}

		private ListEntryViewModel Model
		{
			get { return _listEntryViewModel ?? (_listEntryViewModel = new ListEntryViewModel()); }
		}
	}
}

