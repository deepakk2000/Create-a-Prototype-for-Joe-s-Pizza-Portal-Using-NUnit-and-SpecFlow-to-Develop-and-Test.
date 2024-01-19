Feature: Pizza
  As a pizza enthusiast
  I want to order pizzas
  So that I can enjoy delicious pizzas at home

  Scenario: Order a Pizza
    Given I am on the Pizza Selection page
    When I select "Chicken Pizza" from the menu
    And I proceed to checkout
    Then I should be on the Order Checkout page

  Scenario: Invalid Pizza Type
    Given I am on the Pizza Selection page
    When I select an invalid pizza type "InvalidPizza"
    Then I should be redirected to the Pizza Selection page