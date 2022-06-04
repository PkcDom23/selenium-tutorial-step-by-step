using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium_tutorial_step_by_step.Steps
{
    [Binding]
    class Steps
    {

        [Given(@"I go to the page 'http://the-internet.herokuapp.com/login'")]
        public void GoToTheLoginPage()
        {
            IWebDriver _driver = new ChromeDriver();

            _driver.Url = "http://the-internet.herokuapp.com/login";
        }
    }
}
