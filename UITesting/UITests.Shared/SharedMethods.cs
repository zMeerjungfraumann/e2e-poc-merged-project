using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Windows;

namespace UITests
{
    public enum LocatorType
    {
        ID,
        TEXT
    }
    public abstract class SharedMethods
    {
        protected AppiumDriver App => AppiumSetup.App;

        // This could also be an extension method to AppiumDriver if you prefer
        protected AppiumElement FindUIElement(string id)
        {
            Task.Delay(300).Wait();
            //Thread.Sleep(200);

            if (App is WindowsDriver)
            {
                return App.FindElement(MobileBy.AccessibilityId(id));
            }

            return App.FindElement(MobileBy.Id(id));
        }




        protected IReadOnlyCollection<AppiumElement> FindUIElements(LocatorType locatorType, String locatorValue)
        {
            switch (locatorType) {
                case LocatorType.ID: 
                    Task.Delay(300).Wait();
                    return (App is WindowsDriver) ?     App.FindElements(MobileBy.AccessibilityId(locatorValue))
                        :                               App.FindElements(MobileBy.Id(locatorValue));
                case LocatorType.TEXT:
                    return App.FindElements(By.XPath($"//*[@text='{locatorValue}']"));
                default: throw new Exception($"Invalid locatorType '{locatorType}'");
            }
        }


        protected void GoBack()
        {

            if (App is WindowsDriver)
            {

                FindUIElement("NavigationViewBackButton").Click();

            }
            else if (App is AndroidDriver)
            {

                try
                {
                    App.FindElement(By.XPath("//*[@content-desc='Nach oben']")).Click();

                }
                catch (Exception ignore)
                {
                    try
                    {
                        App.FindElement(By.XPath("//*[@content-desc='Navigate up']")).Click();
                    }
                    catch (Exception ignore2) { }

                }

            }
        }
    }
}