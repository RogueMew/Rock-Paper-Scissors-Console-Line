internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Rock, Paper, or Scissors");


        string userChoice = Console.ReadLine();


        if (userChoice == null)
        {
            throw new Exception("Input cannot be ");
        }

        if (userChoice == "")
        {
            Console.WriteLine("Hello")
        }

        Console.WriteLine(userChoice.Length);
    }
}