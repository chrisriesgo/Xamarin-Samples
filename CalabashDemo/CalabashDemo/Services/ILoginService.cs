using System;
using System.Threading.Tasks;

namespace CalabashDemo.Services
{
	public interface ILoginService
	{
		Task<bool> IsLoggedIn();
		Task Login(string username, string pw);
		Task Logout();
	}
}

