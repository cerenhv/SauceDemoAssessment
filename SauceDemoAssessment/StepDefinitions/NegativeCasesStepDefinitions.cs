using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using SauceDemoAssessment.Base;
using SauceDemoAssessment.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static SauceDemoAssessment.Constants.Constants;
using System.Threading;
using NUnit.Framework;

namespace SauceDemoAssessment.StepDefinitions
{
    [Binding]
    public class NegativeCasesStepDefinitions : BaseTest
    {
        LoginPage loginPage;
        CartPage cartPage;

        [Before]
        public void Before()
        {
            loginPage = new LoginPage(getWebDriver());
            cartPage = new CartPage(getWebDriver());
        }

        [Given(@"I fill the First Name field")]
        public void GivenIFillTheFirstNameField()
        {
            cartPage.sendFirstname();
        }

        [Given(@"I fill the Last Name field")]
        public void GivenIFillTheLastNameField()
        {
            cartPage.sendLastname();
        }

        [Given(@"I do not enter credentials")]
        public void GivenIDontEnterCredentials()
        {
            getWebDriver().Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage.sendUsername("").sendPassword("");
        }

        [Given(@"I enter invalid credentials")]
        public void GivenIEnterInvalidCredentials()
        {
            getWebDriver().Navigate().GoToUrl("https://www.saucedemo.com/");
            Thread.Sleep(1000);
            loginPage.sendUsername("tstuser").sendPassword("123");
        }

        [Given(@"I enter username")]
        public void GivenIEnterUsername()
        {
            getWebDriver().Navigate().GoToUrl("https://www.saucedemo.com/");
            Thread.Sleep(1000);
            loginPage.sendUsername("tstuser2");
        }

        [When(@"I click the Continue button")]
        public void WhenIClickTheContinueButton()
        {
            Actions actions = new Actions(getWebDriver());
            actions.SendKeys(Keys.Down).ScrollToElement(loginPage.findElement(CONTINUE_BUTTON)).Build().Perform();

            cartPage.Continue();
        }

        [When(@"I click Login button")]
        public void WhenIClickLoginButton()
        {
            loginPage.LoginButton();
            Thread.Sleep(1000);
        }

        [Then(@"I see '([^']*)' message")]
        public void ThenISeeErrorMessage(string message)
        {
            string errMessage = cartPage.GetErrorMessage(ERRORMESSAGE);
            Assert.AreEqual(message, errMessage);
        }

        [Then(@"I see login '([^']*)' message")]
        public void ThenISeeLoginErrorMessage(string message)
        {
            string errMessage = cartPage.GetErrorMessage(LOGINERRORMESSAGE);
            Assert.AreEqual(message, errMessage);
            Assert.AreEqual("https://www.saucedemo.com/", getWebDriver().Url.ToString());
        }

        [Then(@"I logout")]
        public void ThenILogout()
        {
            Actions acts = new Actions(getWebDriver());
            acts.SendKeys(Keys.PageUp).Build().Perform();
            Thread.Sleep(1000);
            loginPage.BurgerMenu().LogoutButton();

            Assert.AreEqual("https://www.saucedemo.com/", getWebDriver().Url.ToString());
        }

        [Then(@"I clear the fields and click error button")]
        public void ThenIClearTheFields()
        {
            loginPage.ErrorButton();
            Thread.Sleep(1000);
            loginPage.ClearField(USERNAME_AREA).ClearField(PASSWORD_AREA);
            Thread.Sleep(1000);
        }
    }
}
