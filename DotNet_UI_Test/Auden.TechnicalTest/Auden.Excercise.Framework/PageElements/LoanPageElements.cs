using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageElements
{
    public class LoanPageElements
    {

        public static string monthlyTab
        {
            get
            {
                return "//nav[@class='tab-list']/button[@name='monthly']";
            } 
        }

        public static string weeklyTab
        {
            get
            {
                return "//nav[@class='tab-list']/button[@name='weekly']";
            }
        }

        public static string dailyTab
        {
            get
            {
                return "//button[@name='single']";
            }
        }

        public static string sliderXpathLoanAmount
        {
            get
            {
                return "//div[contains(@class,'loan-amount__range-slider')]";
            }
        }

        public static string sliderIdMonthly
        {
            get
            {
                return "monthly";
            }
        }


        public static string sliderIdWeekly
        {
            get
            {
                return "weekly";
            }
        }


        public static string sliderIdDaily
        {
            get
            {
                return "daily";
            }
        }

        public static string classLoanCalculator
        {
            get
            {
                return "loan-calculator";
            }
        }

        public static string sliderElement
        {
            get
            {
                return "//input[@class='loan-amount__range-slider__input']";
            }
        }

        public static string singleSliderNumberOfDays
        {
            get
            {
                return "//input[@id='single'][@class='loan-amount__range-slider__input']";
            }
        }

        public static string selectedSliderAmountFromHeader
        {
            get
            {
                return "//div[@class='loan-amount__header__amount']/span";
            }
        }

        public static string selectedLoanAmount
        {
            get
            {
                return "//div[@class='loan-summary__column__amount']/span[@class='loan-summary__column__amount__value']";
            }
        }

        public static string LoanScheduleButton
        {
            get
            {
                return "//span[@class='loan-schedule__tab__panel__header__button__icon']";
            }
        }

        public static string Calander
        {
            get
            {
                return "//div[@class='date-selector']";
            }
        }

        public static string dateOnCalander(int date)
        {
            return "//span[@class='date-selector__flex']/button[contains(text(), '"+ date +"')]";
        }

        public static string repaymentDateWeekend
        {
            get
            {
                return "//label[@class='loan-schedule__tab__panel__detail__tag__label']";
            }
            
        }

        public static string repaymentDateWeekday
        {
            
            get
            {
                return "//span[@class='loan-schedule__tab__panel__detail__tag__text']";
            }

        }

        public static string repaymentDateForWeekly
        {           
           get
            {
                return "//span[@class='loan-schedule__tab__panel__detail__tag']/label[@class='loan-schedule__tab__panel__detail__tag__label']";
            }

        }

        public static string OpenWeekSchedule
        {
            get
            {
                return "//span[@class='loan-schedule__tab__panel__header__button__icon']";
            }
        }

        public static string WeekSchedule
        {
            get
            {
                return "//div[@class='date-selector date-selector--days']";
            }
        }


        
      public static string dayOnWeekSchedule(string day)
        {
           return "//span[@class='date-selector__flex']/button[contains(text(), '" + day + "')]";
        }


        public static string SingleDayWeekendText
        {
            get
            {
                return "//p[@class='text-center']";
            }
        }
    }
}
