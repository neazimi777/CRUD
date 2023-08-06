Feature: Get Customer
Scenario: Getting an existing customer by ID
    Given a customer with ID 1 exists
    When I request the customer with ID 1
    Then the customer information should be returned