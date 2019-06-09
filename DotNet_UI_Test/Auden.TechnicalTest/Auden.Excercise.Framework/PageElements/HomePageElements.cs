using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageElements
{
    public class HomePageElements
    {
        public string btnApplyForLoan
        {
            get
            {
                return "//a[contains(text(),'apply for a loan')]";
            }
        }

        public string btnClassApplyNow
        {
            get
            {
                return "loan-calculator__apply";
            }
        }
    }
}
