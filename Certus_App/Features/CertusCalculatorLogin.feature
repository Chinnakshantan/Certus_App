Feature: Calculator login page
	Certus Calculator login page


@login @smoke
Scenario: Login to Certus Calculator
	Given User login to certus calculator as 'client'
	Then Validate login page is successful

@InvalidLogin
Scenario: Invalid Login
	Given I login certus using 'Invalid credentials'
	Then Validate unsuccessful login

