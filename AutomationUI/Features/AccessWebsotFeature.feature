Feature: Open web site page
	As an user
	I want to Validate A Class models price are between highest and lowest price

Scenario: Go to Mercedes-benz UK web page
	Given I navigate to the Mercedes-benz home page
	And I select one model <allModels>
	When I mouse over the car model <carModel> to click to Build Your Car
	Then I can choose the Fuel type <fuelType> to validate models price

	Examples:
		| TC            | allModels  | carModel | fuelType |
		| Mercedes-Bens | Hatchbacks | A-Class  | Diesel   |