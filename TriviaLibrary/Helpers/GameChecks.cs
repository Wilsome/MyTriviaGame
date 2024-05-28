using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaLibrary.Helpers
{
    public static class GameChecks
    {
        /// <summary>
        /// Checks that players are between 1-4
        /// </summary>
        /// <param name="playerCount"></param>
        /// <returns></returns>
        public static bool ValidatePlayerCount(int playerCount)
        {
            if (playerCount >= 1 && playerCount < 5)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks that question count is between 1-10
        /// </summary>
        /// <param name="questionCount"></param>
        /// <returns></returns>
        public static bool ValidateQuestionCount(int questionCount)
        {
            if (questionCount >= 1 && questionCount < 11)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerNames"></param>
        /// <returns></returns>
        public static string ValidatePlayerNames(string playerNames)
        {
            if (playerNames.Length == 0)
            {
                return "Names cannot be blank";
            }
            if (playerNames.Length > 25)
            {
                return "Max name length is 25 characters.";
            }

            return $"{playerNames} added to the game.";

        }

    }
}
