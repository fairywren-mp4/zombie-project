namespace Project_Zombie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initialize Variables
            string[] survs = new string[10];
            int[][] statBlock = new int[10][];

            int castSize = 0;

            //Introduce story and generate starter characters
            Console.WriteLine("The world has ended, but you have not. 5 survivors remain in a world completely against them.");

            for (int i = 0; i <= 4; i++)
            {
                Console.Write("Enter A Name: ");
                survs[i] = Console.ReadLine()!.Trim().ToUpper();
                statBlock[i] = GenerateCharacter();
                castSize++;
            }

            PrintCast(survs, statBlock);

            while (castSize != 0)
            {

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
        public static void PrintCast(string[] names, int[][] stats)
        {
            Console.WriteLine();
            Console.WriteLine("--- SURVIVOR CAST ---");
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] != null)
                {
                    Console.WriteLine(names[i]);

                    for (int j = 0; j <= 6; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                Console.WriteLine($"STR: {stats[i][j]}");
                                break;

                            case 1:
                                Console.WriteLine($"AGI: {stats[i][j]}");
                                break;

                            case 2:
                                Console.WriteLine($"PRE: {stats[i][j]}");
                                break;

                            case 3:
                                Console.WriteLine($"COM: {stats[i][j]}");
                                break;

                            case 4:
                                Console.WriteLine($"INT: {stats[i][j]}");
                                break;

                            case 5:
                                Console.WriteLine($"KIN: {stats[i][j]}");
                                break;

                            case 6:
                                Console.WriteLine($"END: {stats[i][j]}");
                                break;
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        public static int[,] GenerateMap()
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

        public static void Expedition(string name, int[] stats)
        {
            int[,] map = GenerateMap();
            
        }
    }
}
