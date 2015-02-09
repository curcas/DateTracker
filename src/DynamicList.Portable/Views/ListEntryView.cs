using System;
using DynamicList.Portable.ViewModels;
using DynamicList.Portable.Entities;
using Xamarin.Forms;
using DynamicList.Portable.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace DynamicList.Portable.Views
{
	public class ListEntryView : ContentPage
	{
		private readonly PropertyRepository _PropertyRepository;
		private ListEntryViewModel _listEntryViewModel;

		private StackLayout Layout;

		public ListEntryView (ListEntry listEntry)
		{
			_PropertyRepository = new PropertyRepository ();

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

			var list = new List<View> ();
			list.Add (titleLabel);
			list.Add (title);



			Layout = new StackLayout {
				Spacing = 20,
				Padding = 50,
				VerticalOptions = LayoutOptions.Center,
				Children = {
					titleLabel,
					title
				}
			};

			GetControlls ();
			Layout.Children.Add (saveButton);

			Content = Layout;
		}

		private void GetControlls(){
			foreach (var property in _PropertyRepository.GetAll()) {
				var label = new Label {
					Text = property.Name
				};

				var input = new Entry ();
				//input.SetBinding (Entry.TextProperty, Model.Properties.Where(p => p.Name == property.Name));

				Layout.Children.Add (label);
				Layout.Children.Add (input);
			}
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

