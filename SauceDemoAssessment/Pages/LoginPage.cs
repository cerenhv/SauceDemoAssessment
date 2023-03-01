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
    public class LoginPage : BasePage
    {
        public LoginPage(WebDriver driver) : base(driver) { }

        public LoginPage sendUsername(string username)
        {
            sendKeys(USERNAME_AREA, username);
            return this;
        }

        public LoginPage sendPassword(string pass)
        {
            sendKeys(PASSWORD_AREA, pass);
            return this;
        }

        public LoginPage LoginButton()
        {
            click(LOGIN_BUTTON);
            return this;
        }

        public LoginPage BurgerMenu()
        {
            click(BURGERMENU_BUTTON);
            return this;
        }

        public LoginPage LogoutButton()
        {
            click(LOGOUT_BUTTON);
            return this;
        }

        public LoginPage ErrorButton()
        {
            click(ERRORBUTTON);
            return this;
        }

        public LoginPage ClearField(By by)
        {
            findElement(by).Clear();
            return this;
        }

    }
}
