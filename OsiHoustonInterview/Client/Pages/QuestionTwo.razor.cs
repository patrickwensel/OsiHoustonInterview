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
    public class QuestionTwoModalBase : ComponentBase
    {
        [Inject]
        HttpClient _httpClient { get; set; }

        [Inject]
        ILogger<QuestionTwoRequest> Logger { get; set; }

        protected QuestionTwoRequest questionTwoRequest = new();
        protected QuestionTwoResponse questionTwoResponse = new();

        protected async Task<QuestionTwoResponse> SubmitStrings()
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("QuestionTwo", questionTwoRequest);

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new HttpRequestException($"Validation failed. Status Code: {response.StatusCode}");
                }
                else
                {
                    questionTwoResponse = JsonConvert.DeserializeObject<QuestionTwoResponse>(response.Content.ReadAsStringAsync().Result);
                    return questionTwoResponse;
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
