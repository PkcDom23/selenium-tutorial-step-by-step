using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace selenium_tutorial_step_by_step.PageObjects
{
    class LoginSuccessPage
    {
        private IWebDriver _driver;
        public LoginSuccessPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div")]
        public IWebElement successMessage;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/a")]
        public IWebElement logoutButton;
    }
}
