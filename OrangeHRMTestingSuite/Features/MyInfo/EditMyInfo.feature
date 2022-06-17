Feature: EditMyInfo

As a Test Automation Engineer
I want to test the edit functionality
For the My Info page

@MyInfo
Scenario: Verify the Personal Details form allows editing the Nationality field
	Given I log into the application with the user 'Admin' and password 'admin123'
	When I navigate to the My Info page
	And I use my custom Select Element methods for the Nationality Dropdown
	Then I save the changes to verify the Nationality dropdown saved my selected option