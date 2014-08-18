Given /^I am on the Login Screen$/ do
  login_page = page(LoginScreen).await
  @current_page = login_page
end

When /^I enter my credentials$/ do
  @current_page = @current_page.enter_email_address("automation@test.com")
  @current_page = @current_page.enter_password("Te$t")
end

When /^I tap the Log In Button$/ do
  @current_page = @current_page.tap_log_in_button
end

Then /^I should be on the First Screen$/ do
  assert_screen(FirstScreen)
  @current_page = page(FirstScreen).await
end

When /^I tap the Second Page Button$/ do
  @current_page = @current_page.tap_button
end

Then /^I should be on the Second Screen$/ do
  assert_screen(SecondScreen)
  @current_page = page(SecondScreen).await
end

When /^I tap the Logout Button$/ do
  @current_page = @current_page.tap_logout_button
end

Then /^I should be on the Login Screen$/ do
  assert_screen(LoginScreen)
  @current_page = page(LoginScreen).await
end