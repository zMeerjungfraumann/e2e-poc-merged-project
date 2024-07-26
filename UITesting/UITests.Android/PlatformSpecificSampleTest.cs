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
        FindUIElement("btShowMonkeysID").Click();

        var carouselViewMonkeys = FindUIElement("cvMonkeysID");

        var offset = (int)(carouselViewMonkeys.Size.Width * (-0.1));
        var actions = new Actions(App);

        for (int i = 0; i < 4; i++)
        {
            //Console.WriteLine("in for (Android)");
            Task.Delay(200).Wait();
            actions.MoveToElement(carouselViewMonkeys).ClickAndHold().MoveByOffset(offset, 0).Release().Perform();
        }

        GoBack();
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
        int sliderWidth = slider.Size.Width;
        int offset = (int)(sliderWidth * (-0.2));      //0.0 -> 50%    0.1 -> 60%       - 0.2 -> 30%      

        var actions = new Actions(App);
        actions.MoveToElement(slider)
               .ClickAndHold()
               .MoveByOffset(offset, 0)
               .Release()
               .Perform();

        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\Test.png");

        GoBack();

        //Es gibt auch driver.TakeScreenshot().SaveAsFile(), doch dafür muss man eine neue Library importieren, deswegen haben wir driver.GetScreenshot().SaveAsFile() verwendet
    }
    //************************
    //************************

    [Test]
    public void d_CustomElementAndListView()
    {
        FindUIElement("btShowLVCustomElementID").Click();
        var customs = FindUIElements(LocatorType.ID, "customButton");

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
    //************Picker-Test************
    [Test]
    public void e_testCombobox()
    {
        FindUIElement("btShowComboboxID").Click();

        var picker = FindUIElement("MonthPickerID");
        picker.Click();

        Thread.Sleep(1000);

        try{
            Console.WriteLine("In Android try");

            //var item = App.FindElement(By.XPath("//ListItem[@Name='March']"));
            //var item = App.FindElement(MobileBy.Name("November"));
            
            try
            {
                Console.WriteLine("In Android try");

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
    }
    //************************
    //************************






}