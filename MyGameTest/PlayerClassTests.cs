using TriviaLibrary;

namespace MyGameTest
{
    public class PlayerClassTests
    {
        /// <summary>
        /// Test a new players score is set to zero
        /// </summary>
        [Fact]
        public void PlayerStartsWithZeroScore()
        {
            //arrange 
            Player player = new();

            //act
            int initScore = 0;

            //assert
            Assert.Equal(initScore, player.Score);
            
        }

        [Fact]
        public void PlayerNameInitToEmptyString() 
        {
            //arrange
            Player player = new();

            //act
            string name = "";

            //assert
            Assert.Equal(name, player.Name);
        }
    }
}