namespace Project_Zombie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Survivor[] survs = new Survivor[10];

            //Introduce story and generate starter characters
            Console.WriteLine("The world has ended, but you have not. 5 survivors remain in a world completely against them.");

            for (int i = 0; i <= 4; i++)
            {
                Console.Write("Enter A Name: ");
                string name = Console.ReadLine()!.Trim().ToUpper();
                int[] stats = GenerateCharacter();
                Survivor surv = new Survivor(stats[0], stats[1], stats[2], stats[3], stats[4], stats[5], stats[6], name);
                survs[i] = surv;
            }

            PrintCast(survs);

            while (Survivor.getCastSize() != 0)
            {
                Console.WriteLine();
                Console.Write("The survivors feel ready for an expedition, who will you send out? ");

                while (true)
                {
                    string adventurer = Console.ReadLine()!.Trim().ToUpper();
                    for (int i = 0; i < Survivor.getCastSize(); i++)
                    {
                        if (adventurer == survs[i].getName())
                        {
                            Console.WriteLine($"{adventurer} will go out!");
                            Expedition(survs[i]);
                            return;
                        } 
                    }
                    Console.WriteLine("Invalid Entry.");
                }
            }
        }

        /// <summary>
        /// Generates stats for a character
        /// </summary>
        /// <returns>The list of stats for the generated character</returns>
        public static int[] GenerateCharacter()
        {
            Random rng = new Random();
            int[] charBlock = new int[7];

            for (int i = 0; i <= 6; i++)
            {
                int result = rng.Next(5, 16);
                charBlock[i] = result;
            }

            return charBlock;
        }

        /// <summary>
        /// Prints out the cast of survivors
        /// </summary>
        /// <param name="names">The array containing survivor names</param>
        /// <param name="stats">The array containing survivor stats</param>
        public static void PrintCast(Survivor[] names)
        {
            Console.WriteLine();
            Console.WriteLine("--- SURVIVOR CAST ---");
            Console.WriteLine();
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] != null)
                {
                    Console.WriteLine(names[i]);
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Randomly generates a map for use in expeditions
        /// </summary>
        /// <returns>The generated map</returns>
        private static int[,] GenerateMap()
        {
            Random rng = new Random();
            
            int[,] map = new int[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    map[i, j] = rng.Next(0, 2);
                }
            }

            for (int k = 0; k < 5; k++)
            {
                for (int l = 0; l < 5; l++)
                {
                    if (map[k, l] == 1)
                    {
                        map[k, l] = rng.Next(1, 10);
                    } 
                }
            }

            return map;
        }

        public static void Expedition(Survivor surv)
        {
            int[,] map = GenerateMap();
            int[] location = [0, 0];
            int events = map[0, 0];
            int time = 1;

            Console.WriteLine();
            Console.WriteLine($"{surv.getName()} arrives at the destination.");

            while (time > 0)
            {
                string move;
                switch (events)
                {
                    case 0:
                        Console.WriteLine("A moment of respite. This spot is quiet, for now.");
                        break;

                    default:
                        Console.WriteLine("Unadded for now");
                        break;

                }

                Console.WriteLine();
                Console.Write($"Where should {surv.getName()} go next? ");

                if (location[0] == 0 && location[1] == 0)
                {
                    move = Movement("EAST", "SOUTH");
                } else if (location[0] == 5 && location[1] == 5)
                {
                    move = Movement("NORTH", "WEST");
                } else if (location[0] == 0)
                {
                    move = Movement("EAST", "SOUTH", "WEST");
                } else if (location[1] == 0)
                {
                    move = Movement("NORTH", "EAST", "SOUTH");
                } else if (location[0] == 5)
                {
                    move = Movement("NORTH", "EAST", "WEST");
                } else if (location[1] == 5)
                {
                    move = Movement("NORTH", "SOUTH", "WEST");
                } else
                {
                    move = Movement("NORTH", "EAST", "SOUTH", "WEST");
                }
            }
        }

        /// <summary>
        /// Prompts the user for a movement option and loops until a valid option is returned. 
        /// </summary>
        /// <param name="valid1"> Valid Option</param>
        /// <param name="valid2"> Valid Option</param>
        /// <returns>The User's choice</returns>
        private static string Movement(string valid1, string valid2)
        {
            while (true)
            {
                Console.Write($"Valid options are {valid1} and {valid2}");
                string result = Console.ReadLine()!.Trim().ToUpper();

                if (result == valid1 || result == valid2)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid Entry. ");
                }
            }
        }

        private static string Movement(string valid1, string valid2, string valid3)
        {
            while (true)
            {
                Console.Write($"Valid options are {valid1}, {valid2}, and {valid3}");
                string result = Console.ReadLine()!.Trim().ToUpper();

                if (result == valid1 || result == valid2 || result == valid3)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid Entry. ");
                }
            }
        }

        private static string Movement(string valid1, string valid2, string valid3, string valid4)
        {
            while (true)
            {
                Console.Write($"Valid options are {valid1}, {valid2}, {valid3}, and {valid4}");
                string result = Console.ReadLine()!.Trim().ToUpper();

                if (result == valid1 || result == valid2 || result == valid3 || result == valid4)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid Entry. ");
                }
            }
        }
    }
}
