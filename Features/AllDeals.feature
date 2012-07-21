Feature: All deals
	I need to store all my awesome groupon deals in a file.	

Scenario:  Save all my deals
	
	Given I am on the home page
    When I click the Sign In link
	Then I should be on the login page
	When I enter my email and password
    When I press the commit button
	Then I should be logged in
	When I click the All Deals link
	Then I should be able to store all my deals in AllMyDeals file

