require 'calabash-cucumber/ibase'

class LoginScreen < Calabash::IBase
  include CalabashDemo::IOSHelpers

  def trait
    "button marked:'Log In'"
  end
  
  def email_address_field
    "textField placeholder:'Email Address'"
    # "textFieldLabel marked:'Email Address'"
  end

  def password_field
    "textField placeholder:'Password'"
    # "textFieldLabel marked:'Password'"
  end
    
  def log_in_button
    trait
  end

  def tap_log_in_button
    touch(log_in_button)
    page(FirstScreen).await
  end
  
  def enter_email_address(email_address)
    clear_text(email_address_field)
    enter_text(email_address_field, email_address)
    page(LoginScreen).await
  end
  
  def enter_password(password)
    clear_text(password_field)
    enter_text(password_field, password)
    page(LoginScreen).await
  end

  # def task_label(task_name)
  #   "label marked:'#{task_name}'"
  # end
  #
  # def has_in_list(task_name)
  #   item = query(task_label(task_name))
  #   item.any?
  # end
  #
  # def assert_should_have_in_list(task_name)
  #   raise "Could not find #{task_name} in the TableView." unless has_in_list(task_name)
  # end
  #
  # def select_task(task_name)
  #   touch(task_label(task_name))
  #   page(TaskDetailsScreen).await
  # end
  #
  # def is_checked(task_name)
  #   # The iOS verison of Tasky doesn't have check marks in the TableView
  #   true
  # end
  #
  # def delete_task(task_name)
  #   if has_in_list(task_name)
  #     touch(task_label(task_name))
  #     details_page = page(TaskDetailsScreen).await
  #     touch(details_page.delete_button)
  #     page(TaskyProScreen).await
  #   end
  # end
end