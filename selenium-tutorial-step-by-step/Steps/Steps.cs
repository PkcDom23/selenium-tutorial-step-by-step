using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace selenium_tutorial_step_by_step.Steps
{
    [Binding]
    class Steps
    {
        private IWebDriver _driver = new ChromeDriver();

        [Given(@"I go to the page '(.*)'")]
        public void GoToTheLoginPage(string url)
        {
            _driver.Url = url;
        }

        [When(@"I enter username '(.*)'")]
        public void EnterUsername(string username)
        {
            var loginPage = new PageObjects.LoginPage(_driver);

            loginPage.userNameInput.SendKeys(username);
        }

        [When(@"I enter password '(.*)'")]
        public void EnterPassword(string password)
        {
            var loginPage = new PageObjects.LoginPage(_driver);

            loginPage.passwordInput.SendKeys(password);
        }

        [When(@"I press the Login button")]
        public void PressLoginButton()
        {
            var loginPage = new PageObjects.LoginPage(_driver);

            loginPage.loginButton.Click();
        }

        [Then(@"I see that I am logged in")]
        public void VerifyThatImLoggedIn()
        {
            var loginPage = new PageObjects.LoginPage(_driver);

            Assert.AreEqual("You logged into a secure area!\r\n×", loginPage.successMessage.Text);

            _driver.Quit();
        }
    }
}
