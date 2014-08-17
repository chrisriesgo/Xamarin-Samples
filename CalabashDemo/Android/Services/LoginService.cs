using System;
using CalabashDemo.Services;
using CalabashDemo.Android.Services;
using Android.Content;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency (typeof (LoginService))]

namespace CalabashDemo.Android.Services
{
	public class LoginService : ILoginService
	{
		private const string SharedPreferencesFileName = "CalabashDemoSharedPreferences";
		private const string UserNameKey = "CalabashDemoUserName";
		private const string PwKey = "CalabashDemoPw";

		public async Task<bool> IsLoggedIn()
		{
			var context = Xamarin.Forms.Forms.Context;
			var preferences = context.GetSharedPreferences(SharedPreferencesFileName, FileCreationMode.Private);
			var user = preferences.GetString(UserNameKey, null);

			return !string.IsNullOrWhiteSpace(user);
		}

		public async Task Login(string username, string pw)
		{
			var context = Xamarin.Forms.Forms.Context;
			var preferences = context.GetSharedPreferences(SharedPreferencesFileName, FileCreationMode.Private);

			var editor = preferences.Edit();
			editor.Remove(UserNameKey);
			editor.PutString(UserNameKey, username);
			editor.PutString(PwKey, pw);
			editor.Commit();
		}

		public async Task Logout()
		{
			var context = Xamarin.Forms.Forms.Context;
			var preferences = context.GetSharedPreferences(SharedPreferencesFileName, FileCreationMode.Private);

			var editor = preferences.Edit();
			editor.Remove(UserNameKey);
			editor.Remove(PwKey);
			editor.Commit();
		}
	}
}

