require 'calabash-cucumber/ibase'

class SecondScreen < Calabash::IBase
  include CalabashDemo::IOSHelpers

  def trait
    "label text:'Second Page'"
  end
  
  def logout_button
    "button label text:'Logout'"
  end
  
  def tap_logout_button
    touch(logout_button)
    page(LoginScreen).await
  end

end