Feature: CancelOrder

Remove products from the Shopping cart

Scenario: [Cancel_BeforeContinueTheOrder]
	Given I login to Saucedemo.com
	And I add the Backpack product to cart
	And I go to the Shopping Cart and Checkout
	And I click Cancel button
	When I click Backpack's Remove button
	Then I see empty cart page
	And I continue shopping and logout

Scenario: [Cancel_BeforeFinishTheOrder]
	Given I login to Saucedemo.com
	And I add the Backpack product to cart
	And I go to the Shopping Cart and Checkout
	And I fill the informations and Continue
	And I click Cancel button on Checkout step two
	And I go to cart
	When I click Backpack's Remove button
	Then I see empty cart page
	And I continue shopping and logout