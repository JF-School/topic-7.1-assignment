using System.ComponentModel.Design;

namespace topic_7._1_assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            bool done = false;
            double bet;
            int decision;
            double balance = 100;
            Console.WriteLine("Welcome to the CASINO OF ALDWORTH");
            Console.WriteLine("You have " + balance.ToString("C") + " dollars");
            Console.WriteLine();
            Console.WriteLine("There are three games to choose from");
            Console.WriteLine("1. Coin Flip     2. Roulette     3. Wheel of Fortune");
            Console.Write("Which game? ");
            while (!Int32.TryParse(Console.ReadLine(), out decision))
            {
                Console.WriteLine("Invalid number.");
                Console.Write("Which game? ");
            }
            // coin flip (heads or tails)
            if (decision == 1)
            {
                Console.WriteLine("Coin flip!");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("You chose 'COIN FLIP' at the CASINO OF ALDWORTH");
                Console.WriteLine("You will bet on heads or tails, and choose how much you bet");
                Console.WriteLine("or you can just 'quit'.");
                Console.WriteLine("Lose all your money, and you lose!");
                Console.WriteLine();
                Console.WriteLine("You have " + balance.ToString("C"));
                while (!done)
                {
                    Console.Write("How much would you like to bet? ");
                    while (!Double.TryParse(Console.ReadLine(), out bet) || (bet > balance) || (bet < 0))
                    {
                        Console.WriteLine("Invalid number.");
                        Console.Write("How much would you like to bet? ");
                    }
                    Console.Write("Heads or tails? ");
                    string coinFlip = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    Console.WriteLine("Flipping coin...");
                    int coinFlipInt = generator.Next(1, 3);
                    if ((coinFlipInt == 1) && (coinFlip == "heads"))
                    {
                        Console.WriteLine();
                        Console.WriteLine("HEADS!");
                        Console.WriteLine("Good job!");
                        balance = (balance + bet);
                        Console.WriteLine("You now have " + balance.ToString("C"));
                    }
                    else if ((coinFlipInt == 2) && (coinFlip == "tails"))
                    {
                        Console.WriteLine();
                        Console.WriteLine("TAILS!");
                        Console.WriteLine("Congrats!");
                        balance = (balance + bet);
                        Console.WriteLine("You now have " + balance.ToString("C"));
                    }
                    else if ((coinFlipInt == 1) && (coinFlip == "tails"))
                    {
                        Console.WriteLine();
                        Console.WriteLine("HEADS!");
                        Console.WriteLine("Rest in Peace!");
                        balance = (balance - bet);
                        Console.WriteLine("You now have " + balance.ToString("C"));
                    }
                    else if ((coinFlipInt == 2) && (coinFlip == "heads"))
                    {
                        Console.WriteLine();
                        Console.WriteLine("TAILS!");
                        Console.WriteLine("Oof!");
                        balance = (balance - bet);
                        Console.WriteLine("You now have " + balance.ToString("C"));
                    }
                    else if ((coinFlip == "quit") || (balance == 0))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Thanks for playing!");
                        done = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                        Console.WriteLine();
                    }
                }
            }
            // roulette (specific number, red or black, odd or even, high or low)
            else if (decision == 2)
            {
                Console.WriteLine("Roulette!");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("You chose 'ROULETTE' at the CASINO OF ALDWORTH");
                Console.WriteLine("You have a various of options on where to bet.");
                Console.WriteLine();
                while (!done)
                {
                    int betDecision;
                    Console.WriteLine("You have " + balance.ToString("C"));
                    Console.WriteLine("Here are your options for betting");
                    Console.WriteLine("1. Specific Number     2. Red or Black     3. Even or Odd");
                    Console.WriteLine();
                    Console.WriteLine("              4. High or Low         5. Quit");
                    Console.Write("Where do you want to bet? ");
                    while (!Int32.TryParse(Console.ReadLine(), out betDecision) || (betDecision >= 5) || (betDecision <= 0))
                    {
                        Console.WriteLine("Invalid number");
                        Console.Write("Where do you want to bet? ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Reminder: You have " + balance.ToString("C"));
                    Console.Write("How much would you like to bet? ");
                    while (!Double.TryParse(Console.ReadLine(), out bet) || (bet > balance) || (bet < 0))
                    {
                        Console.WriteLine("Invalid number");
                        Console.Write("How much would you like to bet? ");
                    }
                    if (betDecision == 1)
                    {
                        int betNumber;
                        int number = generator.Next(0, 37);
                        Console.WriteLine();
                        Console.WriteLine("You chose 'Specific Number'");
                        Console.WriteLine("Pick a number between 0-36");
                        Console.Write("What number are you betting on? ");
                        while (!Int32.TryParse(Console.ReadLine(), out betNumber) || (betNumber < 0) || (betNumber > 36))
                        {
                            Console.WriteLine("Invalid number");
                            Console.Write("What number are you betting on? ");
                        }
                        if (betNumber == number)
                        {
                            Console.WriteLine();
                            Console.WriteLine("You got the 1/36 chance of getting the right number!");
                            Console.WriteLine("Your balance is now your bet doubled!");
                            balance = (balance + (bet * 2));
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("RIP!");
                            balance = (balance - bet);
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    if (betDecision == 2)
                    {
                        int randColour = generator.Next(1, 3);
                        Console.WriteLine();
                        Console.WriteLine("You chose 'Red or Black'");
                        Console.WriteLine("Choose... Red or Black");
                        Console.Write("Which colour are you choosing? ");
                        string colour = Console.ReadLine().ToLower();
                        if ((randColour == 1) && (colour == "red"))
                        {
                            Console.WriteLine("RED! GOOD JOB!");
                            balance = (balance + bet);
                        }
                        else if ((randColour == 2) && (colour == "black"))
                        {
                            Console.WriteLine("BLACK! GOOD JOB!");
                            balance = (balance + bet);
                        }
                        else if ((randColour == 1) && (colour == "black"))
                        {
                            Console.WriteLine("It was red. You guessed wrong");
                            balance = (balance - bet);
                        }
                        else if ((randColour == 2) && (colour == "red"))
                        {
                            Console.WriteLine("It was black. You guessed wrong");
                            balance = (balance - bet);
                        }    
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                    }
                }
            }
            // wheel of fortune (find the word, spin the wheel)
            else if (decision == 3)
            {
                Console.WriteLine("Wheel of Fortune!");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
