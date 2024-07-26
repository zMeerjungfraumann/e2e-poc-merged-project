using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.MultiTouch;
using NUnit.Framework.Internal;
using System.Xml.Linq;


namespace e2e_poc_merged_project_nunit_tests
{
    public class Tests
    {
        bool debug = true;
        public static AppiumDriver driver;
        private string platform = "Windows";
        private static AppiumLocalService service;
        public string directoryPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName; // C:\HTL\Diplomarbeit\e2e-poc-merged-project
        //private static WebDriverWait wait;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            platform= TestContext.Parameters.Get("Platform", string.Empty);
            Environment.SetEnvironmentVariable("ANDROID_HOME", @"C:\Program Files (x86)\Android\android-sdk");
            service = AppiumLocalService.BuildDefaultService();
            service.Start();

            if (platform.Equals("Windows")){
                AppiumOptions windowsOptions = new AppiumOptions
                {
                    AutomationName = "windows",
                    PlatformName = "Windows",

                    App = @"" + directoryPath + @"\e2e-poc-merged-project\bin\Debug\net8.0-windows10.0.19041.0\win10-x64\e2e-poc-merged-project.exe",
                };

                windowsOptions.AddAdditionalAppiumOption("appWorkingDir", @"" + directoryPath + @"\e2e-poc-merged-project\bin\Debug\net8.0-windows10.0.19041.0\win10-x64\");

                driver = new WindowsDriver(windowsOptions);

            }else if (platform.Equals("Android")){
                StartEmulator();

                AppiumOptions androidOptions = new AppiumOptions
                {
                    AutomationName = "UiAutomator2",
                    PlatformName = "Android",
                    DeviceName = "emulator-5554",
                    //DeviceName = "RF8NA18GT4M",
                    App = @""+ directoryPath + @"\e2e-poc-merged-project\bin\Release\net8.0-android\com.companyname.e2epocmergedproject-Signed.apk",
                };
                driver = new AndroidDriver(androidOptions);

            }else{
                throw new Exception("Unsupported platform");

            }

        }


        //************************
        //************Login-Test************
        [Test]
        public void a_testLogin(){

            Console.WriteLine("Directory: "+ Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName + "------");

            //Login
            findElementByAutomationID("btStartLoginID").Click();

            findElementByAutomationID("txtfUsernameID").SendKeys("Dennis");
            findElementByAutomationID("txtfPasswordID").SendKeys("1234");

            findElementByAutomationID("btLoginID").Click();
            string lbl = findElementByAutomationID("lblLoginInformationID").Text;

            //Assert
            Task.Delay(2000).Wait();
            driver.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\Screenshots\Test.png");
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
        //************swipeCarouselView-Test************
        [Test]
        public void b_swipeCarouselView(){

            if (platform.Equals("Android")){
                findElementByAutomationID("btShowMonkeysID").Click();

                var carouselViewMonkeys = findElementByAutomationID("cvMonkeysID");

                var offset = (int)(carouselViewMonkeys.Size.Width * (-0.1));
                var actions = new Actions(driver);

                for(int i = 0; i<4; i++)
                {
                    //Console.WriteLine("in for (Android)");
                    Task.Delay(200).Wait();
                    actions.MoveToElement(carouselViewMonkeys).ClickAndHold().MoveByOffset(offset, 0).Release().Perform();
                }

                clickBackButton();
            }
            else if (platform.Equals("Windows")){
                findElementByAutomationID("btShowMonkeysID").Click();

                var carouselViewMonkeys = findElementByAutomationID("cvMonkeysID");
                carouselViewMonkeys.Click();

                for (int i = 0; i < 3; i++){
                    carouselViewMonkeys.SendKeys(Keys.PageDown);
                    Thread.Sleep(300);

                }

                Thread.Sleep(1000);
                findElementByAutomationID("NavigationViewBackButton").Click();
            }
        }
        //************************
        //************************




        //************************
        //************CheckboxAndSlider-Test************
        [Test]
        public void c_testCheckboxSlider ()
        {
            
            findElementByAutomationID("btShowCbSliderID").Click();

            IWebElement slider = findElementByAutomationID("sl_slider");
            IWebElement checkbox = findElementByAutomationID("ch_Check");
            IWebElement disbledButton = findElementByAutomationID("btn_Disabled");

            if (platform.Equals("Windows"))
            {
                // Simulate pressing the right arrow key several times to move the slider
                for (int i = 0; i < 5; i++) // 50% of the slider
                {
                    slider.SendKeys(Keys.ArrowRight);
                }
            }
            else if (platform.Equals("Android"))
            {
                int sliderWidth = slider.Size.Width;
                int offset = (int)(sliderWidth * (-0.2));      //0.0 -> 50%    0.1 -> 60%       - 0.2 -> 30%      

                var actions = new Actions(driver);
                actions.MoveToElement(slider)
                       .ClickAndHold()
                       .MoveByOffset(offset, 0)
                       .Release()
                       .Perform();

            }

            Console.WriteLine("Ckeckbox clicked: " + checkbox.Selected);
            Console.WriteLine("Is Button enabled: " + disbledButton.Enabled);

            Console.WriteLine("After click on Checkbox");

            checkbox.Click();

            Console.WriteLine("Ckeckbox clicked: " + checkbox.Selected);
            Console.WriteLine("Is Button enabled: " + disbledButton.Enabled);

            //Go Back
            if (platform.Equals("Windows")){
                findElementByAutomationID("NavigationViewBackButton").Click();

            }else if (platform.Equals("Android")){
                clickBackButton();

            }

            //Es gibt auch driver.TakeScreenshot().SaveAsFile(), doch dafür muss man eine neue Library importieren, deswegen haben wir driver.GetScreenshot().SaveAsFile() verwendet
            driver.GetScreenshot().SaveAsFile(@"" + directoryPath + @"\Screenshots\Test.png");
        }
        //************************
        //************************




        //************************
        //************CheckboxAndSlider-Test************
        [Test]
        public void d_testCustomElementAndListView()
        {
           
            Console.WriteLine("in testCustomElement");

            findElementByAutomationID("btShowLVCustomElementID").Click();
            var customs = FindElementsbyAutomationId("customButton");
            
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
                    findElementByAutomationID(id).Click();
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Element with content-desc {id} not found");
                }
            }/*
            var listItemNames = new[] { "Test Item 1", "Test Item 2", "Test Item 3" };
            foreach (var name in listItemNames)
            {
                driver.FindElement(By.XPath($"//*[@Name='{name}']")).Click();
            }*/
            try
            {
                var elements = driver.FindElements(By.XPath("//*[@text='Click Me!']"));
                foreach(var element in elements)
                {
                    element.Click();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error while attempting to locate Element via 'Name': " + exception.Message);
            }
            
            //Go Back
            if (platform.Equals("Windows"))
            {
                findElementByAutomationID("NavigationViewBackButton").Click();

            }
            else if (platform.Equals("Android"))
            {
                clickBackButton();

            }

        }
        //************************
        //************************




