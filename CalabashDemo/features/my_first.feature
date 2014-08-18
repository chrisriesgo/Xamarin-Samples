Feature: Running a test

Scenario: Calabash Passing Demo
  Given I am on the Login Screen
  When I enter my credentials
  And I tap the Log In Button
  Then I should be on the First Screen
  
  When I tap the Second Page Button
  Then I should be on the Second Screen
  
  When I tap the Logout Button
  Then I should be on the Login Screen
 
Scenario: Calabas# h Failing Demo
  Given I am on the Login Screen
  When I enter my credentials
  And I tap the Log In Button
  Then I should be on the First Screen
  
  When I tap the Logout Button
  When I tap the Second Page Button
  Then I should be on the Second Screen
  
  When I tap the Logout Button
  Then I should be on the Login Screen

