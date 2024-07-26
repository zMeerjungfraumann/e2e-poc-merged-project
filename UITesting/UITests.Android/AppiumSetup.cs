using NUnit.Framework;

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Diagnostics;

namespace UITests;

[SetUpFixture]
public class AppiumSetup
{
	private static AppiumDriver driver;
	public static AppiumDriver App => driver;
    private static AppiumOptions androidOptions;
    public string directoryPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName; // C:\HTL\Diplomarbeit\e2e-poc-merged-project


    [OneTimeSetUp]
	public void RunBeforeAnyTests()
	{
        Environment.SetEnvironmentVariable("ANDROID_HOME", @"C:\Program Files (x86)\Android\android-sdk");
        AppiumServerHelper.StartAppiumLocalServer();

        androidOptions = new AppiumOptions
        {
            AutomationName = "UiAutomator2",
            PlatformName = "Android",
            DeviceName = "emulator-5554",
            //DeviceName = "RF8NA18GT4M",
            App = @""+ directoryPath + @"\e2e-poc-merged-project\e2e-poc-merged-project\bin\Release\net8.0-android\com.companyname.e2epocmergedproject-Signed.apk",
        };

        StartEmulator();
        driver = new AndroidDriver(androidOptions);

        
    }

    [OneTimeTearDown]
	public void RunAfterAnyTests()
	{
		driver.Quit();
        driver.Dispose();

		// If an Appium server was started locally above, make sure we clean it up here
		AppiumServerHelper.DisposeAppiumLocalServer();
        StopEmulator();
	}

    private void StartEmulator()
    {
        androidOptions.AddAdditionalAppiumOption("avd", "pixel_5_-_api_33");
        //androidOptions.AddAdditionalAppiumOption("avd", "nexus_5_-_api_34");
    }

    private void StopEmulator()
    {
        Process.Start(@"C:\Program Files (x86)\Android\android-sdk\platform-tools\adb.exe", "-s emulator-5554 emu kill").WaitForExit();
    }
}