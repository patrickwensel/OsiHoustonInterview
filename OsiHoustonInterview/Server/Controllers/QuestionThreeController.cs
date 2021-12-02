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
    public class QuestionThreeController : Controller
    {
        IQuestionService questionService;

        public QuestionThreeController(IQuestionService _questionService)
        {
            questionService = _questionService;
        }

        [HttpPost]
        public Task<QuestionThreeResponse> Post(QuestionThreeRequest questionThreeRequest)
        {
            QuestionThreeResponse questionThreeResponse = questionService.GetQuestionThreeResponse(questionThreeRequest);

            return Task.FromResult(questionThreeResponse);
        }
    }
}
