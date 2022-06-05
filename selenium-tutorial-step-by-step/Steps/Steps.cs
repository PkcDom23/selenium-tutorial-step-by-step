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

        [Given(@"I am logged in")]
        public void IAmLoggedIn()
        {
            NavigateToUrlMethod("http://the-internet.herokuapp.com/login");
            EnterUsernameMethod("tomsmith");
            EnterPasswordMethod("SuperSecretPassword!");
            PressLoginButtonMethod();
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

        [When(@"I press the Logout button")]
        public void PressLogoutButton()
        {
            PressLogoutButtonMethod();
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
            var expectedMessage2 = "You logged out of the secure area!\r\n×";

            var actualMessage = loginPage.loginPageTopMessage.Text;
            
            if(expectedMessage == actualMessage)
            {
                Assert.Pass();
                Thread.Sleep(2000);
            }
            else if (expectedMessage2 == actualMessage)
            {
                Assert.Pass();
                Thread.Sleep(2000);
            }
            else
            {
                Assert.Fail("The actual text in the top element does not match any of the expected messages!\n Actual msg: " + actualMessage);                
            }
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

        private void PressLogoutButtonMethod()
        {
            var loginSuccessPage = new PageObjects.LoginSuccessPage(_driver);

            loginSuccessPage.logoutButton.Click();
        }
    }
}
