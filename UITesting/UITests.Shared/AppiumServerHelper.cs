using OpenQA.Selenium.Appium.Service;

namespace UITests;

public static class AppiumServerHelper
{
	private static AppiumLocalService service;

	public static void StartAppiumLocalServer()
	{
		service = AppiumLocalService.BuildDefaultService();
		service.Start();
	}

	public static void DisposeAppiumLocalServer()
	{
		service.Dispose();
	}
}