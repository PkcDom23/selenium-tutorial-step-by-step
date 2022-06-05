using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;

namespace selenium_tutorial_step_by_step.Steps
{
    [Binding]
    class Steps
    {
        private IWebDriver _driver;

        public Steps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["driver"] as IWebDriver;
        }

        [Given(@"I go to the page '(.*)'")]
        public void GoToTheLoginPage(string url)
        {
            NavigateToUrlMethod(url);
        }

        [When(@"I enter username '(.*)'")]
        public void EnterUsername(string username)
        {
            EnterUsernameMethod(username);
        }

        [When(@"I enter password '(.*)'")]
        public void EnterPassword(string password)
        {
            EnterPasswordMethod(password);
        }

        [When(@"I press the Login button")]
        public void PressLoginButton()
        {
            PressLoginButtonMethod();
        }

        [Then(@"I see that I am logged in")]
        public void VerifyThatImLoggedIn()
        {
            var loginPage = new PageObjects.LoginSuccessPage(_driver);

            var expectedMessage = "You logged into a secure area!\r\n×";
            var actualMessage = loginPage.successMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage);

            Thread.Sleep(2000);
        }

        [Then(@"I see that I am NOT logged in")]
        public void VerifyWrongCredentialsProvided()
        {
            var loginPage = new PageObjects.LoginPage(_driver);

            var expectedMessage = "Your username is invalid!\r\n×";
            var actualMessage = loginPage.loginFailedMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage);

            Thread.Sleep(2000);
        }

        private void NavigateToUrlMethod(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        private void EnterUsernameMethod(string username)
        {
            var loginPage = new PageObjects.LoginPage(_driver);

            loginPage.userNameInput.SendKeys(username);
        }

        private void EnterPasswordMethod(string password)
        {
            var loginPage = new PageObjects.LoginPage(_driver);

            loginPage.passwordInput.SendKeys(password);
        }

        private void PressLoginButtonMethod()
        {
            var loginPage = new PageObjects.LoginPage(_driver);

            loginPage.loginButton.Click();
        }
    }
}
