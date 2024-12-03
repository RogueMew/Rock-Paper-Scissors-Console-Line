using System.Runtime.InteropServices;

internal class Program
{
    static int UserChoiceToInt(string UserInput)
    {
        if (UserInput.Length == 1)
        {
            char UserInputChar = UserInput[0];
            int UserChoice = 0;

            Dictionary<char, int> choices =
                    new Dictionary<char, int>(){
                    {'r', 1 },
                    { 'p', 2},
                    { 's', 3}
                    };

            if (choices.TryGetValue(UserInputChar, out UserChoice))
            {
                return UserChoice;
            }

            throw new Exception($"{UserInput} is not an option");
        }
        else
        {
            int UserChoice = 0;
            Dictionary<string, int> choices =
                    new Dictionary<string, int>(){
                    {"rock", 1 },
                    { "paper", 2},
                    { "scissor" , 3}
                    };

            if (choices.TryGetValue(UserInput.ToLower(), out UserChoice))
            {
                return UserChoice;
            }

            throw new Exception($"{UserInput} is not an option");
        }

    }

    static int ComputerChoice()
    {
        Random rand = new Random();

        int ComputerChoice = rand.Next(1,4);

        return ComputerChoice;
    }

    static string ComputerChoiceToString(int ComputerChoice)
    {
        string OutputString = "";

        Dictionary<int, string> choices =
                new Dictionary<int, string>(){
                    {1 , "rock"},
                    {2, "paper"},
                    {3, "scissor"}
                };

        if (choices.TryGetValue(ComputerChoice, out OutputString))
        {
            return OutputString;
        }
        else
        {
            throw new Exception("Somehow You Fucked Up Computer");
        }
    }

    static string GameLogic(int ComputerChoice, int UserChoice)
    {
        if (UserChoice == ComputerChoice)
        {
            return "tie";
        }
        else if (UserChoice > ComputerChoice && (UserChoice == 1 && UserChoice < ComputerChoice))
        {
            return "User";
        }
        else
        {
            return "Computer";
        }
    }

    static string UserChoiceString()
    {
        List<string> choices =
            new List<string>(){
            "Rock",
            "Paper",
            "Scissors"
        };

        Console.WriteLine($"Choose from the following: {string.Join(", ", choices)}");

        string? UserChoice = Console.ReadLine();

        if (UserChoice == null)
        {
            throw new Exception($"Input cannot be {UserChoice}");
        }

        if (UserChoice == "")
        {
            throw new Exception("Input Not Detected Try Again");
        }

        return UserChoice;
    }
    
    static bool ContinueGame()
    {
        string ?UserChoiceToContinue = Console.ReadLine();
        if(UserChoiceToContinue == null || UserChoiceToContinue == "")
        {
            return true;
        }else if (UserChoiceToContinue.Length == 1)
        {
            if (UserChoiceToContinue.ToLower()[0] == 'y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (UserChoiceToContinue.ToLower() == "yes")
            {
                return true;
            }else if (UserChoiceToContinue.ToLower() == "no")
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }

    private static void Main(string[] args)
    {
        bool PlayGame = true;
        while (PlayGame == true)
        {
            string UserChoice = UserChoiceString();
            int UserInput = UserChoiceToInt(UserChoice);
            int ComputerInput = ComputerChoice();
            Console.WriteLine($"\nComputer Chose: {ComputerChoiceToString(ComputerInput)}");
            string winner = GameLogic(UserInput, ComputerInput);
            Console.WriteLine($"\nWinner {winner}");
            Console.WriteLine("\nContinue Game (y/n)");
            PlayGame = ContinueGame();
        }
     }
}