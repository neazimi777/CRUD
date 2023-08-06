Feature: Update Customer
Scenario: Updating an existing customer with valid data

    Given a customer for update with ID 2 exists
    When I update the customer with valid data
    Then the customer information should be updated