using OsiHoustonInterview.Server.Data;
using OsiHoustonInterview.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace OsiHoustonInterview.Server.Services
{
    public class QuestionService : IQuestionService
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public QuestionService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
         }
        public QuestionTwoResponse GetQuestionTwoResponse(QuestionTwoRequest questionTwoRequest)
        {
            QuestionTwoResponse questionTwoResponse = new QuestionTwoResponse();
            string stringOne = questionTwoRequest.StringOne;
            string stringTwo = questionTwoRequest.StringTwo;

            List<char> stringOnelist = new List<char>();
            stringOnelist.AddRange(stringOne);

            List<char> stringTwolist = new List<char>();
            stringTwolist.AddRange(stringTwo);

            var whatsLeftArray = stringOnelist.Where(x => !stringTwolist.Contains(x)).ToArray();

            questionTwoResponse.Result = string.Join(",", whatsLeftArray);

            return questionTwoResponse;
        }

        public QuestionThreeResponse GetQuestionThreeResponse(QuestionThreeRequest questionThreeRequest)
        {
            QuestionThreeResponse questionThreeResponse = new QuestionThreeResponse();
            string filter1 = questionThreeRequest.FilterOne;
            string filter2 = questionThreeRequest.FilterTwo;
            string filter3 = questionThreeRequest.FilterThree;

            //Test Original
            Stopwatch swGetFilteredData = new Stopwatch();

            swGetFilteredData.Start();

            var resultsOriginal = GetFilteredData(filter1, filter2, filter3);

            swGetFilteredData.Stop();
            questionThreeResponse.OriginalMethodTime = swGetFilteredData.Elapsed;

            //Test Refactor 1
            Stopwatch swGetFilteredDataRefactor1 = new Stopwatch();

            swGetFilteredDataRefactor1.Start();

            var results1 = GetFilteredDataRefactor1(filter1, filter2, filter3);

            swGetFilteredDataRefactor1.Stop();
            questionThreeResponse.RefactoredMethodTimeOne = swGetFilteredDataRefactor1.Elapsed;

            //Test Refactor 2
            Stopwatch swGetFilteredDataRefactor2 = new Stopwatch();

            swGetFilteredDataRefactor2.Start();

            var results2 = GetFilteredDataRefactor2(filter1, filter2, filter3);

            swGetFilteredDataRefactor2.Stop();
            questionThreeResponse.RefactoredMethodTimeTwo = swGetFilteredDataRefactor2.Elapsed;


            //Test Refactor 3
            Stopwatch swGetFilteredDataRefactor3 = new Stopwatch();

            swGetFilteredDataRefactor3.Start();

            var results3 = GetFilteredDataRefactor3(filter1, filter2, filter3);

            swGetFilteredDataRefactor3.Stop();
            questionThreeResponse.RefactoredMethodTimeThree = swGetFilteredDataRefactor3.Elapsed;

            return questionThreeResponse;
        }

        public List<string> GetFilteredData(string filter1, string filter2, string filter3)
        {
            var result = new List<string>();

            try
            {
                List<string> data = _applicationDbContext.Categories.Select(x => x.Name).ToList();

                foreach (var currentItem in data)
                {
                    if (currentItem == filter1)
                        result.Add(currentItem);

                    if (currentItem == filter2)
                        result.Add(currentItem);

                    if (currentItem == filter3)
                        result.Add(currentItem);
                }
            }
            catch (Exception ex)
            {
                if (!(ex is NullReferenceException))
                    throw ex;
            }

            return result;
        }

        public List<string> GetFilteredDataRefactor1(string filter1, string filter2, string filter3)
        {
            var result = new List<string>();

            try
            {
                List<string> data = _applicationDbContext.Categories.Select(x => x.Name).ToList();
                List<string> filter = new List<string> { filter1, filter2, filter3 };

                result = data.Where(i => filter.Contains(i)).ToList();


            }
            catch (Exception ex)
            {
                if (!(ex is NullReferenceException))
                    throw ex;
            }

            return result;
        }

        public List<string> GetFilteredDataRefactor2(string filter1, string filter2, string filter3)
        {
            var result = new List<string>();

            try
            {
                List<string> data = _applicationDbContext.Categories.Where(x=>x.Name == filter1 || x.Name == filter2 || x.Name == filter3).Select(y=>y.Name).ToList();

                result = data;

            }
            catch (Exception ex)
            {
                if (!(ex is NullReferenceException))
                    throw ex;
            }

            return result;
        }

        public List<string> GetFilteredDataRefactor3(string filter1, string filter2, string filter3)
        {
            var result = new List<string>();

            try
            {
                List<string> filter = new List<string> { filter1, filter2, filter3 };
                List<string> data = _applicationDbContext.Categories.Where(x => filter.Contains(x.Name)).Select(y => y.Name).ToList();

                result = data;

            }
            catch (Exception ex)
            {
                if (!(ex is NullReferenceException))
                    throw ex;
            }

            return result;
        }
    }
}
