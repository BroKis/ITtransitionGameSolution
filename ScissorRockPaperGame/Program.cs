using ScissorRockPaperGame;
using System.Security.Cryptography;

class Program
{
    public static void Main(string[] args)
    {
        if (!ValidateInput(args))
        {
            return;
        }

        Security security = new Security();
        RuleChecker checker = new RuleChecker(args.Length);
        TableGenerator table = new TableGenerator(args);

        bool gameFinished = false;
        while (!gameFinished)
        {
            var key = security.GenerateKey();
            var computerTurn = RandomNumberGenerator.GetInt32(args.Length);
            var hash = security.GenerateHMAC(key, args[computerTurn]);

            Console.WriteLine($"HMAC:{hash}");

            Console.WriteLine("Available moves:");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {args[i]}");
            }
            Console.WriteLine("? - Help");
            Console.WriteLine("0 - Exit");
            Console.Write("Your choice?");
            string choice = Console.ReadLine();

            if (choice == "?")
            {
                table.PrintTable();
                Console.Write("\n\n\n");
                continue;
            }
            if (choice == "0")
            {
                gameFinished = true;
                continue;
            }

            int playerTurn = 0;

            if (!int.TryParse(choice, out playerTurn) || playerTurn <= 0 || playerTurn > args.Length)
            {
                Console.Write("\n\n\n");
                continue;
            }

            Console.WriteLine($"Your turn:{args[playerTurn - 1]}");
            Console.WriteLine($"Computer turn:{args[computerTurn]}");

            Console.WriteLine($"Status:{checker.TurnCheck(computerTurn, playerTurn - 1)}");

            Console.WriteLine($"HMAC:{hash}");
            Console.Write("\n\n\n");
        }
    }
    static bool ValidateInput(string[] args)
    {
        if (args.Length < 3 || args.Length % 2 == 0)
        {
            Console.WriteLine("Invalid input: please write odd numbers which count greater than 3");
            return false;
        }
        else if (args.Length != args.Distinct().Count())
        {
            Console.WriteLine("Invalid input: all moves must be distinct");
            return false;
        }
        return true;
    }
}