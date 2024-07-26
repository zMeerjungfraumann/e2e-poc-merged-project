using NUnit.Framework;

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace UITests;

[SetUpFixture]
public class AppiumSetup
{
	private static AppiumDriver driver;
	public static AppiumDriver App => driver;
    public string directoryPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName; // C:\HTL\Diplomarbeit\e2e-poc-merged-project


    [OneTimeSetUp]
	public void RunBeforeAnyTests()
	{
		// If you started an Appium server manually, make sure to comment out the next line
		// This line starts a local Appium server for you as part of the test run
		AppiumServerHelper.StartAppiumLocalServer();

        AppiumOptions windowsOptions = new AppiumOptions
        {
            AutomationName = "windows",
            PlatformName = "Windows",

            App = @"" + directoryPath + @"\e2e-poc-merged-project\e2e-poc-merged-project\bin\Debug\net8.0-windows10.0.19041.0\win10-x64\e2e-poc-merged-project.exe",
        };

        windowsOptions.AddAdditionalAppiumOption("appWorkingDir", @"C:\HTL\Diplomarbeit\e2e-poc-merged-project\e2e-poc-merged-project\e2e-poc-merged-project\bin\Debug\net8.0-windows10.0.19041.0\win10-x64\");

        driver = new WindowsDriver(windowsOptions);
    }

	[OneTimeTearDown]
	public void RunAfterAnyTests()
	{
		driver.Quit();
		driver.Dispose();

		// If an Appium server was started locally above, make sure we clean it up here
		AppiumServerHelper.DisposeAppiumLocalServer();
	}
}