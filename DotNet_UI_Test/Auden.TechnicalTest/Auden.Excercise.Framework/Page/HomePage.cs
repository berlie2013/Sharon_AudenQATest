using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.PageElements;
using Framework.Webdriver;
using Framework.Common;


namespace Auden.Excercise.Pages
{
    /// <summary>
    /// HomePage methods
    /// </summary>
    public class HomePage: HomePageElements
    {
        /// <summary>
        /// The driver
        /// </summary>
        public Driver driver;

        public CommonMethods commonMethods;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        public HomePage(Driver driver)
        {
            this.driver = driver;
            this.commonMethods = new CommonMethods();
        }

        /// <summary>
        /// Navigates to login page.
        /// </summary>
        /// <param name="url">The URL.</param>
        public void LoadApplicationURL(string url)
        {
            this.driver.NavigateToUrl(commonMethods.GetAppConfigKeyValue(url));
        }

        public void GoToLoanPage()
        {
            this.driver.WaitForPageLoad(20);
            this.driver.ScrollToElement(this.btnApplyForLoan);
            this.driver.Click(this.btnApplyForLoan);
            this.driver.WaitForPageLoad(20);
        }
    }
}
