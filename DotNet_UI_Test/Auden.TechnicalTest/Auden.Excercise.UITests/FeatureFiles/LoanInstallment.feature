Feature: Instalment

@MonthlyTest
Scenario: Monthly repayment and select repayment day as weekend	
	 Given User is on home page
     When user clicks on Apply For A Loan button
	 Then user is navigated to shorttermloan page	
	 When user select loan amount from slider 	  
	 And click Monthly tab
	 Then system displays slider with minimum amount 200 and maximum amount 1000 
	 And selected slider amount is displayed as loan amount
	 When user select repayment date as weekend 22 June
	 Then system automatically move it to push it back to friday
	 When user select repayment date as weekday 24 june
	 Then system displays the selected date as repaymnet date
	
 
 @WeeklyTest
Scenario: Weekly repayment and select repayment day as weekend	
	 Given User is on home page
     When user clicks on Apply For A Loan button
	 Then user is navigated to shorttermloan page	
	 When user select loan amount from slider 	  
	 And click weekly tab
	 Then system displays slider with minimum amount 200 and maximum amount 1000 
	 And selected slider amount is displayed as loan amount
	 When user select repayment date as Fri	
	 Then system displays the selected day as repaymnet date
 
 @DailyTest
Scenario: Daily repayment and select repayment day as weekend	
	 Given User is on home page
     When user clicks on Apply For A Loan button
	 Then user is navigated to shorttermloan page	
	 When user select loan amount from slider 	  
	 And click Daily tab
	 Then system displays slider with minimum amount 200 and maximum amount 600 
	 And selected slider amount is displayed as loan amount	
	 When user selects a weekend for single repayment, system does not display repayment date