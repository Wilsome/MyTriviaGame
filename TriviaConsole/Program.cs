//init a new game
using TriviaLibrary;
using TriviaLibrary.Helpers;
using TriviaLibrary.Interfaces;
using TriviaLibrary.Services;

IUserInput userInput = new ConsoleUserInput();
IUserOutput userOutput = new ConsoleUserOutput();

//create new game object
Game game = new(userInput, userOutput);

int players = 0;
int numOfQuestion = 0;

//get number of players
while (players < 1 || players > 4)
{
    Console.Clear();
    try
    {
        Console.WriteLine("Enter number of players for today's game (between 1 and 4):");
        players = int.Parse(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.Clear();
    }
}

//check 
bool checkedPlayers = GameChecks.ValidatePlayerCount(players);
if (checkedPlayers == true)
{
    game.ConfirmedPlayerCount = true;
    game.NumberOfPlayers = players;
}
else
{
    while (game.ConfirmedPlayerCount == false)
    {
        Console.Clear();
        Console.WriteLine("Must have between 1-4 players. ");
        Console.WriteLine("Enter number of players for todays game.");
        players = int.Parse(Console.ReadLine());
        //check 
        checkedPlayers = GameChecks.ValidatePlayerCount(players);
        if (checkedPlayers == true)
        {
            game.ConfirmedPlayerCount = true;
            game.NumberOfPlayers = players;
            Console.Clear();
        }
    }

}

Console.Clear();

//get number of questions
while (numOfQuestion < 1 || numOfQuestion > 10)
{
    Console.Clear();
    try
    {
        Console.WriteLine("How many Questions for this game?(1-10)");

        numOfQuestion = int.Parse(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.Clear();
    }
}

//need to get more questions then requested, so when a play answers correctly
//a new question will be provided
game.NumberOfQuestions = numOfQuestion * game.NumberOfPlayers;
Console.Clear();

//going to default all questions to easy for now
game.Difficulty = "easy";

//display and capture trivia categories
DisplayCategories display = new(userOutput);
display.GetCategories();
string category = Console.ReadLine();
game.CategoryOfQuestions = CategoryToId.GetCategoryId(category);
Console.Clear();

//get and set names of players
for (int i = 0; i < game.NumberOfPlayers; i++)
{
    Console.WriteLine($"Enter the name of player {i + 1}");


    //create a new player
    Player player = new()
    {
        Name = Console.ReadLine(),
        Score = 0,
    };

    //check to make sure name isnt blank
    while (player.Name.Length < 1)
    {
        Console.Clear();
        Console.WriteLine("Player name cannot be blank.");
        Console.WriteLine();
        Console.WriteLine($"Enter the name of player {i + 1}");
        player.Name = Console.ReadLine();
        Console.Clear();
    }

    //add player to list
    game.Players.Add(player);
    Console.Clear();
}


//get list of questions
Task<List<Question>> gameQuestions = QuestionService.GetQuestions(game.NumberOfQuestions, game.CategoryOfQuestions, game.Difficulty);
game.Questions = gameQuestions.Result;


game.Start(numOfQuestion);


//create win condition object to determine the winner
WinCondition win = new(game.Players);

userOutput.WriteLine(win.DisplayScores());

//userOutput.WriteLine($"{win.GetWinner()}");
userOutput.TextColor(win.GetWinner(), "green");


