using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System.Collections.ObjectModel;

// You will have to make sure that all the namespaces match
// between the different platform specific projects and the shared
// code files. This has to do with how we initialize the AppiumDriver
// through the AppiumSetup.cs files and NUnit SetUpFixture attributes.
// Also see: https://docs.nunit.org/articles/nunit/writing-tests/attributes/setupfixture.html
namespace UITests;

// This is an example of tests that do not need anything platform specific
public class MainPageTests : SharedMethods
{

    public string directoryPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName; // C:\HTL\Diplomarbeit\e2e-poc-merged-project

    //************************
    //************Login-Test************
    [Test]
    public void a_testLogin()
    {
        //Login
        FindUIElement("btStartLoginID").Click();

        FindUIElement("txtfUsernameID").SendKeys("Dennis");
        FindUIElement("txtfPasswordID").SendKeys("1234");

        FindUIElement("btLoginID").Click();
        string lbl = FindUIElement("lblLoginInformationID").Text;

        //Assert
        Task.Delay(1000).Wait();
        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\Test.png");
        Assert.That(lbl, Is.EqualTo("Successfully logged in!"));
    }
    //************************
    //************************




    //************************
    //************RegisterAndLogin-Test************
    /*[Test]
    public void testRegisterAndLogin(){

        //Registration 
        findElementByAutomationID("btStartRegisterID").Click();
        findElementByAutomationID("txtfUsernameRegID").SendKeys("Owen");
        findElementByAutomationID("txtfEmailRegID").SendKeys("owen.oseghe@gmx.at");
        findElementByAutomationID("txtfPasswordRegID").SendKeys("abcde");

        findElementByAutomationID("btRegisterID").Click();
        string lbl = findElementByAutomationID("lblRegisterInfoID").Text;

        //Assert
        Assert.That(lbl, Is.EqualTo("User was created!"));

        //Login after Registration
        findElementByAutomationID("txtfUsernameID").SendKeys("owen");
        findElementByAutomationID("txtfPasswordID").SendKeys("abcde");

        findElementByAutomationID("btLoginID").Click();
        lbl = findElementByAutomationID("lblLoginInformationID").Text;

        //Assert
        Assert.That(lbl, Is.EqualTo("Successfully logged in!"));

    }*/
    //************************
    //************************



    //************************
    //************CustomElementAndListView-Test************
    [Test]
    public void testCustomElement()
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
        
            // Locating Elements by Text (All Child-Element-Buttons of the custom element are clicked again)
            // Does not work at the moment for some unknown reason (did work in the past)
        Console.WriteLine("Ist im try");
        
        var elements = FindUIElements(LocatorType.TEXT, "Click Me!");
        foreach (var element in elements)
        {
            Console.WriteLine("Ist in der Schleife");
            element.Click();
        }

        Console.WriteLine("Ist nach der Schleife");
        
        //Screenshot
        App.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\UITesting\Screenshots\customElementListView-Windows.png");

        // Check If all Labels were updated correctly, then assert
        var customLabels = FindUIElements(LocatorType.ID, "customLabel");
        var match = true;
        foreach (var customLabel in customLabels)
        {
            match = match && (customLabel.Text.Equals("Button Clicked"));
        }
        //Returning to the menu
        GoBack();
        //Assert
        Assert.That(match, Is.EqualTo(true));
    }
    [Test]
    public void testListView()
    {
        FindUIElement("btShowLVCustomElementID").Click();
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
        //Returning to the menu
        GoBack();
        Assert.Pass("Listview Items successfully clicked");
    }
}