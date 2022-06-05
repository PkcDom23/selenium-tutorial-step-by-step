Feature: Login

Very first test with Selenium

Scenario: OK login
Given I go to the page 'http://the-internet.herokuapp.com/login'
When I enter username 'tomsmith'
And I enter password 'SuperSecretPassword!'
And I press the Login button
Then I see that I am logged in

Scenario: NOT-OK login
Given I go to the page 'http://the-internet.herokuapp.com/login'
When I enter username 'wrongUsername'
And I enter password 'wrongPassword'
And I press the Login button
Then I see that I am NOT logged in

Scenario: Logout
Given I am logged in
When I press the Logout button
Then I see that I am NOT logged in