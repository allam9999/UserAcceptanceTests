using Bindings.Context;
using TechTalk.SpecFlow;

namespace Bindings.Given
{
    [Binding]
    public class UserData
    {
        private readonly IContextProperties _contextProperties;

        public UserData(IContextProperties contextProperties)
        {
            _contextProperties = contextProperties;
        }

        [Given(@"I have a userId of (.*)")]
        public void GivenIHaveAUserIdOf(int userId)
        {
            _contextProperties.Url = $"{Constants.getDataForSingleUserUrl}{userId}";
        }

        [Given(@"I have a city (.*)")]
        public void GivenIHaveACity(string city)
        {
            var url = Constants.getUserDataByCityUrl;
            _contextProperties.Url = url.Replace("cityname", city);
        }
    }
}