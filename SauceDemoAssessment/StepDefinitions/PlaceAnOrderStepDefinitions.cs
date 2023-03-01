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
using NUnit.Framework;
using System.Threading;

namespace SauceDemoAssessment.StepDefinitions
{
    [Binding]
    public class PlaceAnOrderStepDefinitions : BaseTest
    {
        LoginPage loginPage;
        InventoryPage inventoryPage;
        CartPage cartPage;

        [Before]
        public void Before()
        {
            loginPage = new LoginPage(getWebDriver());
            inventoryPage = new InventoryPage(getWebDriver());
            cartPage = new CartPage(getWebDriver());
        }

        [Given(@"I login to Saucedemo\.com")]
        public void GivenILoginToSaucedemoCom()
        {
            loginPage.sendUsername("standard_user").sendPassword("secret_sauce").LoginButton();
        }

        [Given(@"I add the Backpack product to cart")]
        public void GivenIAddTheBackpackProductToCart()
        {
            inventoryPage.AddToCart(ADDCART_BACKPACK);
            Assert.AreEqual("1", cartPage.GetCartQuantity().ToString());
        }

        [Given(@"I go to the Shopping Cart and Checkout")]
        public void GivenIGoToTheShoppingCartAndCheckout()
        {
            cartPage.GoToCart().Checkout();
            Assert.AreEqual("https://www.saucedemo.com/checkout-step-one.html", getWebDriver().Url.ToString());
        }

        [Given(@"I fill the informations and Continue")]
        public void GivenIFillTheİnformationsAndContinue()
        {
            cartPage.sendFirstname().sendLastname().sendPostalCode();
            Thread.Sleep(1000);
            Actions actions = new Actions(getWebDriver());
            actions.SendKeys(Keys.Down).ScrollToElement(loginPage.findElement(CONTINUE_BUTTON)).Build().Perform();
            Thread.Sleep(1000);
            cartPage.Continue();
        }

        [When(@"I click the Finish button after check the total amount")]
        public void WhenIClickTheFinishButtonAfterCheckTheTotalAmount()
        {
            Actions actions = new Actions(getWebDriver());
            actions.SendKeys(Keys.Down).ScrollToElement(cartPage.findElement(FINISH_BUTTON)).Build().Perform();

            string subtotalPriceText = inventoryPage.GetPrice(SUBTOTAL);
            string taxPriceText = inventoryPage.GetPrice(TAX);
            string totalPriceText = inventoryPage.GetPrice(TOTAL);

            decimal subTotal = Convert.ToDecimal(subtotalPriceText.Split('$')[1]);
            decimal tax = Convert.ToDecimal(taxPriceText.Split('$')[1]);
            decimal total = Convert.ToDecimal(totalPriceText.Split('$')[1]);

            Assert.AreEqual((subTotal + tax), total);

            cartPage.Finish();

        }

        [Then(@"I see the Checkout complete page")]
        public void ThenISeeTheCheckoutCompletePage()
        {
            Assert.AreEqual("https://www.saucedemo.com/checkout-complete.html", getWebDriver().Url.ToString());
        }

        [Then(@"I back to home and logout")]
        public void ThenIBackToHomeAndLogout()
        {
            cartPage.BackHome();
            Thread.Sleep(1000);
            Actions acts = new Actions(getWebDriver());
            acts.SendKeys(Keys.PageUp).Build().Perform();
            Thread.Sleep(1000);
            loginPage.BurgerMenu().LogoutButton();

            Assert.AreEqual("https://www.saucedemo.com/", getWebDriver().Url.ToString());
        }

        [Given(@"I go to Bike Light detail page and add product to cart")]
        public void GivenIGoToBikeLightDetailPageAndAddProductToCart()
        {
            inventoryPage.GotoProductDetail(LINK_BIKELIGHT);
            Thread.Sleep(2000);
            inventoryPage.AddToCart(ADDCART_BIKELIGHT);
        }
    }
}
