using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using CalabashDemo.Services;

namespace CalabashDemo.Pages
{
	public class LoginPage : ContentPage
	{
		private readonly ILoginService _loginService;
		private readonly Entry _username;
		private readonly Entry _pw;
		private readonly Button _button;
		private readonly ActivityIndicator _activityIndicator;

		private bool CanLogIn
		{
			get 
			{
				return !string.IsNullOrWhiteSpace(_username.Text) && !string.IsNullOrWhiteSpace(_pw.Text);
			}
		}

		public LoginPage()
		{
			BindingContext = this;
			_loginService = DependencyService.Get<ILoginService>();

			Title = "Login";
			BackgroundColor = Color.FromHex("ff7DC6CB");

			_username = new Entry { Placeholder = "Email Address", WidthRequest = 250 };
			_pw = new Entry { Placeholder = "Password", WidthRequest = 250, IsPassword = true };
			_button = new Button { Text = "Log In" };

			_activityIndicator = new ActivityIndicator();
			_activityIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");
			_activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");

			_button.Clicked += async (sender, e) =>
			{
				if (!CanLogIn) return;

				_button.Text = "Logging In...";
				IsBusy = true;

				_username.Unfocus(); _pw.Unfocus();
				await _loginService.Login(_username.Text, _pw.Text);
				await Task.Delay(3000); // Simulate API call

				IsBusy = false;
				Navigation.PopModalAsync();
			};

			var loginStack = new StackLayout {
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = { _button, _activityIndicator }
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { _username, _pw, loginStack }
			};
		}
	}

}

