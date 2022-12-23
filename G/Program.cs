using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int commandsCount = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < commandsCount; i++)
        {
            string command = Console.ReadLine();
            try
            {
                string result = Shop.GetShop().ProcessCommand(command);
                Console.WriteLine(result);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}