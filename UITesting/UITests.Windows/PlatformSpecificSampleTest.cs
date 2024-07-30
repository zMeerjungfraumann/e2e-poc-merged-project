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
            //Die clickAndHold Action geht auf Windows nicht, da sonst eine Exception geworfen wird
            carouselViewMonkeys.SendKeys(Keys.PageDown);
            Thread.Sleep(300);
        }

        Thread.Sleep(1000);

        //Screenshot
        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\swipeCarouselView-Windows.png");

        // Returning to the menu
        FindUIElement("NavigationViewBackButton").Click();

        //Assert
        //Keinen Weg gefunden, um zu sehen welches Element im CarouselView angezeigt wird.

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
            //Die clickAndHold Action geht auf Windows nicht, da sonst eine Exception geworfen wird
            slider.SendKeys(Keys.ArrowRight);
        }

        //Screenshot
        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\slider-Windows.png");

        // Returning to the menu
        GoBack();

        //Assert
    }
    //************************
    //************************

    [Test]
    public void testCheckbox()
    {
        FindUIElement("btShowCbSliderID").Click();

        IWebElement checkbox = FindUIElement("ch_Check");
        IWebElement disbledButton = FindUIElement("btn_Disabled");

        Console.WriteLine("Ckeckbox clicked: " + checkbox.Selected);
        Console.WriteLine("Is Button enabled: " + disbledButton.Enabled);

        Console.WriteLine("After click on Checkbox");

        checkbox.Click();

        Console.WriteLine("Ckeckbox clicked: " + checkbox.Selected);
        Console.WriteLine("Is Button enabled: " + disbledButton.Enabled);

        // Returning to the menu
        GoBack();

        //Assert
        Assert.That(checkbox.Selected, Is.EqualTo(true));
    }

    //************************
    //************Picker-Test************
    [Test]
    public void e_testCombobox()
    {
        var monthToSelect = "December";

        //Action
        FindUIElement("btShowComboboxID").Click();
        Thread.Sleep(1000);

        //clicks on the combobox, so all options are visible
        var picker = FindUIElement("MonthPickerID");
        picker.Click();

        Thread.Sleep(1000);

        //Tries to find the Listitem with the name "December" and selects/clicks it
        var item = App.FindElement(MobileBy.Name(monthToSelect));
        item.Click();

        Thread.Sleep(1000);

        //Screenshot
        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\comboBox-Windows.png");

        var pickerText = picker.Text;
        Console.WriteLine("Selected Month: " + pickerText);

        //Returning to the menu
        GoBack();

        //Assert
        Assert.That(pickerText, Is.EqualTo(monthToSelect));
    }
    //************************
    //************************
}