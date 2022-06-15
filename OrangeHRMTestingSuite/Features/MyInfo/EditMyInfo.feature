Feature: EditMyInfo

As a Test Automation Engineer
I want to test the edit functionality
For the My Info page

@MyInfo
Scenario: Verify the Nationality field on the Personal Details form is not required
	Given I log into the application with the user 'Admin' and password 'admin123'
	When I navigate to the My Info page
	And I reset the Nationality dropdown to the default option
	Then I save the changes to verify the Nationality dropdown is not required