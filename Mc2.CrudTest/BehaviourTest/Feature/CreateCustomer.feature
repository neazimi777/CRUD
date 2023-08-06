Feature: CreateCustomer
    As a system,
    I want to create a new customer,
    So that I can manage customer information.

Scenario: Valid customer creation
    Given a valid customer request
    When the request is handled
    Then the response should be successful

Scenario: Invalid customer creation
    Given an invalid customer request
    When the request is handled
    Then the response should be unsuccessful