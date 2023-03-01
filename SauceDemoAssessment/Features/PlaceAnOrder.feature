Feature: PlaceAnOrder

Place an order with products that are added from Products page/Product Detail page.

Scenario: [PlaceAnOrder_ProductsPage]
	Given I login to Saucedemo.com
	And I add the Backpack product to cart
	And I go to the Shopping Cart and Checkout
	And I fill the informations and Continue
	When I click the Finish button after check the total amount
	Then I see the Checkout complete page
	And I back to home and logout

Scenario: [PlaceAnOrder_ProductDetailPage]
	Given I login to Saucedemo.com
	And I go to Bike Light detail page and add product to cart
	And I go to the Shopping Cart and Checkout
	And I fill the informations and Continue
	When I click the Finish button after check the total amount
	Then I see the Checkout complete page
	And I back to home and logout