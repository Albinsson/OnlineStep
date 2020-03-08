using Fusillade;
using ModernHttpClient;
using OnlineStep.Helpers;
using Refit;
using System;
using System.Net.Http;

namespace OnlineStep.Services
{
    public class TestRestClientHelper : ServiceHelper
    {
        public const string ApiBaseAddress = "https://online-step.herokuapp.com";
        //Lazy is used to improve performance by deffering an objects creation until it is first used (lazy initialization)
        private readonly Lazy<RestInterface> backGround;
        private readonly Lazy<RestInterface> userInitiated;
        private readonly Lazy<RestInterface> speculative;

        public TestRestClientHelper(string apiBaseAddress = null)
        {
            //Encapsulated method that takes a param (HttpMessageHandler) and returns a result (RestInterface)
            //we create and specify our httpClient here so that our RestInterface uses modern httpclient
            //Modern http client places our network stack on the appropriate stack on android and IOS
            //We do this because Android and IOS has their own optimized networking and we want each respective system to use them
            Func<HttpMessageHandler, RestInterface> createClient = messageHandler =>
            {
                var client = new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri(ApiBaseAddress ?? apiBaseAddress)
                };
                return RestService.For<RestInterface>(client);
            };

            //The fusillade nuget provides the Priority feature for us to us
            backGround = new Lazy<RestInterface>(() => createClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Background)));
            userInitiated = new Lazy<RestInterface>(() => createClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.UserInitiated)));
            speculative = new Lazy<RestInterface>(() => createClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Speculative)));
        }

        public RestInterface BackGround { get { return backGround.Value; } }
        public RestInterface UserInitiated { get { return userInitiated.Value; } }
        public RestInterface Speculative { get { return speculative.Value; } }
    }
}
