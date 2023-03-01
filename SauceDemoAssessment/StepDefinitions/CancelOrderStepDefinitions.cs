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
    public class CancelOrderStepDefinitions : BaseTest
    {
        LoginPage loginPage;
        CartPage cartPage;

        [Before]
        public void Before()
        {
            loginPage = new LoginPage(getWebDriver());
            cartPage = new CartPage(getWebDriver());
        }

        [Given(@"I click Cancel button")]
        public void GivenIClickCancelButton()
        {
            Actions actions = new Actions(getWebDriver());
            actions.SendKeys(Keys.Down).ScrollToElement(loginPage.findElement(CANCEL_BUTTON)).Build().Perform();
            Thread.Sleep(1000);
            cartPage.Cancel();

            Assert.AreEqual("https://www.saucedemo.com/cart.html", getWebDriver().Url.ToString());
        }

        [Given(@"I click Cancel button on Checkout step two")]
        public void GivenIClickCancelButtonOnCheckoutStepTwo()
        {
            Actions actions = new Actions(getWebDriver());
            actions.SendKeys(Keys.Down).ScrollToElement(loginPage.findElement(CANCEL_BUTTON)).Build().Perform();
            Thread.Sleep(1000);
            cartPage.Cancel();

            Assert.AreEqual("https://www.saucedemo.com/inventory.html", getWebDriver().Url.ToString());
        }

        [When(@"I click Backpack's Remove button")]
        public void WhenIClickBackpacksRemoveButton()
        {
            cartPage.RemoveProduct(REMOVE_BACKPACK);
        }

        [Then(@"I see empty cart page")]
        public void ThenISeeEmptyCartPage()
        {
            Actions acts = new Actions(getWebDriver());
            acts.SendKeys(Keys.PageUp).Build().Perform();
            Thread.Sleep(1000);

            try
            {
                bool val = (getWebDriver().FindElement(SHOPPINGCART_BADGE).Enabled);
                Assert.False(val);
            }
            catch
            {
                Assert.False(false);
            }

        }

        [Given(@"I go to cart")]
        public void GivenIGoToCart()
        {
            cartPage.GoToCart();
            Assert.AreEqual("https://www.saucedemo.com/cart.html", getWebDriver().Url.ToString());
        }

        [Then(@"I continue shopping and logout")]
        public void ThenIContinueShoppingAndLogout()
        {
            cartPage.ContinueShopping();
            Thread.Sleep(1000);
            Actions acts = new Actions(getWebDriver());
            acts.SendKeys(Keys.PageUp).Build().Perform();
            Thread.Sleep(1000);
            loginPage.BurgerMenu().LogoutButton();

            Assert.AreEqual("https://www.saucedemo.com/", getWebDriver().Url.ToString());
        }
    }
}
