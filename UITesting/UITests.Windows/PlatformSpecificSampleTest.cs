using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace UITests;

public class PlatformSpecificSampleTest : SharedMethods
{
    public string directoryPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName; // C:\HTL\Diplomarbeit\e2e-poc-merged-project

    //************************
    //************swipeCarouselView-Test************
    [Test]
    public void b_swipeCarouselView()
    {
        //Action
        FindUIElement("btShowMonkeysID").Click();

        var carouselViewMonkeys = FindUIElement("cvMonkeysID");
        carouselViewMonkeys.Click();

        //Clicks the PageDown-Button 3 times
        for (int i = 0; i < 3; i++)
        {
            carouselViewMonkeys.SendKeys(Keys.PageDown);
            Thread.Sleep(300);
        }

        Thread.Sleep(1000);

        //Screenshot
        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\swipeCarouselView-Windows.png");

        //Assert

        // Returning to the menu
        FindUIElement("NavigationViewBackButton").Click();

    }
    //************************
    //************************



    //************************
    //************CheckboxAndSlider-Test************
    [Test]
    public void c_testSlider()
    {
        //Action
        FindUIElement("btShowCbSliderID").Click();

        IWebElement slider = FindUIElement("sl_slider");

        // Simulate pressing the right arrow key several times to move the slider
        //Actions does not work on windows
        for (int i = 0; i < 5; i++) // 5% of the slider
        {
            slider.SendKeys(Keys.ArrowRight);
        }

        //Screenshot
        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\slider-Windows.png");

        //Assert

        // Returning to the menu
        GoBack();
    }
    //************************
    //************************




    //************************
    //************CustomElementAndListView-Test************
    [Test]
    public void d_CustomElementAndListView()
    {
        //Action
        // Change to the Listview / Custom Element - Page
        FindUIElement("btShowLVCustomElementID").Click();
        // Click each Custom Button (Child-Element of the custom Element once)
        var customs = FindUIElements(LocatorType.ID,"customButton");

        foreach (var custom in customs)
        {
            Console.WriteLine("in for");
            custom.Click();
        }
        Console.WriteLine("Clicked all buttons");
        // AutomationIDs of the List-Items in hardcoded array
        var listItemAutomationIds = new[] { "item1", "item2", "item3" };
        // Searching for the matching Element for each ID and clicking it
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
            // Locating Elements by Text (All Child-Element-Buttons of the custom element are clicked again)
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

        //Screenshot
        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\customElementListView-Windows.png");

        //Assert


        //Returning to the menu
        GoBack();
    }
    //************************
    //************************




    //************************
    //************Picker-Test************
    [Test]
    public void e_testCombobox()
    {
        //Action
        FindUIElement("btShowComboboxID").Click();
        Thread.Sleep(1000);

        //clicks on the combobox, so all options are visible
        var picker = FindUIElement("MonthPickerID");
        picker.Click();

        Thread.Sleep(1000);

        Console.WriteLine("In Windows");

        //var item = App.FindElement(By.XPath("//ListItem[@Name='March']"));
        //Tries to find the Listitem with the name "December" and selects/clicks it
        var item = App.FindElement(MobileBy.Name("December"));
        item.Click();

        Thread.Sleep(1000);

        //Screenshot
        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\comboBox-Windows.png");

        //Assert
    }
    //************************
    //************************
}