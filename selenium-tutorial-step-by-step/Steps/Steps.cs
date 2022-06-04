using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium_tutorial_step_by_step.Steps
{
    [Binding]
    class Steps
    {
        private IWebDriver _driver = new ChromeDriver();

        [Given(@"I go to the page 'http://the-internet.herokuapp.com/login'")]
        public void GoToTheLoginPage()
        {
            _driver.Url = "http://the-internet.herokuapp.com/login";
        }

        [When(@"I enter username 'tomsmith'")]
        public void EnterUsername()
        {
            var usernameField = _driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/input"));

            var username = "tomsmith";

            usernameField.SendKeys(username);

            Thread.Sleep(2000);
        }

        [When(@"I enter password 'SuperSecretPassword!'")]
        public void EnterPassword()
        {
            var passwordField = _driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/div/input"));

            var password = "SuperSecretPassword!";

            passwordField.SendKeys(password);

            Thread.Sleep(2000);
        }
    }
}
