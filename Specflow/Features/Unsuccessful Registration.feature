Feature: Unsuccessful Registration

Scenario: Not completed data
	Given Endpoint returns 400 code and returns error message code 'Missing password'
