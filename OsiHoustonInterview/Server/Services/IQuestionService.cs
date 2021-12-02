using OsiHoustonInterview.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsiHoustonInterview.Server.Services
{
    public interface IQuestionService
    {
        QuestionTwoResponse GetQuestionTwoResponse(QuestionTwoRequest questionTwoRequest);
        QuestionThreeResponse GetQuestionThreeResponse(QuestionThreeRequest questionThreeRequest);
    }
}
