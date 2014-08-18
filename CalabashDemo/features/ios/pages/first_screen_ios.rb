require 'calabash-cucumber/ibase'

class FirstScreen < Calabash::IBase
  include CalabashDemo::IOSHelpers

  def trait
    "label text:'First Page'"
  end
  
  def second_page_button
    "button label text:'Open Second Page'"
  end
  
  def tap_button
    touch(second_page_button)
    # page(SecondScreen).await
  end

end