internal class Program
{
    static string CharToString(string userInput)
    {
        Dictionary<char, string> choices =
                new Dictionary<char, string>(){
                    {'r', "Rock" },
                    { 'p', "Paper"},
                    { 's', "Scissors"}
                };
        
        foreach (KeyValuePair<char, string> temp in choices)
        {
            if (char.Parse(userInput) == temp.Key)
            {
                userInput = temp.Value;
                break;
            }
        }

        if (userInput.Length == 1)
        {
            throw new Exception($"{userInput} is not a choice");
        }
        
        return userInput;
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Rock, Paper, or Scissors?");

        string ?userChoice = Console.ReadLine();

        if (userChoice == null)
        {
            throw new Exception($"Input cannot be {userChoice}");
        }

        if (userChoice == "")
        {
            throw new Exception("Input Not Detected Try Again");
        }

        if (userChoice.Length == 1)
        {
            userChoice = CharToString(userChoice);
        }

        
    }
}