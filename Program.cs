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

    private static void Main(string[] args)
    {
        List<string> choices =
            new List<string>(){
            "Rock",
            "Paper",
            "Scissors"
        };

        Console.WriteLine($"Choose from the following: {string.Join(", ", choices)}");

        string ?UserChoice = Console.ReadLine();

        if (UserChoice == null)
        {
            throw new Exception($"Input cannot be {UserChoice}");
        }

        if (UserChoice == "")
        {
            throw new Exception("Input Not Detected Try Again");
        }

        int UserInput = UserChoiceToInt(UserChoice);

        Console.WriteLine(UserInput);
    }
}