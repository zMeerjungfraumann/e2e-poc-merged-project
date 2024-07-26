using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace UITests;

public class PlatformSpecificSampleTest : SharedMethods
{

    //************************
    //************swipeCarouselView-Test************
    [Test]
    public void b_swipeCarouselView()
    {
        FindUIElement("btShowMonkeysID").Click();
        
        var carouselViewMonkeys = FindUIElement("cvMonkeysID");
        carouselViewMonkeys.Click();

        for (int i = 0; i < 3; i++)
        {
            carouselViewMonkeys.SendKeys(Keys.PageDown);
            Thread.Sleep(300);

        }

        Thread.Sleep(1000);
        FindUIElement("NavigationViewBackButton").Click();

    }
    //************************
    //************************



    //************************
    //************CheckboxAndSlider-Test************
    [Test]
    public void c_testSlider()
    {

        FindUIElement("btShowCbSliderID").Click();

        IWebElement slider = FindUIElement("sl_slider");

        // Simulate pressing the right arrow key several times to move the slider
        for (int i = 0; i < 5; i++) // 50% of the slider
        {
            slider.SendKeys(Keys.ArrowRight);
        }

        GoBack();

        //Es gibt auch driver.TakeScreenshot().SaveAsFile(), doch dafür muss man eine neue Library importieren, deswegen haben wir driver.GetScreenshot().SaveAsFile() verwendet
        //App.GetScreenshot().SaveAsFile(@"C:\HTL\Diplomarbeit\e2e-poc-merged-project\Screenshots\Test.png");
    }
    //************************
    //************************




    //************************
    //************CustomElementAndListView-Test************
    [Test]
    public void d_CustomElementAndListView()
    {
        FindUIElement("btShowLVCustomElementID").Click();
        var customs = FindUIElements(LocatorType.ID,"customButton");

        foreach (var custom in customs)
        {
            Console.WriteLine("in for");
            custom.Click();
        }
        Console.WriteLine("Clicked all buttons");

        var listItemAutomationIds = new[] { "item1", "item2", "item3" };

        foreach (var id in listItemAutomationIds)
        {
            try
            {
                FindUIElement(id).Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"Element with content-desc {id} not found");
            }
        }
        try
        {
            var elements = FindUIElements(LocatorType.TEXT, "Click me!");
            foreach (var element in elements)
            {
                element.Click();
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error while attempting to locate Element via 'Name': " + exception.Message);
        }
        GoBack();
    }
    //************************
    //************************




    //************************
    //************Picker-Test************
    [Test]
    public void e_testCombobox()
    {
        FindUIElement("btShowComboboxID").Click();
        Thread.Sleep(1000);

        var picker = FindUIElement("MonthPickerID");
        picker.Click();

        Thread.Sleep(1000);

        Console.WriteLine("In Windows");

        //var item = App.FindElement(By.XPath("//ListItem[@Name='March']"));
        var item = App.FindElement(MobileBy.Name("December"));
        Console.WriteLine("After finding December");
        item.Click();
        Console.WriteLine("After clicking December");


        Thread.Sleep(1000);
    }
    //************************
    //************************

}