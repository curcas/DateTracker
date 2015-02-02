using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DateTracker
{
	public class DeletableViewCell <T> : ViewCell
	{
		public DeletableViewCell ()
		{
			var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
			deleteAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
			deleteAction.Clicked += (sender, e) => {
				var item = (T)((MenuItem)sender).CommandParameter;
				var deletableView = GetDeletableView(this.ParentView);
				deletableView.Delete(item);
			};

			ContextActions.Add (deleteAction);
		}

		private DeletableView<T> GetDeletableView(VisualElement element){
			if (element is DeletableView<T>) {
				return element as DeletableView<T>;
			}

			return GetDeletableView (element.ParentView);
		}
	}

	public class UserCell<T> : DeletableViewCell<T>
	{
		public UserCell ()
		{
			var name = new Label ();
			name.SetBinding<Arrangement> (Label.TextProperty, c => c.Name);
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