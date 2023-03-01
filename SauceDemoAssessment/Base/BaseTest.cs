using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SauceDemoAssessment.Base
{
    [Binding]
    public class BaseTest
    {
        static WebDriver driver;

        [BeforeTestRun]
        public static void setUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-notifications");
            options.AddArguments("disable-popup-blocking");
            setWebDriver(new ChromeDriver(options));
            getWebDriver().Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public static WebDriver getWebDriver()
        {
            return driver;
        }

        public static void setWebDriver(WebDriver driver)
        {
            BaseTest.driver = driver;
        }

        [AfterTestRun]
        public static void TearDown()
        {
            getWebDriver().Quit();
            getWebDriver().Dispose();
        }
    }
}
