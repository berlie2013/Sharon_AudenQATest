using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Framework.Webdriver;
using Framework.Pages;

namespace Auden.Excercise.UITests
{    
    public class SliderHook
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public Driver driver { get; set; }

        public Pages.HomePage homePage { get; set; }

        public LoansPage loansPage { get; set; }

        /// <summary>
        /// Befores the feature.
        /// </summary>      

        [BeforeScenario]
        public void BeforeFeature()
        {
            driver = new Driver();
            driver.startBrowser();
            homePage = new Pages.HomePage(this.driver);
            loansPage = new LoansPage(this.driver);            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.StopBrowser();
        }        
    }
}
