namespace Framework.Webdriver
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Edge;
    using Auden.Excercise.Common;
    using System.Collections.Generic;
    using System;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    

    public class Driver
    {
        public Assertions assertions;

        public Driver()
        {
            this.assertions = new Assertions();
        }

        public IWebDriver WebDriver { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="browserType"></param>
        public void startBrowser(EnumValues.browsers browserType = EnumValues.browsers.chrome)
        {
            switch (browserType)
            {
                case EnumValues.browsers.chrome:
                    WebDriver = new ChromeDriver();
                    WebDriver.Manage().Window.Maximize();
                    break;

                case EnumValues.browsers.firefox:
                    WebDriver = new FirefoxDriver();
                    WebDriver.Manage().Window.Maximize();
                    break;

                case EnumValues.browsers.internetExplorer:
                    WebDriver = new InternetExplorerDriver();
                    WebDriver.Manage().Window.Maximize();
                    break;

                case EnumValues.browsers.edge:
                    WebDriver = new EdgeDriver();
                    WebDriver.Manage().Window.Maximize();
                    break;
            } 
        }

        /// <summary>
        /// Call Dispose() and safely end all browser sessions
        /// </summary>
        public void StopBrowser()
        {
            this.WebDriver.Quit();
        }


        /// <summary>
        /// Find element by locator
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public IWebElement FindElement(By locator)
        {            
            try
            {
               return this.WebDriver.FindElement(locator);
            }
            catch
            {
                return null;
            }            
        }
                       

        public void WaitForPageLoad(int time)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(time));
            var javascript = WebDriver as IJavaScriptExecutor;
            wait.Until((d) => ((IJavaScriptExecutor)this.WebDriver).ExecuteScript("return document.readyState").Equals("complete"));

        }


        public string GetText(string element)
        {
            try
            {
                return this.FindVisibleElement(element).Text;
            }
            catch
            {
                return null;
            }
        }

        public void Click(string element)
        {
            try
            {
                this.FindVisibleElement(element).Click();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }

        public void ClickAllVisibleElements(string element)
        {
            try
            {
                foreach (IWebElement elm in this.FindAllElementsByStringLocator(element))
                {
                    if (elm.Displayed)
                    {
                        elm.Click();
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        public void WaitForElementVisible(string element, int time)
        {
            var ticks = new TimeSpan(DateTime.Now.Ticks);
            double totalTime = this.ClockTime(ticks);
            while (this.FindVisibleElement(element) == null && totalTime <= time)
            {
                totalTime = Convert.ToInt32(this.ClockTime(ticks));
                if (totalTime >= time)
                {
                    assertions.AssertFail("Failed to find element " + element + " after " + totalTime + " seconds");
                }                
            }
        }

        public void MoveToElement(string element, int x= 0, int y= 0)
        {
            Actions action = new Actions(this.WebDriver);
            action.MoveToElement(this.FindVisibleElement(element), x, y).Click().Perform();
            
        }

        public void SetSliderValue(string slider, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                this.WebDriver.FindElement(By.XPath(slider)).SendKeys(Keys.ArrowRight);

            }
        }

        public void Wait(int timeInseconds)
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeInseconds);
        }


        public void WaitForElementEnabled(string element, int time)
        {
            var ticks = new TimeSpan(DateTime.Now.Ticks);
            double totalTime = this.ClockTime(ticks);
            while (this.FindEnabledElement(element) == null && totalTime <= time)
            {
                totalTime = Convert.ToInt32(this.ClockTime(ticks));
                if (totalTime >= time)
                {
                    assertions.AssertFail("Failed to find element " + element + " after " + totalTime + " seconds");
                }
            }
        }

        private double ClockTime(TimeSpan timeSpan)
        {
            var initialTimespan = new TimeSpan(DateTime.Now.Ticks);
            var newTimeSpan = timeSpan - initialTimespan;
            return Math.Abs(newTimeSpan.TotalSeconds);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public IWebElement FindVisibleElement(string element)
        {
            try
            {                
                ICollection<IWebElement> webElements = this.FindAllElementsByStringLocator(element);
                foreach(IWebElement webElement in webElements)
                {
                    if (webElement.Displayed)
                    {
                        return webElement;
                    }                   
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

        public bool IsElementVisisble(string element)
        {
            try
            {
                ICollection<IWebElement> webElements = this.FindAllElementsByStringLocator(element);
                foreach (IWebElement webElement in webElements)
                {
                    if (webElement.Displayed)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public IWebElement FindEnabledElement(string element)
        {
            try
            {
                ICollection<IWebElement> webElements = this.FindAllElementsByStringLocator(element);
                foreach (IWebElement webElement in webElements)
                {
                    if (webElement.Enabled)
                    {
                        return webElement;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }

            return null;
        }    

        /// <summary>
        /// Find all elements in the webpage
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Collection of all webelements</returns>
        public ICollection<IWebElement> FindAllElementsByStringLocator(string element)
        {
            try
            {
               if ( this.FindElement(By.Id(element)) != null)
                {
                    return this.WebDriver.FindElements(By.Id(element));
                }
               else if (this.FindElement(By.XPath(element)) != null)
                {
                    return this.WebDriver.FindElements(By.XPath(element));
                }
                else if (this.FindElement(By.ClassName(element)) != null)
                {
                    return this.WebDriver.FindElements(By.ClassName(element));
                }
                else if (this.FindElement(By.Name(element)) != null)
                {
                    return this.WebDriver.FindElements(By.Name(element));
                }
                else if (this.FindElement(By.LinkText(element)) != null)
                {
                    return this.WebDriver.FindElements(By.LinkText(element));
                }
                else if (this.WebDriver.FindElement(By.PartialLinkText(element)) != null)
                {
                    return this.WebDriver.FindElements(By.PartialLinkText(element));
                }
                else if (this.WebDriver.FindElement(By.TagName(element)) != null)
                {
                    return this.WebDriver.FindElements(By.TagName(element));
                }
                else if (this.WebDriver.FindElement(By.CssSelector(element)) != null)
                {
                    return this.WebDriver.FindElements(By.CssSelector(element));
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }


        public void MoveSliderToPercent(int percent, string sliderBarLocator)
        {
            IWebElement sliderBar = this.WebDriver.FindElement(By.XPath(sliderBarLocator));
            int width = sliderBar.Size.Width;
            Actions sliderAction = new Actions(this.WebDriver);
            sliderAction.ClickAndHold(sliderBar);
            sliderAction.MoveByOffset(percent, 0).Build().Perform();
            sliderAction.Release(sliderBar).Perform();
        }


        public void ScrollToElement(string locator)
        {
            this.WaitForPageLoad(10);
            this.WaitForElementVisible(locator, 10);
            IWebElement element = this.FindEnabledElement(locator);

            if (element != null)
            {
                IJavaScriptExecutor js = this.WebDriver as IJavaScriptExecutor;
                js.ExecuteScript("arguments[0].scrollIntoView(false);", element);
            }
            else
            {
                assertions.AssertFail("Unable to locate element to scroll to - locator: " + locator);
            }
        }

        public string GetAttributeValue(string elementLocator, string attributeName)
        {
            var element = this.FindVisibleElement(elementLocator);

            if (element != null)
            {
                return element.GetAttribute(attributeName);
            }

            return null;
        }

        
        public void SelectValueFromSlider(string locator, int amount)
        {            
            IWebElement slider = this.FindVisibleElement(locator);            
            double minValue = Double.Parse(slider.GetAttribute("min"));
            double maxValue = Double.Parse(slider.GetAttribute("max"));
            int sliderH = slider.Location.X;
            int sliderW = slider.Location.Y;        
            Actions action = new Actions(WebDriver);
            action.MoveToElement(slider, (int)(amount * sliderW / (maxValue - minValue)), sliderH / 2).Click().Build().Perform();
        }


    public void NavigateToUrl(string url)
        {
            this.WebDriver.Navigate().GoToUrl(url);
            this.WaitForPageLoad(20);
        }
    }
}
