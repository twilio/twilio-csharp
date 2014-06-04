using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestClient.Tests
{
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        HttpResponseMessage response ;

        public FakeHttpMessageHandler(HttpStatusCode statusCode) {
            response = new HttpResponseMessage(statusCode);
        }

        public FakeHttpMessageHandler(HttpStatusCode statusCode, string content)
        {
            response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(content)
            };
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return response;  
        }
    }
}
