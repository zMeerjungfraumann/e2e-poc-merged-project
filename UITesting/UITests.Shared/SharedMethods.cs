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

        //Returns a AppiumElement. The search parameters are different for windows and android
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
            Task.Delay(300).Wait();
            switch (locatorType) {
                case LocatorType.ID: 
                    return (App is WindowsDriver) ?     App.FindElements(MobileBy.AccessibilityId(locatorValue))
                        :                               App.FindElements(MobileBy.Id(locatorValue));
                case LocatorType.TEXT:
                    return App.FindElements(By.XPath($"//*[@text='{locatorValue}']"));      // Only works for Android

                //var monthElement = App.FindElements(By.XPath($"//android.widget.TextView[@text='{monthToSelect}']"));

                default: throw new Exception($"Invalid locatorType '{locatorType}'");
            }
        }

        //Clicks on the generated back button. Unfortunately it only has a AutomationID on Windows. To click it on Android it searches with XPath, but it throws exception. So the exceptions must be ignored. 
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