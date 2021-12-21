Feature: CertusCalculateRecordingFee
	Calculating Recording fee

@Recordingfee
Scenario: Calculating Recording fee
	Given User login to certus calculator as 'client'
	When I press 'Certus Calculator' in Home page
	And I select 'NewYork' state
	And I select 'Livingston' county
	And I press 'Search' button in certus calculator
	And I press 'Next' button in certus calculator
	And I select 'Refinance' in transaction type
	And I select 'Mortagage' in Add Document
	And I press Add for Add Document
	And I enter Loan Amount as '10000'
	And I enter no. of pages as '20'
	And I scroll to 'Next' button
	And I press 'Next' in Loan information
	And I press 'Next' in Mortagage
	And I press 'Next' in Mortagage
	Then validate Transaction Id is generated