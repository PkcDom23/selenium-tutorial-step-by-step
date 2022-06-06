using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_tutorial_step_by_step.PageObjects
{
    class MyLoginTestLoginPage
    {
        // You will need new locators for elements on the geek page. Use correct 'using's and create your IWebElement locators

        // errors below will be resolved after you use correct packages
        private IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        // the element below is the one from the LoginPage.cs file, its here just so you see an example
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/form/div[1]/div/input")]
        public IWebElement userNameInput;
    }
}
