using System.ComponentModel.Design;

namespace topic_7._1_assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            List<string> flips = new List<string>();
            flips.Add("heads");
            flips.Add("tails");
            List<string> rouletteColour = new List<string>();
            rouletteColour.Add("red");
            rouletteColour.Add("black");
            bool done = false;
            bool game = false;
            bool diegame = false;
            double bet;
            int decision;
            double balance = 100;
            
            while (!done)
            {
                game = false;
                Console.WriteLine("Welcome to the CASINO OF ALDWORTH");
                if (balance <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Thanks for playing at the CASINO OF ALDWORTH!");
                    Console.WriteLine("See you next time when you have enough money!");
                    done = true;
                }
                Console.WriteLine("You have " + balance.ToString("C") + " dollars");
                Console.WriteLine();
                Console.WriteLine("There are three games to choose from");
                Console.WriteLine("1. Coin Flip     2. Roulette     3. Doubles  ");
                Console.WriteLine("                   4. Quit                   ");
                Console.Write("Which game? ");
                while (!Int32.TryParse(Console.ReadLine(), out decision))
                {
                    Console.WriteLine("Invalid number.");
                    Console.Write("Which game? ");
                }
                // quit
                if ((decision == 4))
                {
                    Console.WriteLine();
                    Console.WriteLine("Thanks for playing at the CASINO OF ALDWORTH!");
                    done = true;
                }
                // coin flip (heads or tails)
                else if (decision == 1)
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
                    // game = coin flip
                    while (!game)
                    {
                        if (balance <= 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Thanks for playing at the CASINO OF ALDWORTH!");
                            Console.WriteLine("Come back next time when you have enough money.");
                            game = true;
                            done = true;
                        }
                        else if (balance != 0)
                        {
                            Console.WriteLine();
                            Console.Write("Heads, tails, or quit? ");
                            string userFlip = Console.ReadLine().ToLower().Trim();
                            if (userFlip == "quit")
                            {
                                Console.WriteLine();
                                Console.WriteLine("Thanks for playing 'COIN FLIP' at the CASINO OF ALDWORTH!");
                                Console.WriteLine("Press ENTER to Continue");
                                Console.ReadLine();
                                Console.Clear();
                                game = true;
                            }
                            else if (userFlip != "quit")
                            {
                                Console.Write("How much would you like to bet? ");
                                while (!Double.TryParse(Console.ReadLine(), out bet) || (bet > balance) || (bet < 0))
                                {
                                    Console.WriteLine("Invalid number.");
                                    Console.Write("How much would you like to bet? ");
                                }
                                Console.WriteLine();
                                Console.WriteLine("Flipping coin...");
                                string coinFlip = flips[generator.Next(2)];
                                if (coinFlip == userFlip)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(coinFlip);
                                    Console.WriteLine("Congrats! You got it correct!");
                                    balance += bet;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                }
                                else if (coinFlip != userFlip)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(coinFlip);
                                    Console.WriteLine("Incorrect, unfortunateley.");
                                    balance -= bet;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input.");
                                    Console.WriteLine();
                                }
                            } 
                        }
                    }
                }
                // roulette (specific number, red or black, even or odd, high or low)
                else if (decision == 2)
                {
                    Console.WriteLine("Roulette!");
                    Console.WriteLine("Press ENTER to continue");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("You chose 'ROULETTE' at the CASINO OF ALDWORTH");
                    Console.WriteLine("You have a various of options on where to bet.");
                    Console.WriteLine();
                    while (!game)
                    {
                        int betDecision;
                        if (balance <= 0)
                        {
                            Console.WriteLine("Thanks for playing at the CASINO OF ALDWORTH!");
                            Console.WriteLine("Come back when you have more money!");
                            game = true;
                            done = true;
                        }
                        else if (balance != 0)
                        {
                            Console.WriteLine("You have " + balance.ToString("C"));
                            Console.WriteLine("Here are your options for betting");
                            Console.WriteLine("1. Specific Number     2. Red or Black     3. Even or Odd");
                            Console.WriteLine();
                            Console.WriteLine("              4. High or Low         5. Quit");
                            Console.Write("Where do you want to bet? ");
                            while (!Int32.TryParse(Console.ReadLine(), out betDecision) || (betDecision > 5) || (betDecision <= 0))
                            {
                                Console.WriteLine("Invalid number");
                                Console.Write("Where do you want to bet? ");
                            }
                            // quit
                            if ((betDecision == 5) || (balance <= 0))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Thanks for playing 'ROULETTE' at the CASINO OF ALDWORTH!");
                                Console.WriteLine("Press ENTER to Continue");
                                Console.ReadLine();
                                Console.Clear();
                                game = true;
                            }
                            // specific number
                            if (betDecision == 1)
                            {
                                int betNumber;
                                int number = generator.Next(0, 37);
                                Console.WriteLine();
                                Console.WriteLine("Reminder: You have " + balance.ToString("C"));
                                Console.Write("How much would you like to bet? ");
                                while (!Double.TryParse(Console.ReadLine(), out bet) || (bet > balance) || (bet < 0))
                                {
                                    Console.WriteLine("Invalid number");
                                    Console.Write("How much would you like to bet? ");
                                }
                                Console.WriteLine();
                                Console.WriteLine("You chose 'Specific Number'");
                                Console.WriteLine("Pick a number between 0-36");
                                Console.Write("What number are you betting on? ");
                                while (!Int32.TryParse(Console.ReadLine(), out betNumber) || (betNumber <= 0) || (betNumber > 36))
                                {
                                    Console.WriteLine("Invalid number");
                                    Console.Write("What number are you betting on? ");
                                }
                                if (betNumber == number)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("You got the 1/36 chance of getting the right number!");
                                    Console.WriteLine("The number was " + number);
                                    Console.WriteLine("Your balance is now your bet doubled!");
                                    balance = (balance + (bet * 2));
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else if (betNumber == 0)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("The number was " + number + " which means you lose everything!");
                                    balance = 0;
                                    Console.WriteLine();
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else if (betNumber != number)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("RIP! The number was " + number);
                                    balance -= bet;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                            }
                            // red or black
                            else if (betDecision == 2)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Reminder: You have " + balance.ToString("C"));
                                Console.Write("How much would you like to bet? ");
                                while (!Double.TryParse(Console.ReadLine(), out bet) || (bet > balance) || (bet < 0))
                                {
                                    Console.WriteLine("Invalid number");
                                    Console.Write("How much would you like to bet? ");
                                }
                                Console.WriteLine();
                                Console.WriteLine("You chose 'Red or Black'");
                                Console.WriteLine("Choose... Red or Black");
                                Console.WriteLine("Inputting wrongly will cost ya");
                                Console.WriteLine();
                                Console.Write("Which colour are you choosing? ");
                                string colour = Console.ReadLine().ToLower().Trim();
                                string randColour = rouletteColour[generator.Next(2)];
                                if (randColour == colour)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(randColour.ToUpper() + "! GOOD JOB!");
                                    balance += bet;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else if (randColour != colour)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("It was " + randColour + ". You guessed wrong.");
                                    balance -= bet;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                            }
                            // even or odd
                            else if (betDecision == 3)
                            {
                                int evenOddNumber = generator.Next(0, 36);
                                Console.WriteLine();
                                Console.WriteLine("Reminder: You have " + balance.ToString("C"));
                                Console.Write("How much would you like to bet? ");
                                while (!Double.TryParse(Console.ReadLine(), out bet) || (bet > balance) || (bet < 0))
                                {
                                    Console.WriteLine("Invalid number");
                                    Console.Write("How much would you like to bet? ");
                                }
                                Console.WriteLine();
                                Console.WriteLine("You chose 'Even or Odd'");
                                Console.WriteLine("You must guess whether the number chosen will be even or odd.");
                                Console.Write("Even or Odd? ");
                                string evenOddGuess = Console.ReadLine().ToLower();
                                if ((evenOddNumber % 2 == 0) && (evenOddGuess == "even"))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("The number was " + evenOddNumber + " and that is " + evenOddGuess + "!");
                                    balance += bet;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else if ((evenOddNumber % 2 == 0) && (evenOddGuess == "odd"))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("The number was " + evenOddNumber + " and that isn't " + evenOddGuess + "!");
                                    balance -= bet;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else if ((evenOddNumber % 2 == 1) && (evenOddGuess == "odd"))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("The number was " + evenOddNumber + " and that is " + evenOddGuess + "!");
                                    balance += bet;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else if ((evenOddNumber % 2 == 1) && (evenOddGuess == "even"))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("The number was " + evenOddNumber + " and that isn't " + evenOddGuess + "!");
                                    balance -= bet;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else if (evenOddNumber == 0)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("The number was " + evenOddNumber + " which means you lose all your money!");
                                    balance = 0;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Invalid input! Try again at the menu!");
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                            }
                            // high or low
                            else if (betDecision == 4)
                            {
                                int hiLowNumber = generator.Next(0, 37);
                                Console.WriteLine();
                                Console.WriteLine("Reminder: You have " + balance.ToString("C"));
                                Console.Write("How much would you like to bet? ");
                                while (!Double.TryParse(Console.ReadLine(), out bet) || (bet > balance) || (bet < 0))
                                {
                                    Console.WriteLine("Invalid number");
                                    Console.Write("How much would you like to bet? ");
                                }
                                Console.WriteLine();
                                Console.WriteLine("You chose 'High or Low'");
                                Console.WriteLine("You must guess if the number will be in the low-range of numbers, or the high-range of numbers.");
                                Console.WriteLine("Low range: 1-18. High range: 19-36");
                                Console.Write("High or Low? ");
                                string hiGuess = Console.ReadLine().ToLower();
                                if ((hiLowNumber <= 18) && (hiGuess == "low"))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("The number was " + hiLowNumber + " which is in the " + hiGuess + " range.");
                                    balance += bet;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else if ((hiLowNumber >= 19) && (hiGuess == "high"))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("The number was " + hiLowNumber + " which is in the " + hiGuess + " range.");
                                    balance += bet;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else if ((hiLowNumber <= 18) && (hiGuess == "high"))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("The number was " + hiLowNumber + " which isn't in the " + hiGuess + " range.");
                                    balance -= bet;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else if ((hiLowNumber >= 19) && (hiGuess == "low"))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("The number was " + hiLowNumber + " which isn't in the " + hiGuess + " range.");
                                    balance -= bet;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else if (hiLowNumber == 0)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("The number was " + hiLowNumber + " which means you lose all your money!");
                                    balance = 0;
                                    Console.WriteLine("You now have " + balance.ToString("C"));
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Invalid input! Try again at the menu!");
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                            }
                        }
                    }
                }
                // doubles (bet on rolling higher)
                else if (decision == 3)
                {
                    int dice1, dice2;
                    Console.WriteLine("Doubles!");
                    Console.WriteLine("Press ENTER to Continue");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("You chose 'DOUBLES' at the CASINO OF ALDWORTH");
                    Console.WriteLine("You and a bot will roll a dice.");
                    Console.WriteLine("If your die roll is higher than theirs, you win bet money");
                    Console.WriteLine("If your die roll is lower than theirs, you lose bet money");
                    Console.WriteLine("If you both get a double, the bet is doubled.");
                    Console.WriteLine("If the bet is higher than your balance, you lose all your remaining money if you lose.");
                    Console.WriteLine();
                    Console.WriteLine("Press ENTER to continue");
                    Console.ReadLine();
                    while (!game)
                    {
                        diegame = false;
                        if (balance <= 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Thanks for playing at the CASINO OF ALDWORTH!");
                            Console.WriteLine("Come back when you have more money!");
                            game = true;
                            done = true;
                        }
                        if (balance != 0)
                        {
                            Console.Write("Roll or Quit? ");
                            string diceReady = Console.ReadLine().ToLower().Trim();
                            if (diceReady == "quit")
                            {
                                Console.WriteLine();
                                Console.WriteLine("Thanks for playing 'DOUBLES' at the CASINO OF ALDWORTH!");
                                Console.WriteLine("Press ENTER to Continue");
                                Console.ReadLine();
                                Console.Clear();
                                game = true;
                            }
                            else if (diceReady == "roll")
                            {
                                Console.WriteLine();
                                Console.WriteLine("Reminder: You have " + balance.ToString("C"));
                                Console.Write("How much would you like to bet? ");
                                while (!Double.TryParse(Console.ReadLine(), out bet) || (bet > balance) || (bet < 0))
                                {
                                    Console.WriteLine("Invalid number");
                                    Console.Write("How much would you like to bet? ");
                                }
                                while (!diegame)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Rolling dice...");
                                    dice1 = generator.Next(1, 7);
                                    dice2 = generator.Next(1, 7);
                                    Console.WriteLine();
                                    Console.WriteLine("You rolled a " + dice1);
                                    Console.WriteLine("Your opponent rolled a " + dice2);
                                    if (dice1 > dice2)
                                    {
                                        Console.WriteLine("Congrats!");
                                        balance += bet;
                                        Console.WriteLine("You have " + balance.ToString("C"));
                                        diegame = true;
                                    }
                                    else if (dice1 < dice2)
                                    {
                                        Console.WriteLine("Unfortunately, you lost.");
                                        balance -= bet;
                                        Console.WriteLine("You have " + balance.ToString("C"));
                                        diegame = true;
                                    }
                                    else if (dice1 == dice2)
                                    {
                                        Console.WriteLine("You both got the same!");
                                        Console.WriteLine("Bet has been doubled!");
                                        bet = (bet * 2);
                                        Console.WriteLine("The bet is now " + bet.ToString("C") + " and your balance is " + balance.ToString("C"));
                                        Console.WriteLine("Press ENTER to Continue");
                                        Console.ReadLine();
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Invalid input!");
                            }
                        }
                        
                    }
                }
            }
        }
    }
}
