using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_tutorial_step_by_step.Steps
{
    [Binding]
    class MyLoginPageTestSteps
    {
        // You can reuse steps from the "Steps.cs" class, or alter them. Or you can create new steps here.
        // You will need to use this class to create new steps for skip buttons though, so I recommend putting theme in this class

        // Errors below will be solved by using correct packages
        private IWebDriver _driver;

        public Steps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["driver"] as IWebDriver;
        }

        [When(@"I hit the skip button")]
        public void PressSkip()
        {
            // Step code here, its up to you if you want to have the code right in the step, or if you want to have a separate method that this step would call
        }
    }
}
