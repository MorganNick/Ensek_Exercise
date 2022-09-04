Feature: Ensek_BuyEnergy
	Ensek Buy Energy Exercise
	
Background: 
	Given the Buy Energy page is displayed

Scenario Outline: Buy energy and check the success message
	Given I enter a <value> to be purchased for a specific <fuel>
	When I click the Buy button for the <fuel>
	Then the Sale Confirmed page is displayed with <value> and <fuel>

	Examples:
	|value|fuel|
	|100|Gas|
	|200|Electricity|
	|10|Oil|
