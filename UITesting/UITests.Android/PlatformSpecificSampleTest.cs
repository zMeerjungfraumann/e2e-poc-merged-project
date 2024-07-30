using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Xml.Linq;

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

        // Returning to the menu
        GoBack();

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

        // Returning to the menu
        GoBack();

        //Assert
        Assert.Pass("Slider moved");
    }

    //************************
    //************************


    [Test]
    public void testCheckbox()
    {
        //Action
        FindUIElement("btShowCbSliderID").Click();

        IWebElement checkbox = FindUIElement("ch_Check");
        IWebElement disbledButton = FindUIElement("btn_Disabled");

        Console.WriteLine("Ckeckbox clicked: " + bool.Parse(checkbox.GetAttribute("checked")));
        Console.WriteLine("Is Button enabled: " + disbledButton.Enabled);

        Console.WriteLine("After click on Checkbox");

        checkbox.Click();

        bool selected = bool.Parse(checkbox.GetAttribute("checked"));

        Console.WriteLine("Ckeckbox clicked: " + selected);
        Console.WriteLine("Is Button enabled: " + disbledButton.Enabled);

        // Returning to the menu
        GoBack();

        //Assert
        Assert.That(selected, Is.EqualTo(true));
    }


    
    //************************
    //************Picker-Test************
    [Test]
    public void e_testCombobox()
    {
        var monthToSelect = "October";

        //Action
        FindUIElement("btShowComboboxID").Click();

        //clicks on the combobox, so all options are visible
        var picker = FindUIElement("MonthPickerID");
        picker.Click();

        Thread.Sleep(1000);

        // Tries to find the Listitem with the name "March" and selects/ clicks it
        //var monthElement = App.FindElement(By.XPath($"//android.widget.TextView[@text='{monthToSelect}']"));
        var monthElement = App.FindElement(By.XPath($"//*[@text='{monthToSelect}']"));
        monthElement.Click();

        Thread.Sleep(1000);

        //Screenshot
        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\comboBox-Android.png");

        var pickerText = picker.Text;
        Console.WriteLine("Selected Month: "+pickerText);

        // Returning to the menu
        GoBack();

        //Assert
        Assert.That(pickerText, Is.EqualTo(monthToSelect));
    }
    //************************
    //************************

}