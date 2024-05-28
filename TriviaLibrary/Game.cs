using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaLibrary.Interfaces;

namespace TriviaLibrary
{
    public class Game : IQuestionProvider
    {
        private IUserInput userInput;
        private IUserOutput userOutput;

        public bool ConfirmedQuestionsCount;

        public bool ConfirmedPlayerCount;

        public List<Round> Rounds { get; set; }
        public List<Player> Players { get; set; }
        public List<Question> Questions { get; set; }

        public Game(IUserInput userInput, IUserOutput userOutput)
        {
            Questions = [];
            Players = [];
            Rounds = [];
            this.userInput = userInput;
            this.userOutput = userOutput;
            ConfirmedPlayerCount = false;
            ConfirmedQuestionsCount = false;
        }

        public DateTime Date { get; set; } = DateTime.Now;
        public string Winner { get; set; } = string.Empty;
        public int NumberOfPlayers { get; set; }
        public int NumberOfQuestions { get; set; }
        public int CategoryOfQuestions { get; set; }
        public string Difficulty { get; set; } = string.Empty;

        private int currentQuestionIndex = 0;

        /// <summary>
        /// starts the Game and determine how many rounds to play.
        /// </summary>
        /// <param name="numQuestionsToUse"></param>
        public void Start(int numQuestionsToUse)
        {
            ShuffleQuestions(); // Shuffle questions before starting the game

            // Start rounds until all questions are exhausted or the player's desired number of questions is reached
            for (int i = 0; i < numQuestionsToUse; i++)
            {
                Round round = new Round(Players, this, userInput, userOutput);
                round.PlayRound();
            }
        }

        /// <summary>
        /// Attempts to shuffle questions provided by the API
        /// </summary>
        private void ShuffleQuestions()
        {
            Random rng = new Random();
            int n = Questions.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Question value = Questions[k];
                Questions[k] = Questions[n];
                Questions[n] = value;
            }
        }

        public Question GetNextQuestion()
        {
            // Check if there are questions left
            if (currentQuestionIndex < Questions.Count)
            {
                Question nextQuestion = Questions[currentQuestionIndex];
                currentQuestionIndex++; // Move to the next question
                return nextQuestion;
            }
            else
            {
                // If all questions have been exhausted, return null or handle as needed
                return null;
            }
        }

    }
}
