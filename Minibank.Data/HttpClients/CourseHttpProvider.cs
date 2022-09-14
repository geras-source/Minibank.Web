using Minibank.Core;
using Minibank.Data.HttpClients.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Minibank.Data
{
    public class CourseHttpProvider : ICourse
    {
        private readonly HttpClient _httpClient;
        public CourseHttpProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public double GetRubleCourse(string currencyCode)
        {
            var result = _httpClient.GetFromJsonAsync<CourseResponse>("daily_json.js")
                .GetAwaiter().GetResult();

            return result.Valute[currencyCode].Value;
        }
    }
}