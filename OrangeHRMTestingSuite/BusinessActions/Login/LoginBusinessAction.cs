using OrangeHRMTestingSuite.Interfaces;
using OrangeHRMTestingSuite.PageObjects.Login;
using WebDriverClient.Interfaces;

namespace OrangeHRMTestingSuite.BusinessActions.Login
{
	internal class LoginBusinessAction
	{
		private readonly IWebDriverClient _webDriverClient;

		private LoginPage? _loginPage;

		public LoginBusinessAction(IWebDriverClient webDriverClient)
		{
			_webDriverClient = webDriverClient;
		}

		public void Login(IUser user)
		{
			if (user is null)
				throw new ArgumentNullException(nameof(user));

			_loginPage = new LoginPage(_webDriverClient);

			_loginPage.EnterUserName(user.UserName);
			_loginPage.EnterPassword(user.Password);
			_loginPage.ClickLoginButton();
		}
	}
}
