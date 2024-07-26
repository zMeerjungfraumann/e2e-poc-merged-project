using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System.ComponentModel;
using OpenQA.Selenium.Appium;

namespace UITests;

public class PlatformSpecificSampleTest : SharedMethods
{

    public string directoryPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName; // C:\HTL\Diplomarbeit\e2e-poc-merged-project

    

    ///************************
    //************swipeCarouselView-Test************
    [Test]
    public void b_swipeCarouselView()
    {
        //Action
        FindUIElement("btShowMonkeysID").Click();

        var carouselViewMonkeys = FindUIElement("cvMonkeysID");
        //define the swipe action
        var offset = (int)(carouselViewMonkeys.Size.Width * (-0.1));
        var actions = new Actions(App);

        //Does the swipe Action 4 times
        for (int i = 0; i < 4; i++)
        {
            Task.Delay(200).Wait();
            actions.MoveToElement(carouselViewMonkeys).ClickAndHold().MoveByOffset(offset, 0).Release().Perform();
        }

        //Screenshot
        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\swipeCarouselView-Android.png");

        //Assert

        // Returning to the menu
        GoBack();

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

        //Presses and holds the slider and moves right/left. After that it releases the button
        int sliderWidth = slider.Size.Width;
        int offset = (int)(sliderWidth * (-0.2));      //0.0 -> 50%    0.1 -> 60%       - 0.2 -> 30%      

        var actions = new Actions(App);
        actions.MoveToElement(slider)
               .ClickAndHold()
               .MoveByOffset(offset, 0)
               .Release()
               .Perform();

        //Screenshot
        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\slider-Android.png");

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
        var customs = FindUIElements(LocatorType.ID, "customButton");
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
        //There is also the methode driver.TakeScreenshot().SaveAsFile(), but to be able to use it you have to import a library, that's why we decided to use driver.GetScreenshot().SaveAsFile() instead
        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\customElementListView-Android.png");

        //Assert

        // Returning to the menu
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

        //clicks on the combobox, so all options are visible
        var picker = FindUIElement("MonthPickerID");
        picker.Click();

        Thread.Sleep(1000);

        try{
            try
            {
                //Tries to find the Listitem with the name "March" and selects/clicks it
                var item = App.FindElement(By.XPath("//ListItem[@Name='March']"));
                item.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        catch (Exception e){
            Console.WriteLine(e);

        }

        Thread.Sleep(1000);

        //Screenshot
        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\comboBox-Android.png");

        //Assert
    }
    //************************
    //************************
}