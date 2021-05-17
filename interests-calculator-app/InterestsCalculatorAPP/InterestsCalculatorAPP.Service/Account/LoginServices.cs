using InterestsCalculatorAPP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InterestsCalculatorAPP.Service.Account
{
    public class LoginServices : ILoginServices
    {
        private readonly IHttpClientFactory _clientFactory;

        public LoginServices(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HttpStatusCode> Login(Login login)
        {

            var url = "https://reqres.in/api/login";

            var encodedContent = new FormUrlEncodedContent(new[] {
                 new KeyValuePair<string, string>("email", login.Email),
                 new KeyValuePair<string, string>("password", login.Password),
            });

            var client = _clientFactory.CreateClient();

            var response = await client.PostAsync(url, encodedContent);

            if (response.IsSuccessStatusCode)
            {
                return response.StatusCode;
            }
            else
            {
                return HttpStatusCode.Unauthorized;
            }
        }
    }
}
