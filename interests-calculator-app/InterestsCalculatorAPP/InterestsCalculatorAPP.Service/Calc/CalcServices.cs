using InterestsCalculatorAPP.Domain.Model;
using InterestsCalculatorAPP.Service.AppConfig;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InterestsCalculatorAPP.Service.Calc
{
    public class CalcServices : ICalcServices
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IAppConfiguration _AppConfiguration;

        public CalcServices(IHttpClientFactory clientFactory, IAppConfiguration appConfiguration)
        {
            _clientFactory = clientFactory;
            _AppConfiguration = appConfiguration;
        }

        public async Task<double> CalculateInterests(InterestsCalculator interestsCalculator)
        {

            var url = _AppConfiguration.EndPoint_Production + "api/calc-interests";

            var client = _clientFactory.CreateClient();

            var stringContent = new StringContent(JsonConvert.SerializeObject(interestsCalculator), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, stringContent);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<double>(result);
        }

        public async Task<string> ShowMeYourCode()
        {

            var url = _AppConfiguration.EndPoint_Production + "api/show-me-your-code";

            var client = _clientFactory.CreateClient();

            var response = await client.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
