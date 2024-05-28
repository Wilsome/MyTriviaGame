using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaLibrary.Models;

namespace TriviaLibrary.Services
{
    public static class QuestionService
    {
        private static readonly HttpClient client = new();

        /// <summary>
        /// Takes the input from the user and sends the request to the trivia API
        /// Method also takes the API Json result and does deserialization. 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="category"></param>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        public static async Task<List<Question>> GetQuestions(int count, int category, string difficulty)
        {
            try
            {
                string requestUri = $"https://opentdb.com/api.php?amount={count}&category={category}&difficulty={difficulty}";

                HttpResponseMessage response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Root rootObject = JsonConvert.DeserializeObject<Root>(jsonResponse);

                    if (rootObject != null && rootObject.Results != null)
                    {
                        // Convert Result objects to Question objects
                        List<Question> questions = [];
                        foreach (Result result in rootObject.Results)
                        {
                            questions.Add(new Question
                            {
                                Text = result.Question,
                                Difficulty = result.Difficulty,
                                CorrectAnswer = result.CorrectAnswer,
                                IsBooleanQuestion = result.Type.Equals("boolean", StringComparison.OrdinalIgnoreCase)
                            });
                        }

                        return questions;
                    }
                    else
                    {
                        Console.WriteLine("API response format is invalid.");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Failed to fetch questions from API. Status code: " + response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching questions from API: " + ex.Message);
                return null;
            }
        }
    }
}
