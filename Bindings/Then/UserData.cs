using Bindings.Context;
using Bindings.Helper;
using Bindings.Response;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Bindings.Then
{
    [Binding]
    public class UserData
    {
        private readonly IContextProperties _contextProperties;

        public UserData(IContextProperties contextProperties)
        {
            _contextProperties = contextProperties;
        }

        [Then(@"I should receive a status code of (.*) from the api")]
        public void ThenIShouldReceiveTheCorrectResponseOfFromTheApi(HttpStatusCode expected)
        {
            _contextProperties.Response.Should().NotBeNull();
            _contextProperties.Response.StatusCode.Should().Be(expected);
        }

        [Then(@"I should get the following user data")]
        public void ThenIShouldGetTheFollowingUserData(Table table)
        {
            var expectedData = table.CreateSet<UserResponse>().ToList();
            var actual = ApiHelper.DeserialiseReponseMessage<UserResponse>(_contextProperties.Response);

            if (actual == null) throw new NullReferenceException("No data is returned from API");
            VerifyData(actual, expectedData[0]);
        }


        [Then(@"I should get the following data")]
        public void ThenIShouldGetTheFollowingData(Table table)
        {
            var expectedData = table.CreateSet<UserResponse>().ToList();
            var actual = VerifyResponse(expectedData.Count);

            actual = actual.OrderBy(x => x.id).ToList();

            for (int i = 0; i < expectedData.Count; i++)
            {
                VerifyData(actual[i], expectedData[i]);

            }
        }

        [Then(@"the total user count should be (.*)")]
        public void ThenTheTotalUserCountShouldBe(int count)
        {
            VerifyResponse(count);
        }

        private List<UserResponse> VerifyResponse(int count)
        {
            var actual = ApiHelper.DeserialiseReponseMessage<List<UserResponse>>(_contextProperties.Response);
            if (actual == null) throw new NullReferenceException("No data is returned from API");
            actual.Count.Should().Be(count);
            return actual;
        }

        private void VerifyData(UserResponse actual, UserResponse expectedData)
        {
            actual.first_name.Should().Be(expectedData.first_name);

            actual.last_name.Should().Be(expectedData.last_name);
            actual.latitude.Should().Be(expectedData.latitude);
            actual.longitude.Should().Be(expectedData.longitude);
            actual.email.Should().Be(expectedData.email);
            actual.ip_address.Should().Be(expectedData.ip_address);

            if (expectedData.city != null)
            {
                actual.city.Should().Be(expectedData.city);
            }
        }
    }
}