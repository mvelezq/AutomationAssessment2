using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AutomationAssessment2
{
    public class APIService
    {
        public async Task<Response<object>> PostAsync<T>(string urlBase,T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("shopmanager", "axY2 rimc SzO9 cobf AZBw NLnX");
                
                var response = await client.PostAsync(urlBase, content);
                var answer = await response.Content.ReadAsStringAsync();
                return new Response<object>
                {
                    IsSuccess = true,
                    Message = "Done"
                };

            }
            catch (Exception ex)
            {
                return new Response<object>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
