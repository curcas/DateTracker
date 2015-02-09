using System;
using DynamicList.Portable.ViewModels;
using DynamicList.Portable.Entities;
using Xamarin.Forms;
using DynamicList.Portable.Repositories;

namespace DynamicList.Portable.Views
{
	public class PropertyView : ContentPage
	{
		private PropertyViewModel _PropertyViewModel;

		public PropertyView (Property property)
		{
			Model.Name = property.Name;
			Model.Type = property.Type;
			Model.Id = property.Id;

			CreateLayout ();
		}

		private void CreateLayout(){
			BindingContext = Model;

			var nameLabel = new Label{
				Text = "Name"
			};

			var name = new Entry ();
			name.SetBinding (Entry.TextProperty, "Name");

			var typeLabel = new Label{
				Text = "Name"
			};

			var type = new Entry ();
			type.SetBinding (Entry.TextProperty, "Type");

			var saveButton = new Button {
				Text = "Save"
			};
			saveButton.Clicked += OnSave;

			Content = new StackLayout {
				Spacing = 20,
				Padding = 50,
				VerticalOptions = LayoutOptions.Center,
				Children = {
					nameLabel,
					name,
					typeLabel,
					type,
					saveButton
				}
			};

		}

		void OnSave (object sender, EventArgs e)
		{
			var repository = new PropertyRepository ();
			repository.SaveOrUpdate (Model.GetEntity ());

			Navigation.PopAsync ();
		}

		private PropertyViewModel Model
		{
			get { return _PropertyViewModel ?? (_PropertyViewModel = new PropertyViewModel()); }
		}
	}
}

