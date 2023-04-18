using System;

namespace CalculatorNS
{
    static class Calculator
    {
        private static int operationsDone = 0;
        private static char[] commands = {'Q', 'A', 'S', 'M', 'D', 'N'};
        public static int OperationsDone 
        {
            get { return operationsDone;}
        }
        
        private static int Add(int x, int y)
        {
            return x + y;
        }

        private static int Sub(int x, int y)
        {
            return x - y;
        }

        private static int Mult(int x, int y)
        {
            return x * y;
        }

        private static int Div(int x, int y)
        {
            return x * y;
        }

        private static (char, int, int) GetUserInput()
        {
            char cmd = 'X';
            int x = 0;
            int y = 0;

            Console.WriteLine("Getting user input...\n");
            
            string? userInput = Console.ReadLine();

            if(!String.IsNullOrEmpty(userInput)) {
            
                string[] args = userInput.Split(' ');

                if (args.Length == 3)
                {
                    char.TryParse(args[0], out cmd);
                    int.TryParse(args[1], out x);
                    int.TryParse(args[2], out y);
                }

            }
            return (cmd, x, y);
        }

        private static bool RunCmd(char cmd, int x, int y)
        {
            if (commands.Contains(cmd))
            {
                switch(cmd)
                {
                    case 'Q':
                        return false;
                    case 'A':
                        Console.WriteLine(Add(x, y));
                        return true;
                    case 'S':
                        Console.WriteLine(Sub(x, y));
                        return true;
                    case 'M':
                        Console.WriteLine(Mult(x, y));
                        return true;
                    case 'D':
                        Console.WriteLine(Div(x, y));
                        return true;
                    default:
                        Console.WriteLine("This message should not be seen, shutting down.");
                        return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid Command, please try again.");
                return true;
            }
            
        }
        public static void Run()
        {
            bool run = true;
            while (run)
            {
                char cmd = ':';
                int x = 0;
                int y = 0;
                (cmd, x, y) = GetUserInput();
                run = RunCmd(cmd, x, y);
            }
            Console.WriteLine("Calculator shut down.\nThank you for using me!");
        }
    }
}