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

    /*
	
	[Test]
	public void ClickCounterTest()
	{
		// Arrange
		// Find elements with the value of the AutomationId property
		var element = FindUIElement("CounterBtn");

		// Act
		element.Click();
		Task.Delay(500).Wait(); // Wait for the click to register and show up on the screenshot

		// Assert
		App.GetScreenshot().SaveAsFile($"{nameof(ClickCounterTest)}.png");
		Assert.That(element.Text, Is.EqualTo("Clicked 1 time"));
	}*/




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

    [Test]
    public void testCheckbox ()
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

        //HIER

        GoBack();
    }





    //************************
    //************Picker-Test************
    /*
    [Test]
    public void e_testCombobox()
    {
        findElementByAutomationID("btShowComboboxID").Click();

        var picker = findElementByAutomationID("MonthPickerID");
        picker.Click();

        Thread.Sleep(1000);

        if (platform.Equals("Windows"))
        {
            Console.WriteLine("In Windows");

            var item = driver.FindElement(By.XPath("//ListItem[@Name='March']"));
            item.Click();
        }
        else if (platform.Equals("Android"))
        {
            try
            {
                Console.WriteLine("In Android try");

                var item = driver.FindElement(By.XPath("//ListItem[@Name='March']"));
                item.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

        }


        Thread.Sleep(1000);


    }
    //************************
    //************************
    */



    private ReadOnlyCollection<AppiumElement> FindElementsbyAutomationId(string automationId)
    {
        Task.Delay(135).Wait();
        return
            (App is WindowsDriver) ? App.FindElements(By.XPath($"//*[@AutomationId='{automationId}']"))
            : (App is AndroidDriver) ? App.FindElements(By.Id(automationId))
            : throw new Exception($"Invalid platform detected: {App.GetType}");
    }
}