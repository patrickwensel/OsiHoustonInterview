using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using OsiHoustonInterview.Shared;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OsiHoustonInterview.Client.Pages
{
    public class QuestionThreeModalBase : ComponentBase
    {
        [Inject]
        HttpClient _httpClient { get; set; }

        [Inject]
        ILogger<QuestionThreeRequest> Logger { get; set; }

        protected QuestionThreeRequest questionThreeRequest = new QuestionThreeRequest
        {
            FilterOne = "GUHNRIIHRQ",
            FilterTwo = "PMSLFTWTQC",
            FilterThree = "EYTOVYFYED"
        };
        protected QuestionThreeResponse questionThreeResponse = new();

        protected async Task<QuestionThreeResponse> SubmitStrings()
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("QuestionThree", questionThreeRequest);

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new HttpRequestException($"Validation failed. Status Code: {response.StatusCode}");
                }
                else
                {
                    questionThreeResponse = JsonConvert.DeserializeObject<QuestionThreeResponse>(response.Content.ReadAsStringAsync().Result);
                    return questionThreeResponse;
                }

            }
            catch (Exception ex)
            {                
                Logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
