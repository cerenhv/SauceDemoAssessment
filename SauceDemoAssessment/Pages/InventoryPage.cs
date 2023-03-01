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
    public class InventoryPage : BasePage
    {
        public InventoryPage(WebDriver driver) : base(driver) { }

        public InventoryPage AddToCart(By by)
        {
            click(by);
            return this;
        }

        public InventoryPage GotoProductDetail(By by)
        {
            click(by);
            return this;
        }

        public string GetPrice(By by)
        {
            return getText(by);
        }
    }
}
