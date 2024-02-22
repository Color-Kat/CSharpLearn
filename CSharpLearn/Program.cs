namespace CSharpLearn
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("/* --- Guess The Number Game --- */");
            Console.Write("Enter the max number (define the difficulty): ");

            int minNumber = 1, maxNumber = 0;
            maxNumber = Convert.ToInt32(Console.ReadLine());

            Random random = new Random();
            int randValue = random.Next(minNumber, maxNumber);
            int attemptsCountRest = (int) Math.Sqrt(Convert.ToDouble(maxNumber));

            for(int i = attemptsCountRest; i > 0; i--)
            {
                if (attemptsCountRest == i) Console.WriteLine($"You have {i} attempts, guess the number.");
                else Console.WriteLine($"You have {i} fucking attempts, guess this motherfucking number!");

                Console.Write("And your variant is: ");
                
                int guessedNumber = Convert.ToInt32(Console.ReadLine());
                if ( guessedNumber != randValue )
                {
                    Console.WriteLine("You're damn wrong!");

                    if (i == 1)
                    {
                        Console.WriteLine("You have ran out of attempts.\nGet the fuck out of here! Please");
                        Console.WriteLine("The right answer was " + randValue);
                    }
                }
                else
                {
                    Console.WriteLine(
                        "Oh, shit, this nigga is god damn right!\n" +
                        "I can't belive it, you won a million dollars, nigga!"
                    );
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}