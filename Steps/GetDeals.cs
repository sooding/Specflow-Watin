#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using System.IO;
using System.Net;

#endregion

namespace GrouponDeals.AcceptanceTests.Steps
{
    [Binding]
    public class GetDeals
    {
        [Given("I am on the home page")]
        public void given_i_am_on_the_home_page()
        {
            WebBrowser.Current.GoTo("http://www.groupon.com");
            var link1 = WebBrowser.Current.Link(b => b.Text == "Sign In");
            if (!link1.Exists)
            {
                when_i_click_the_link("Sign out");
            }
           
        }

        [Then(@"I should be on the login page")]
        public void Ishouldbeontheloginpage()
        {
            Assert.IsTrue(WebBrowser.Current.Title.Equals("Sign in"));
        }

        [Then ("I should be logged in")]
        public bool Ishouldbeloggedin()
        {

            try
            {
                var link = WebBrowser.Current.Link(b => b.Text == "Abhishek S.");
                Assert.IsTrue(link.Exists);
                return true;
            }
            catch (AssertFailedException)
            {
                var newlink = WebBrowser.Current.Link(b => b.Text == "Abhishek Sood");
               Assert.IsTrue(newlink.Exists);
                return true;
            }

        }

        [When(@"I enter my email and password")]
        public void WhenIEnterMyUsernameAndPassword()
        {
            WebBrowser.Current.TextField("session_email_address").Value = "soodabhi7@gmail.com";
            WebBrowser.Current.TextField("session_password").Value = "Test123";
        }

       [When("I press the (.*) button")]
       public void when_i_press_the_button(string buttonName)
       {
           var button = WebBrowser.Current.Button(b => b.Name == buttonName);
           button.Click();           
           WebBrowser.Current.WaitForComplete(); 
       }

        [When("I click the (.*) link")]
       public void when_i_click_the_link(string linkName)
       {
           try
           {
               var link = WebBrowser.Current.Link(b => b.Text == linkName);
               link.Click();
           }
           catch
           {
               if(linkName == "All Deals")
               {
                    var elem = WebBrowser.Current.Element(b => b.Text == "All Local Deals").Parent;
                    elem.Click();
               }
           }

           WebBrowser.Current.WaitForComplete();
       }

        [Then ("I should be able to store all my deals in (.*) file")]
        public void store_all_deals(string filename)
        {
           var links = WebBrowser.Current.Div(b => b.Id == "deal_container").Links;
           string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
           string str = dir+ filename + ".txt";
           StreamWriter file = new StreamWriter(str);
           foreach (var item in links)
           {
               file.WriteLine(item.Text);    
           }
           file.Close();
           
        }
    }
}