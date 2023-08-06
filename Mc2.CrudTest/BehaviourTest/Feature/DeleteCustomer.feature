Feature: Delete Customer

Scenario: Deleting an existing customer
    Given a customer for delete with ID 1 exists
    When I delete the customer with ID 1
    Then the customer should be marked as inactive
