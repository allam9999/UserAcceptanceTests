
using Bindings.Context;
using Bindings.Helper;
using TechTalk.SpecFlow;

namespace Bindings.When
{
    [Binding]
    public class UserData
    {
        private readonly IContextProperties _contextProperties;

        public UserData(IContextProperties contextProperties)
        {
            _contextProperties = contextProperties;
        }

        [When(@"I make a call to the GetUsersByCity Api")]
        [When(@"I make a call to the GetUser Api")]
        [When(@"I make a call to the GetAllUserData Api")]
        public void WhenIMakeACallToTheGetUserApi()
        {
            _contextProperties.Response = ApiHelper.GetRequest(_contextProperties.Url == null ? Constants.getAllUserDataUrl : _contextProperties.Url);
        }
    }
}