using static System.Net.Mime.MediaTypeNames;

namespace CSharpLearn
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.CursorVisible = false;

            char[,] map =
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#','#'},
                {'#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', 'X', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', '#'},
                {'#', ' ', ' ', '#', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', '#', '#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', ' ', ' ', '#'},
                {'#', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', '#'},
                {'#', ' ', '#', ' ', ' ', 'X', '#', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', '#'},
                {'#', ' ', '#', '#', '#', '#', '#', ' ', ' ', '#', ' ', ' ', '#', ' ', 'X', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', 'X', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '#', ' ', ' ', '#'},
                {'#', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', '#', ' ', 'X', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#','#'},
            };

            // Display info message
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("- ".Repeat(map.GetLength(1)));
            string header = "Control";
            string separator = " ".Repeat((map.GetLength(1) * 2 - 2 - header.Length) / 2);
            Console.WriteLine("|" + separator + header + separator + "|");
            Console.WriteLine("- ".Repeat(map.GetLength(1)));

            Console.WriteLine("| Up Arrow    - move up");
            Console.WriteLine("| Right Arrow - move right");
            Console.WriteLine("| Down Arrow  - move down");
            Console.WriteLine("| Left Arrow  - move left");
            Console.WriteLine("_".Repeat(map.GetLength(1) * 2 - 1));

            // Variables
            int stepX = 2;
            int userX = 8, userY = 6;
            int money = 0;

            while (true)
            {
                // Display money
                Console.SetCursorPosition(0, map.GetLength(0) + 2);
                Console.Write($"Money: {money}");

                // Draw map
                Console.SetCursorPosition(0, 0);

                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                // Draw user position
                Console.SetCursorPosition(userX * stepX, userY);
                Console.Write('@');

                // Movement
                ConsoleKeyInfo charKey = Console.ReadKey();

                switch(charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[userY - 1, userX] != '#')
                        {
                            userY--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[userY + 1, userX] != '#')
                        {
                            userY++;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[userY, userX + 1] != '#')
                        {
                            userX++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map[userY, userX - 1] != '#')
                        {
                            userX--;
                        }
                        break;
                }

                if (map[userY, userX] == 'X')
                {
                    money++;
                    map[userY, userX] = ' ';
                }


                // Console.Clear();

                // Game end
                if (money >= 10) break;
            }

            Console.Clear();

            string text = "Thanks for playing!";
            Console.SetCursorPosition((Console.WindowWidth / 2) - (text.Length / 2), Console.WindowHeight / 2);
            Console.Write(text);
            Console.WriteLine("\n".Repeat(Console.WindowHeight / 2));
            Console.WriteLine("Author - @ColorKat");
        }
    }

    // Extention of standard string class
    // That adds the repaeat method
    public static class StringExtensions
    {
        public static string Repeat(this string instr, int n)
        {
            var result = string.Empty;

            for (var i = 0; i < n; i++)
                result += instr;

            return result;
        }
    }
}