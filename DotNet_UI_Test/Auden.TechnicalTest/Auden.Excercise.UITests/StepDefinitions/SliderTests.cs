using Auden.Excercise.Pages;
using Auden.Excercise.Common;
using TechTalk.SpecFlow;
using Auden.Excercise.UITests;
using System;

namespace Framework.Webdriver
{ 

    [Binding]
    public class SliderTests: SliderHook
    {        
         
        [Given(@"User is on home page")]
        public void GivenUserIsOnHomePage()
        {            
            homePage.LoadApplicationURL("TestURL");
        }

        [When(@"user clicks on Apply For A Loan button")]
        public void WhenUserClicksOnApplyNowButton()
        {
            homePage.GoToLoanPage();
        }

        [Then(@"user is navigated to shorttermloan page")]
        public void ThenUserIsNavigatedToApplyForLoanPage()
        {
            loansPage.WaitForPageLoad();
        }

        [When(@"user select loan amount from slider")]
        public void WhenUserSelectLoanAmountFromSlider()
        {
            loansPage.SelectLoanAmount();            
        }


        [When(@"click Monthly tab")]
        public void WhenClickMonthlyTab()
        {
            loansPage.SelectRepaymentType("monthly");
        }

        [Then(@"system displays slider with minimum amount (.*) and maximum amount (.*)")]
        public void ThenSystemDisplaysSliderWithMinimumAmountAndMaximumAmount(int p0, int p1)
        {
            loansPage.AssetMinandMaxLoanAmounts(p0, p1);
        }

        [Then(@"selected slider amount is displayed as loan amount")]
        public void ThenSelectedSliderAmountIsDisplayedAsLoanAmount()
        {
            loansPage.AssertSliderAmountIsLoanAmount();
            
        }

        [When(@"user selects a weekend for single repayment, system does not display repayment date")]
        public void WhenUserSelectsAWeekendSystemDoesNotDisplayRepaymentDate()
        {
            var date = DateTime.Now;
            var nextSundayFromToday = date.AddDays(7 - (int)date.DayOfWeek);
            var daysTonextWeekend = (nextSundayFromToday - date).Days;
            this.loansPage.SelectSingleRepaymentDayOnSlider(daysTonextWeekend);
            this.loansPage.AssertSingleDaySelectedIsWeekendAndNotAllowedForRepayment();
        }


        [When(@"user select repayment date as weekend (.*) June")]
        public void WhenUserSelectRepaymentDateAsWeekendJune(int repaymentDate)
        {
            loansPage.OpenRepaymentDayCalendarAndSelectDay(repaymentDate);
        }


        [Then(@"system automatically move it to push it back to friday")]
        public void ThenSystemAutomaticallyMoveItToPushItBackToFriday()
        {
            loansPage.AssertRepayemtDayIsFriday();
        }


        [When(@"user select repayment date as weekday (.*) june")]
        public void WhenUserSelectRepaymentDateAsWeekdayJune(int repaymentDate)
        {
            loansPage.OpenRepaymentDayCalendarAndSelectDay(repaymentDate);
        }

        [When(@"user select repayment date as Fri")]
        public void WhenUserSelectRepaymentDateAsFri()
        {
            loansPage.OpenRepaymentDayWeekSchedule("Fri");
        }


        [Then(@"system displays the selected date as repaymnet date")]
        public void ThenSystemDisplaysTheSelectedDateAsRepaymnetDate()
        {
            loansPage.AssertRepayemtDayIsTheSameDayAsSelected();
        }

        [Then(@"system displays the selected day as repaymnet date")]
        public void ThenSystemDisplaysTheSelectedDayAsRepaymnetDate()
        {
            loansPage.AssertRepayemtDayIsTheSameDayAsSelectedForWeekly();
        }


        [When(@"click weekly tab")]
        public void WhenClickWeeklyTab()
        {
            loansPage.SelectRepaymentType("Weekly");
        }

        [When(@"click Daily tab")]
        public void WhenClickDailyTab()
        {
            this.driver.WaitForPageLoad(10);
            loansPage.SelectRepaymentType("Daily");
        }

    }
}
