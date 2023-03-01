using OpenQA.Selenium;
using SauceDemoAssessment.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SauceDemoAssessment.Constants.Constants;

namespace SauceDemoAssessment.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(WebDriver driver) : base(driver) { }

        public CartPage GoToCart()
        {
            click(LINK_SHOPPINGCART);
            return this;
        }

        public CartPage Checkout()
        {
            click(CHECKOUT_BUTTON);
            return this;
        }

        public CartPage Continue()
        {
            click(CONTINUE_BUTTON);
            return this;
        }

        public CartPage ContinueShopping()
        {
            click(CONTINUESHOPPING_BUTTON);
            return this;
        }

        public CartPage Finish()
        {
            click(FINISH_BUTTON);
            return this;
        }

        public CartPage Cancel()
        {
            click(CANCEL_BUTTON);
            return this;
        }

        public CartPage BackHome()
        {
            click(BACKHOME_BUTTON);
            return this;
        }

        public CartPage RemoveProduct(By by)
        {
            click(by);
            return this;
        }

        public CartPage sendFirstname()
        {
            sendKeys(FIRSTNAME, "test name");
            return this;
        }

        public CartPage sendLastname()
        {
            sendKeys(LASTNAME, "test last");
            return this;
        }

        public CartPage sendPostalCode()
        {
            sendKeys(POSTALCODE, "12345");
            return this;
        }

        public string GetCartQuantity()
        {
            return getText(SHOPPINGCART_BADGE);
        }

        public string GetErrorMessage(By by)
        {
            return getText(by);
        }

    }
}
