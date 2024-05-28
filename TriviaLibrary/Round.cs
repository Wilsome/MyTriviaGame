using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaLibrary.Interfaces;
using System.Net;
using TriviaLibrary.Helpers;

namespace TriviaLibrary
{
    public class Round
    {
        private List<Player> players;
        private IUserInput userInput;
        private IUserOutput userOutput;
        private IQuestionProvider questionProvider;

        public Round(List<Player> players, IQuestionProvider questionProvider, IUserInput userInput, IUserOutput userOutput)
        {
            this.players = players;
            //this.question = question;
            this.userInput = userInput;
            this.userOutput = userOutput;
            this.questionProvider = questionProvider;
        }

        /// <summary>
        /// Starts a round for the required number of questions. 
        /// </summary>
        public void PlayRound()
        {
            bool previousPlayerCorrect = false;

            foreach (var player in players)
            {
                if (!previousPlayerCorrect)
                {
                    Question currentQuestion = questionProvider.GetNextQuestion();
                    if (currentQuestion != null)
                    {
                        AskQuestion(player, currentQuestion);

                    }
                    else
                    {
                        // Handle case where all questions have been exhausted
                        break;
                    }
                }
                else
                {
                    // Generate a new question only if the previous player answered correctly
                    Question currentQuestion = questionProvider.GetNextQuestion();
                    if (currentQuestion != null)
                    {
                        AskQuestion(player, currentQuestion);

                    }
                    else
                    {
                        // Handle case where all questions have been exhausted
                        break;
                    }
                }

                // Update previousPlayerCorrect based on the current player's answer
                previousPlayerCorrect = player.AnsweredCorrectly;
            }
        }

        /// <summary>
        /// Determines if players question is a true/false or answer specific
        /// </summary>
        /// <param name="player"></param>
        /// <param name="question"></param>
        private void AskQuestion(Player player, Question question)
        {
            if (question.IsBooleanQuestion)
            {
                AskBooleanQuestion(player, question);
            }
            else
            {
                AskNonBooleanQuestion(player, question);
            }
        }

        /// <summary>
        /// Ask the user a bool question and check correctness. 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="question"></param>
        private void AskBooleanQuestion(Player player, Question question)
        {

            userOutput.WriteLine($"Player {player.Name}, here's your question:");
            string decodedQuestion = WebUtility.HtmlDecode(question.Text);
            userOutput.WriteLine(decodedQuestion);
            userOutput.WriteLine("");
            userOutput.WriteLine("Please answer True or False:");
            string answer = userInput.ReadLine();
            userOutput.WriteLine("");

            if (StringSimilarityHelper.AreStringsSimilar(answer, question.CorrectAnswer))
            {

                userOutput.Clear();
                userOutput.TextColor("Correct!", "green");

                player.Score++;
                player.AnsweredCorrectly = true;
                userOutput.WriteLine("");
            }
            else
            {
                userOutput.Clear();
                userOutput.TextColor("Incorrect", "red");

                player.AnsweredCorrectly = false;
                userOutput.WriteLine("");
            }


        }

        /// <summary>
        /// Ask the user a non bool question, allow 3 attempts
        /// provided correct answer if attempts exhausted. 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="question"></param>
        private void AskNonBooleanQuestion(Player player, Question question)
        {

            int attempts = 0;
            bool answeredCorrectly = false;

            while (attempts < 3 && !answeredCorrectly)
            {
                //promts user and captures response
                userOutput.WriteLine($"Player {player.Name}, here's your question (Attempt {attempts + 1}):");
                string decodedQuestion = WebUtility.HtmlDecode(question.Text);
                userOutput.WriteLine(decodedQuestion);
                userOutput.WriteLine("");
                userOutput.WriteLine("Please provide your answer:");
                string answer = userInput.ReadLine();
                userOutput.WriteLine("");

                bool isCorrect;

                if (question.RequiresExactMatch)
                {
                    isCorrect = answer.Equals(question.CorrectAnswer, StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    isCorrect = StringSimilarityHelper.AreStringsSimilar(answer, question.CorrectAnswer);
                }

                //users answers correctly
                if (isCorrect)
                {

                    userOutput.Clear();
                    userOutput.TextColor($"Correct!, the answer was {question.CorrectAnswer}", "green");
                    userOutput.WriteLine("");
                    player.Score += 1;
                    answeredCorrectly = true;
                }
                else
                {
                    //user gets 3 attempts to answer correctly.
                    if (attempts < 3)
                    {
                        userOutput.Clear();
                        userOutput.TextColor("Incorrect, Please try again.", "Yellow");
                        userOutput.WriteLine("");
                        attempts++;
                    }

                    if (attempts == 3)
                    {
                        userOutput.Clear();
                        userOutput.TextColor("Incorrect", "red");
                        userOutput.WriteLine("");
                    }

                }


            }

            //display correct answer at the end of all attempts. 
            if (!answeredCorrectly)
            {
                userOutput.Write($"Player {player.Name}, ");
                userOutput.TextColor("you've used all your attempts for this question.", "blue");
                userOutput.Write("The correct answer is ");
                userOutput.TextColor($"{question.CorrectAnswer}", "green");
                userOutput.WriteLine("");
            }
        }
    }
}
