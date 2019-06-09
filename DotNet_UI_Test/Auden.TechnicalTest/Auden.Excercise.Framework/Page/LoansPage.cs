using System;
using Framework.PageElements;
using Framework.Webdriver;
using NUnit.Framework;
using Auden.Excercise.Common;

namespace Framework.Pages
{
   
    public class LoansPage: LoanPageElements
    {
        /// <summary>
        /// The driver
        /// </summary>
        public Driver driver;

        
        /// <summary>
        /// Initializes a new instance of the <see cref="LoansPage"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        public LoansPage(Driver driver)
        {
            this.driver = driver;
        }

        public void WaitForPageLoad()
        {
            driver.WaitForElementVisible(LoanPageElements.classLoanCalculator, 5);
        }   


        public string GetMinLoan()
        {
            return this.driver.GetAttributeValue(LoanPageElements.sliderElement, "min");
        }

        public string GetMaxLoan()
        {
            return this.driver.GetAttributeValue(LoanPageElements.sliderElement, "max");
        }

        public void AssetMinandMaxLoanAmounts(int min, int max)
        {
            Assert.AreEqual(this.GetMinLoan(), min.ToString());
            Assert.AreEqual(this.GetMaxLoan(), max.ToString());
        }

        public void SelectLoanAmount()
        {
            this.driver.MoveToElement(LoanPageElements.sliderElement, 300);
            this.driver.Wait(3);
            this.driver.WaitForPageLoad(15);
        }

        public void SelectSingleRepaymentDayOnSlider(int days)
        {
            this.driver.SetSliderValue(LoanPageElements.singleSliderNumberOfDays, days);
        }

        public void AssertSingleDaySelectedIsWeekendAndNotAllowedForRepayment()
        {
            if (this.driver.GetText(LoanPageElements.SingleDayWeekendText).Contains("You've currently selected a non-working"))
            {
                Assert.IsTrue(this.driver.GetText(LoanPageElements.SingleDayWeekendText).Contains("You've currently selected a non-working"));
            }
        }

        public void AssertSliderAmountIsLoanAmount()
        {
            string sliderAmount = driver.GetText(LoanPageElements.selectedSliderAmountFromHeader);
            string loanAmount = driver.GetText(LoanPageElements.selectedLoanAmount).TrimEnd();
            Assert.AreEqual(sliderAmount, loanAmount.Substring(0, loanAmount.Length-1));
        }

        public void AssertRepayemtDayIsFriday()
        {           
            string repaymentDateFromPage = driver.GetText(LoanPageElements.repaymentDateWeekend);
            Assert.AreEqual(repaymentDateFromPage, "Friday 21 Jun 2019");
        }

        public void AssertRepayemtDayIsTheSameDayAsSelected()
        {           
            string repaymentDateFromPage = driver.GetText(LoanPageElements.repaymentDateWeekday);
            Assert.AreEqual(repaymentDateFromPage, "Monday 24 Jun 2019");
        }

        public void OpenRepaymentDayCalendarAndSelectDay(int repaymentDate)
        {            
            if (!this.driver.IsElementVisisble(LoanPageElements.Calander))
            { 
                this.driver.ClickAllVisibleElements(LoanPageElements.LoanScheduleButton);                
            }
            this.driver.WaitForElementVisible(LoanPageElements.Calander, 1);
            this.driver.Click(LoanPageElements.dateOnCalander(repaymentDate));
        }


        public void OpenRepaymentDayWeekSchedule(string repaymentDay)
        {
            if (!this.driver.IsElementVisisble(LoanPageElements.WeekSchedule))
            {
                this.driver.ClickAllVisibleElements(LoanPageElements.OpenWeekSchedule);
            }
            this.driver.WaitForElementVisible(WeekSchedule,0);
            this.driver.Click(LoanPageElements.dayOnWeekSchedule(repaymentDay));
        }

        public void AssertRepayemtDayIsTheSameDayAsSelectedForWeekly()
        {
            string repaymentDateFromPage = driver.GetText(LoanPageElements.repaymentDateForWeekly);
            Assert.AreEqual(repaymentDateFromPage, "Friday 14 Jun 2019");
        }


        public void SelectRepaymentType(string repaymentType)
        {
            switch (repaymentType)
            {
                case "Weekly":
                    this.driver.ClickAllVisibleElements(LoanPageElements.weeklyTab);
                    this.driver.WaitForPageLoad(30);
                    this.driver.Wait(3);
                    break;
                case "Daily":
                    this.driver.WaitForElementVisible(LoanPageElements.dailyTab, 5);
                    this.driver.ClickAllVisibleElements(LoanPageElements.dailyTab);
                    this.driver.WaitForPageLoad(30);
                    this.driver.Wait(1);
                    break;
                default:
                    this.driver.ClickAllVisibleElements(LoanPageElements.monthlyTab);
                    this.driver.WaitForPageLoad(30);
                    this.driver.Wait(3);
                    break;

            }
        }       
    }
}
