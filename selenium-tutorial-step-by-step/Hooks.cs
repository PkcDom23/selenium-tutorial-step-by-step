using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace selenium_tutorial_step_by_step
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public void StartUp(ScenarioContext scenarioContext)
        {
            ChromeOptions options = new ChromeOptions();

            options.AddExcludedArgument("enable-automation");
            options.AddUserProfilePreference("credentials_enable_service", false);
            

            ChromeDriver _driver = new ChromeDriver(options);

            _driver.Manage().Window.Maximize();
            _driver.Manage().Cookies.DeleteAllCookies();

            scenarioContext["driver"] = _driver;
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            var driver = scenarioContext["driver"] as IWebDriver;

            driver.Quit();
        }
    }
}