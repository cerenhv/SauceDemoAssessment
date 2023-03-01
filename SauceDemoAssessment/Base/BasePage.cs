using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoAssessment.Base
{
    public class BasePage
    {
        WebDriver driver;
        WebDriverWait wait;

        public BasePage(WebDriver dr)
        {
            this.driver = dr;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement findElement(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            return driver.FindElement(by);
        }

        public void sendKeys(By by, string text)
        {
            findElement(by).SendKeys(text);
        }

        public void click(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            findElement(by).Click();
        }

        public void hoverElement(By by)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(findElement(by)).Build().Perform();
        }

        public string getText(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            return findElement(by).Text;
        }

    }
}
