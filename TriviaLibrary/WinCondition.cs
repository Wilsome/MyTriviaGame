using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaLibrary.Interfaces;

namespace TriviaLibrary
{
    public class WinCondition(List<Player> players)
    {
       
        /// <summary>
        /// Check which user/s answered the most questions correctly
        /// </summary>
        /// <returns></returns>
        public string GetWinner()
        {
            int currentHigh = 0;

            // Find the highest score
            foreach (Player player in players)
            {
                if (player.Score > currentHigh)
                {
                    currentHigh = player.Score;
                }
            }

            // Find all players with the highest score
            List<string> winners = new List<string>();
            foreach (Player player in players)
            {
                if (player.Score == currentHigh)
                {
                    winners.Add(player.Name);
                }
            }

            if (currentHigh == 0)
            {
                return "No questions were answered correctly.";
            }
            else if (winners.Count == 1)
            {
                return $"{winners[0]} wins!";
            }
            else
            {
                return $"Game is tied between: {string.Join(", ", winners)}.";
            }
        }

        /// <summary>
        /// Display the score for each player.
        /// </summary>
        /// <returns></returns>
        public string DisplayScores() 
        {
            StringBuilder sb = new();

            foreach (Player player in players)
            {
                 sb.Append($"{player.Name} answered {player.Score} questions correctly. \n");
            }

            return sb.ToString();
        }
    }

}
