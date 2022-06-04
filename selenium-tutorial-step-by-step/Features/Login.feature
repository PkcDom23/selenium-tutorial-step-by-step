Feature: Login

Very first test with Selenium

Scenario: OK login
Given I go to the page 'http://the-internet.herokuapp.com/login'
When I enter username 'tomsmith'
And I enter password 'SuperSecretPassword!'
And I press the Login button
