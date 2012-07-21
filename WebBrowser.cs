#region

using TechTalk.SpecFlow;
using WatiN.Core;

#endregion

namespace GrouponDeals.AcceptanceTests
{
    [Binding]
    public class WebBrowser
    {
        public static Browser Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("browser"))
                {
                    ScenarioContext.Current["browser"] = new IE();
             
                }
                return (Browser) ScenarioContext.Current["browser"];
            }
        }


        [AfterScenario]
        public static void Close()
        {
            if (ScenarioContext.Current.ContainsKey("browser"))
            {
                
                Current.Close();
            }
        }
    }
}