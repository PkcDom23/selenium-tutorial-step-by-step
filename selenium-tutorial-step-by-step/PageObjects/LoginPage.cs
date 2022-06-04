using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace selenium_tutorial_step_by_step.PageObjects
{
    class LoginPage
    {
        private IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/form/div[1]/div/input")]
        public IWebElement userNameInput;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/form/div[2]/div/input")]
        public IWebElement passwordInput;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/form/button/i")]
        public IWebElement loginButton;
    }
}
