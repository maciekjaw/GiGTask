using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Specflow.Helpers;

namespace Specflow.Steps
{
    [Binding]
    public static class WebApiCallsSteps
    {

        [Given(@"Correct data endpoint returns (.*) code I get '(.*)' token")]
        public static void GivenCorrectDataEndpointReturnsCodeIGetToken(int acctualCode, string acctualToken)
        {
            Assert.AreEqual(RestHelper.Post<string>(RestHelper.Password).responseCode, acctualCode);
            Assert.AreEqual(RestHelper.Post<string>(RestHelper.Password).token, acctualToken);
        }

        [Given(@"Endpoint returns (.*) code and returns error message code '(.*)'")]
        public static void GivenEndpointReturnsCodeAndReturnsErrorMessageCode(int acctualCode, string acctualErrorMessage)
        {
            Assert.AreEqual(RestHelper.Post<string>().responseCode, acctualCode);
            Assert.AreEqual(RestHelper.Post<string>().errorMessage, acctualErrorMessage);
        }

        [Given(@"GET endpoint returns (.*) code and list of users")]
        public static void GivenGETEndpointReturnsCodeAndListOfUsers(int acctualCode)
        {
            string[] expectedNames = { "George", "Janet", "Emma", "Eve", "Charles", "Tracey" };

            Assert.AreEqual(RestHelper.Get<int>().responseCode, acctualCode);
            Assert.AreEqual(RestHelper.Get<string>().names[0], expectedNames[0]);
            Assert.AreEqual(RestHelper.Get<string>().names[1], expectedNames[1]);
            Assert.AreEqual(RestHelper.Get<string>().names[2], expectedNames[2]);
            Assert.AreEqual(RestHelper.Get<string>().names[3], expectedNames[3]);
            Assert.AreEqual(RestHelper.Get<string>().names[4], expectedNames[4]);
            Assert.AreEqual(RestHelper.Get<string>().names[5], expectedNames[5]);

        }

    }
}
