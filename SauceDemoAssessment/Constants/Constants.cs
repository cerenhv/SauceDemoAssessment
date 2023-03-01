using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoAssessment.Constants
{
    public class Constants
    {
        public static By USERNAME_AREA = By.Id("user-name");
        public static By PASSWORD_AREA = By.Id("password");
        public static By LOGIN_BUTTON = By.Id("login-button");
        public static By ADDCART_BACKPACK = By.Id("add-to-cart-sauce-labs-backpack");
        public static By REMOVE_BACKPACK = By.Id("remove-sauce-labs-backpack");
        public static By ADDCART_BIKELIGHT = By.Id("add-to-cart-sauce-labs-bike-light");
        public static By REMOVE_BIKELIGHT = By.Id("remove-sauce-labs-bike-light");
        public static By LINK_BACKPACK = By.Id("item_4_title_link");
        public static By LINK_BIKELIGHT = By.Id("item_0_title_link");
        public static By LINK_SHOPPINGCART = By.ClassName("shopping_cart_link");
        public static By SHOPPINGCART_BADGE = By.ClassName("shopping_cart_badge");
        public static By CONTINUESHOPPING_BUTTON = By.Id("continue-shopping");
        public static By CHECKOUT_BUTTON = By.Name("checkout");
        public static By BIKELIGHT_PRICE = By.XPath("//*[@id=\"inventory_container\"]/div/div[2]/div[2]/div[2]/div");
        public static By BACKPACK_PRICE = By.XPath("//*[@id=\"inventory_container\"]/div/div[1]/div[2]/div[2]/div");
        public static By FIRSTNAME = By.Id("first-name");
        public static By LASTNAME = By.Id("last-name");
        public static By POSTALCODE = By.Id("postal-code");
        public static By CANCEL_BUTTON = By.Id("cancel");
        public static By CONTINUE_BUTTON = By.Id("continue");
        public static By FINISH_BUTTON = By.Id("finish");
        public static By SUBTOTAL = By.ClassName("summary_subtotal_label");
        public static By TAX = By.ClassName("summary_tax_label");
        public static By TOTAL = By.ClassName("summary_total_label");
        public static By BACKHOME_BUTTON = By.Id("back-to-products");
        public static By BURGERMENU_BUTTON = By.Id("react-burger-menu-btn");
        public static By LOGOUT_BUTTON = By.Id("logout_sidebar_link");
        public static By ALLITEMS = By.Id("inventory_sidebar_link");
        public static By CROSSBUTTON = By.Id("react-burger-cross-btn");
        public static By ERRORMESSAGE = By.XPath("//*[@id=\"checkout_info_container\"]/div/form/div[1]/div[4]");
        public static By LOGINERRORMESSAGE = By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]");
        public static By ERRORBUTTON = By.ClassName("error-button");
    }
}