        //************************
        //************Picker-Test************
        [Test]
        public void e_testCombobox()
        {
            findElementByAutomationID("btShowComboboxID").Click();

            var picker = findElementByAutomationID("MonthPickerID");
            picker.Click();

            Thread.Sleep(1000);

            if (platform.Equals("Windows")){
                Console.WriteLine("In Windows");

                var item = driver.FindElement(By.XPath("//ListItem[@Name='March']"));
                item.Click();
            } else if (platform.Equals("Android")){
                try
                {
                    Console.WriteLine("In Android try");

                    var item = driver.FindElement(By.XPath("//ListItem[@Name='March']"));
                    item.Click();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    
                }

            }

            
            Thread.Sleep(1000);


        }
        //************************
        //************************





        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            driver.Quit();
            driver.Dispose();
            service.Dispose();

            if (platform.Equals("Android"))
            {
                StopEmulator();
            }
        }


        private void StartEmulator()
        {
            Process.Start(@"C:\Program Files (x86)\Android\android-sdk\emulator\emulator.exe", "-avd pixel_5_-_api_33");
        }

        private void StopEmulator()
        {
            Process.Start(@"C:\Program Files (x86)\Android\android-sdk\platform-tools\adb.exe", "-s emulator-5554 emu kill").WaitForExit();
        }

        private IWebElement findElementByAutomationID (string automationId)
        {

            int tries = 0;

            while (tries < 50)
            {
                Task.Delay(135).Wait();

                try
                {
                    if (platform.Equals("Android"))
                    {
                        return driver.FindElement(By.Id(automationId));
                    }
                    else if (platform.Equals("Windows"))
                    {
                        string searchString = "//*[@AutomationId='" + automationId + "']";
                        return driver.FindElement(By.XPath(searchString));
                    }
                    else
                    {
                        throw new Exception("Unsupported platform");
                    }
                }catch (Exception e)
                {
                    if (e.Message.Equals("Unsupported platform")) 
                    {
                        throw new Exception("Unsupported platform");
                    }

                    else
                    {
                        tries++;
                    }
                }
            }
            throw new Exception("Unsupported platform or anything else went wrong");
        }


        private void clickBackButton()
        {
            try{
                driver.FindElement(By.XPath("//*[@content-desc='Nach oben']")).Click();

            }catch (Exception ignore){
                try{
                    driver.FindElement(By.XPath("//*[@content-desc='Navigate up']")).Click();
                }catch (Exception ignore2){}

            }
        }
        private ReadOnlyCollection<AppiumElement> FindElementsbyAutomationId(string automationId)
        {
            Task.Delay(135).Wait();
            return
                (platform.Equals("Windows")) ? driver.FindElements(By.XPath($"//*[@AutomationId='{automationId}']"))
                : (platform.Equals("Android")) ? driver.FindElements(By.Id(automationId))
                : throw new Exception($"Invalid platform detected: {platform}");
        }
    }
}