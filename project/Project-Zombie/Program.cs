using System.Security.Cryptography;

namespace Project_Zombie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] survs = new string[10];
            int[][] statBlock = new int[10][];

            for (int i = 0; i <= 4; i++)
            {
                Console.Write("Enter A Name: ");
                survs[i] = Console.ReadLine()!.Trim().ToUpper();
                statBlock[i] = GenerateCharacter();
            }

            PrintCast(survs, statBlock);
        }

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
    }
}
