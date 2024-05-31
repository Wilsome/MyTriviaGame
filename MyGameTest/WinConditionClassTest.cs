using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaLibrary;

namespace MyGameTest
{
    
    public class WinConditionClassTest
    {
        [Fact]
        public void GetWinnerPlayerOneHigherScore() 
        {
            //arrange
            Player one = new() { Score = 5, Name = "wils" };
            Player two = new() { Score = 4, Name = "phils" };

            List<Player> players = new();
            players.Add(one);
            players.Add(two);

            //act
            WinCondition winCondition = new(players);

            string expectedWinner = "wils wins!";

            string actualWinner = winCondition.GetWinner();

            //assert
            Assert.Equal(expectedWinner, actualWinner);
        }

        [Fact]
        public void GetWinnerPlayerTwoHigherScore() 
        {
            //arrange
            Player one = new() { Score = 3, Name = "Wils" };
            Player two = new() { Score = 4, Name = "Spikey boy" };

            List<Player> players = new();
            players.Add(one);
            players.Add(two);

            //act
            WinCondition winCondition = new(players);

            string expectedWinner = $"{two.Name} wins!";

            string actualWinner = winCondition.GetWinner();

            //assset
            Assert.Equal(expectedWinner,actualWinner);
        }
        [Fact]
        public void GetWinnerPlayerTieScoreZeroCorrect() 
        {
            //arrange
            Player one = new() { Score = 0, Name = "Wils" };
            Player two = new() { Score = 0, Name = "Phils" };

            List<Player> players = [one, two];

            //act

            WinCondition winCondition = new(players);

            string expected = "No questions were answered correctly.";

            string actual = winCondition.GetWinner();

            //assert
            Assert.Equal(expected,actual);
        }
    }
}
