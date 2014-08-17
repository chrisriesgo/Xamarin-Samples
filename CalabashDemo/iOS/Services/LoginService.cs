using System;
using CalabashDemo.Services;
using CalabashDemo.iOS.Services;
using MonoTouch.Foundation;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency (typeof (LoginService))]

namespace CalabashDemo.iOS.Services
{
	public class LoginService : ILoginService
	{
		public async Task<bool> IsLoggedIn()
		{
			var user = NSUserDefaults.StandardUserDefaults;
			var username = user.StringForKey("UserName");
			return !string.IsNullOrWhiteSpace(username);
		}

		public async Task Login(string username, string pw)
		{
			var user = NSUserDefaults.StandardUserDefaults;
			user.SetString(username, "UserName");
			user.SetString(pw, "Password");
			user.Synchronize();
		}

		public async Task Logout()
		{
			var user = NSUserDefaults.StandardUserDefaults;
			user.RemoveObject("UserName");
			user.RemoveObject("Password");
			user.Synchronize();
		}
	}
}

