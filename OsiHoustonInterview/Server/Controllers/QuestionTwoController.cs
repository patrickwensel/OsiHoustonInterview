using Microsoft.AspNetCore.Mvc;
using OsiHoustonInterview.Server.Services;
using OsiHoustonInterview.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsiHoustonInterview.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionTwoController : Controller
    {
        IQuestionService questionService;

        public QuestionTwoController(IQuestionService _questionService)
        {
            questionService = _questionService;
        }

        [HttpPost]
        public Task<QuestionTwoResponse> Post(QuestionTwoRequest questionTwoRequest)
        {
            QuestionTwoResponse questionTwoResponse = new QuestionTwoResponse();

            questionTwoResponse.Result = questionService.GetQuestionTwoResponse(questionTwoRequest).Result;

            return Task.FromResult(questionTwoResponse);
        }
    }
}
