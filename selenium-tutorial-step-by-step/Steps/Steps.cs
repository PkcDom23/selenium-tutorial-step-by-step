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
            var usernameField = _driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/input"));

            usernameField.SendKeys(username);
        }

        [When(@"I enter password '(.*)'")]
        public void EnterPassword(string password)
        {
            var passwordField = _driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/div/input"));

            passwordField.SendKeys(password);
        }

        [When(@"I press the Login button")]
        public void PressLoginButton()
        {
            var loginButton = _driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/button/i"));

            loginButton.Click();
        }

        [Then(@"I see that I am logged in")]
        public void VerifyThatImLoggedIn()
        {
            var successMessage = _driver.FindElement(By.XPath("/html/body/div[1]/div/div"));

            Assert.AreEqual("You logged into a secure area!\r\n×", successMessage.Text);

            _driver.Quit();
        }
    }
}
