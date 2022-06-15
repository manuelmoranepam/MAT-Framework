using OrangeHRMTestingSuite.Interfaces;
using OrangeHRMTestingSuite.PageObjects.MyInfo;
using WebDriverClient.Interfaces;

namespace OrangeHRMTestingSuite.BusinessActions.MyInfo
{
	internal class MyInfoBusinessAction
	{
		private readonly IWebDriverClient _webDriverClient;

		private MyInfoPage? _myInfoPage;

		public MyInfoBusinessAction(IWebDriverClient webDriverClient)
		{
			_webDriverClient = webDriverClient;
		}

		public bool IsEditButtonDisplayed()
		{
			_myInfoPage = new MyInfoPage(_webDriverClient);

			var isDisplayed = _myInfoPage.IsEditButtonDisplayed();

			return isDisplayed;
		}

		public void EditMyInfoForm()
		{
			_myInfoPage = new MyInfoPage(_webDriverClient);

			_myInfoPage.ClickEditButton();
		}

		public void FillMyInfoForm(IUser user)
		{
			if (user is null)
				throw new ArgumentNullException(nameof(user));

			_myInfoPage = new MyInfoPage(_webDriverClient);

			//TODO: Implement methods to fill form
		}

		public bool IsSaveButtonDisplayed()
		{
			_myInfoPage = new MyInfoPage(_webDriverClient);

			var isDisplayed = _myInfoPage.IsSaveButtonDisplayed();

			return isDisplayed;
		}

		public void SaveMyInfoForm()
		{
			_myInfoPage = new MyInfoPage(_webDriverClient);

			_myInfoPage.ClickSaveButton();
		}
	}
}
