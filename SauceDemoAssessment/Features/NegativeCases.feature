Feature: NegativeCases

Negative cases for Saucedemo.com

Scenario: [Checkout: Your Information page validations - First Name]
	Given I login to Saucedemo.com
	And I go to the Shopping Cart and Checkout
	When I click the Continue button
	Then I see 'Error: First Name is required' message
	And I logout

Scenario: [Checkout: Your Information page validations - Last Name]
	Given I login to Saucedemo.com
	And I go to the Shopping Cart and Checkout
	And I fill the First Name field
	When I click the Continue button
	Then I see 'Error: Last Name is required' message
	And I logout

Scenario: [Checkout: Your Information page validations - Postal Code]
	Given I login to Saucedemo.com
	And I go to the Shopping Cart and Checkout
	And I fill the First Name field
	And I fill the Last Name field
	When I click the Continue button
	Then I see 'Error: Postal Code is required' message
	And I logout

Scenario: [Login without enter credentials]
	Given I do not enter credentials
	When I click Login button
	Then I see login 'Epic sadface: Username is required' message
	And I clear the fields and click error button

Scenario: [Login with invalid credentials]
	Given I enter invalid credentials
	When I click Login button
	Then I see login 'Epic sadface: Username and password do not match any user in this service' message
	And I clear the fields and click error button

Scenario: [Login without enter password]
	Given I enter username
	When I click Login button
	Then I see login 'Epic sadface: Password is required' message
	And I clear the fields and click error button