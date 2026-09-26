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
                Console.Write("A few days have passed. The survivors feel ready for an expedition. Who will you send out? ");

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
            Random rng = new Random();
            
            int[,] map = GenerateMap();
            int[] location = [0, 0];
            int events = map[0, 0];
            int time = 1;
            int roll = 0;
            int choice = 0;

            Console.WriteLine();
            Console.WriteLine($"{surv.getName()} arrives at the destination.");

            while (time > 0 || surv.getCom() == 0)
            {
                string move;
                switch (events)
                {
                    case 0:
                        Console.WriteLine("A moment of respite. This spot is quiet, for now.");
                        break;

                    case 1:
                        Console.WriteLine($"{surv.getName()} continues walking as a flurry of small groans appear from the darkness. Step by step, they" +
                            $" get louder, and louder, until suddenly a horde of zombies emerge. What should {surv.getName()} do?\n" +
                            $"1 - Fight back, {surv.getName()} won't go down without a fight.\n" +
                            $"2 - Run. No point in taking an unneccessary risk.\n" +
                            $"3 - Shoot, play it safe, but make an effort to put them down.");
                        choice = MakeChoice();
                        roll = rng.Next(1, 21);
                        if (choice == 1)
                        {
                            roll += surv.getBonus(surv.getStr());
                        } else if (choice == 2)
                        {
                            roll += surv.getBonus(surv.getAgi());
                        } else
                        {
                            roll += surv.getBonus(surv.getPer());
                        }

                        if (roll <= 7)
                        {
                            Console.WriteLine("The survivor's attempts are in vain. They are consumed by the horde.");
                            surv.Kill();
                            return;
                        } else if (roll < 13 && surv.getEnd() > 5)
                        {
                            Console.WriteLine("The survivor is wounded, but escapes with their life.");
                            surv.changeEnd(-5);
                            surv.changeCom(-5);
                            if (surv.getCom() == 0)
                            {
                                return;
                            }
                        } else if (roll < 13)
                        {
                            Console.WriteLine($"{surv.getName()} is wounded escaping the horde. Their wounds are too much to bare and they slowly lose consciousness.");
                            surv.Kill();
                            return;
                        } else
                        {
                            Console.WriteLine($"The zombie numbers trickle down, soon, {surv.getName()} finds themselves alone again, safe.");
                            surv.changeCom(-4);
                            if (surv.getCom() == 0)
                            {
                                return;
                            }
                        }
                        break;

                    case 2:
                        Console.WriteLine($"{surv.getName()} walks further as a deep, putrid smell consumes the room. In the distance, a" +
                            $" strange lump. At closer look, {surv.getName()}'s fears become true: a pile of bodies covered in dried blood.");
                        surv.changeCom(-5);
                        if (surv.getCom() == 0)
                        {
                            return;
                        }
                        break;

                    case 3:
                        Console.WriteLine($"{surv.getName()} continues their search as they notice some slight, shambling footsteps nearby." +
                            $"Suddenly, three zombies appear from the darkness. What will {surv.getName()} do?\n" +
                            $"1 - Fight back, {surv.getName()} won't go down without a fight.\n" +
                            $"2 - Run. No point in taking an unneccessary risk.\n" +
                            $"3 - Shoot, play it safe, but make an effort to put them down.");
                        choice = MakeChoice();
                        roll = rng.Next(1, 21);
                        if (choice == 1)
                        {
                            roll += surv.getBonus(surv.getStr());
                        }
                        else if (choice == 2)
                        {
                            roll += surv.getBonus(surv.getAgi());
                        }
                        else
                        {
                            roll += surv.getBonus(surv.getPer());
                        }

                        if (roll <= 4)
                        {
                            Console.WriteLine("The survivor's attempts are in vain. They are consumed by the group.");
                            surv.Kill();
                            return;
                        }
                        else if (roll < 12 && surv.getEnd() > 2)
                        {
                            Console.WriteLine("The survivor is wounded, but escapes with their life.");
                            surv.changeEnd(-2);
                            surv.changeCom(-4);
                            if (surv.getCom() == 0)
                            {
                                return;
                            }
                        }
                        else if (roll < 12)
                        {
                            Console.WriteLine($"{surv.getName()} is wounded escaping the group. Their wounds are too much to bare and they slowly lose consciousness.");
                            surv.Kill();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"The zombie numbers trickle down, soon, {surv.getName()} finds themselves alone again, safe.");
                            surv.changeCom(-2);
                            if (surv.getCom() == 0)
                            {
                                return;
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine($"{surv.getName()} comes upon a boarded up house, the rudimentary plank barricades slipping" +
                            $" off the front door just enough to get   past. What should {surv.getName()} do?\n" +
                            $"1 - Enter the house, keeping an eye out for danger\n" +
                            $"2 - There is no point in unneccesary risk.");
                        choice = MakeChoice();
                        roll = rng.Next(1, 21);
                        if (choice == 1)
                        {
                            roll += surv.getBonus(surv.getInt());
                            if (roll <= 10 && surv.getEnd() > 2)
                            {
                                Console.WriteLine($"{surv.getName()} enters the home, completely unaware of the rotting planks beneath them. " +
                                    $"They fall through, getting slightly scratched up.");
                                surv.changeEnd(-2);
                                surv.changeCom(-2);
                                if (surv.getCom() == 0)
                                {
                                    return;
                                }
                            } else if (roll <= 10)
                            {
                                Console.WriteLine($"{surv.getName()} enters the home, completely unaware of the rotting planks beneath them. " +
                                    $"They fall through, hitting the ground hard, and never getting back up.");
                                surv.Kill();
                            } else
                            {
                                Console.WriteLine($"{surv.getName()} carefully steps through the house, attempting to avoid the rotting" +
                                    $"floor boards. Inside, they find a book that    improves their faith in the world!");
                                surv.changeKin(2);
                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine($"{surv.getName()} hears an explosion in the distance. Carefully approaching it, they" +
                            $"find an injured survivor next to a burning        vehicle. They try to get the survivor to come with them," +
                            $"but the survivor seems hesitant. What should {surv.getName()} do?\n" +
                            $"1 - Treat the survivor with kindess. Allies are important.\n" +
                            $"2 - Convince the survivor to come with you logically. A community always beats going alone.\n" +
                            $"3 - Use their injured state against them, carry them with you forcefully.");
                        choice = MakeChoice();
                        roll = rng.Next(1, 21);
                        if (choice == 1)
                        {
                            roll += surv.getBonus(surv.getKin());
                        } else if (choice == 2)
                        {
                            roll += surv.getBonus(surv.getInt());
                        } else
                        {
                            roll += surv.getBonus(surv.getStr());
                        }

                        if (roll <= 5 && surv.getEnd() > 3)
                        {
                            Console.WriteLine($"The survivor is frightened by your attempts, attacking {surv.getName()} before they limp away.");
                            surv.changeEnd(-3);
                            surv.changeCom(-4);
                            if (surv.getCom() == 0)
                            {
                                return;
                            }
                        } else if (roll <= 5)
                        {
                            Console.WriteLine($"The survivor is frightened by your attempts, attacking {surv.getName()}. Before they can react, they succumb to their wounds.");
                            surv.Kill();
                        } else if (roll <= 10)
                        {
                            Console.WriteLine("The survivor is unconvinced, escaping into the nearby woods.");
                        } else
                        {
                            Console.WriteLine("The survivor comes with you, resisting very little");
                            Survivor.changeCastSize();
                            return;
                        }
                        break;

                    default:
                        Console.WriteLine($"{surv.getName()} continues their search as they notice some slight, shambling footsteps nearby." +
                            $" Suddenly, a zombie appears    from the darkness. What will {surv.getName()} do?\n" +
                            $"1 - Fight back, {surv.getName()} won't go down without a fight.\n" +
                            $"2 - Run. No point in taking an unneccessary risk.\n" +
                            $"3 - Shoot, play it safe, but make an effort to put them down.");
                        choice = MakeChoice();
                        roll = rng.Next(1, 21);
                        if (choice == 1)
                        {
                            roll += surv.getBonus(surv.getStr());
                        }
                        else if (choice == 2)
                        {
                            roll += surv.getBonus(surv.getAgi());
                        }
                        else
                        {
                            roll += surv.getBonus(surv.getPer());
                        }

                        if (roll <= 1)
                        {
                            Console.WriteLine("The survivor's attempts are in vain. They zombie pounces onto them and consumes them completely.");
                            surv.Kill();
                            return;
                        }
                        else if (roll < 10 && surv.getEnd() > 1)
                        {
                            Console.WriteLine("The survivor is wounded, but escapes with their life.");
                            surv.changeEnd(-1);
                            surv.changeCom(-2);
                            if (surv.getCom() == 0)
                            {
                                return;
                            }
                        }
                        else if (roll < 10)
                        {
                            Console.WriteLine($"{surv.getName()} is wounded escaping the zombie. Their wounds are too much to bare and they slowly lose consciousness.");
                            surv.Kill();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"The zombie is only a slight road block. Soon, {surv.getName()} finds themselves alone again, safe.");
                            surv.changeCom(-1);
                            if (surv.getCom() == 0)
                            {
                                return;
                            }
                        }
                        break;
                }

                map[location[0], location[1]] = -1;

                Console.WriteLine();
                Console.Write($"Where should {surv.getName()} go next? ");

                if (location[0] == 0 && location[1] == 0)
                {
                    move = Movement("EAST", "SOUTH");
                }
                else if (location[0] == 4 && location[1] == 4)
                {
                    move = Movement("NORTH", "WEST");
                }
                else if (location[0] == 0 && location[1] == 4)
                {
                    move = Movement("SOUTH", "WEST");
                } else if (location[0] == 4 && location[1] == 0)
                {
                    move = Movement("NORTH", "EAST");
                }
                else if (location[0] == 0)
                {
                    move = Movement("EAST", "SOUTH", "WEST");
                }
                else if (location[1] == 0)
                {
                    move = Movement("NORTH", "EAST", "SOUTH");
                }
                else if (location[0] == 4)
                {
                    move = Movement("NORTH", "EAST", "WEST");
                }
                else if (location[1] == 4)
                {
                    move = Movement("NORTH", "SOUTH", "WEST");
                }
                else
                {
                    move = Movement("NORTH", "EAST", "SOUTH", "WEST");
                }

                if (move == "NORTH")
                {
                    location[0] -= 1;
                } else if (move == "EAST")
                {
                    location[1] += 1;
                } else if (move == "SOUTH")
                {
                    location[0] += 1;
                } else
                {
                    location[1] -= 1;
                }

                events = map[location[0], location[1]];
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
                Console.Write($"Valid options are {valid1} and {valid2}: ");
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
                Console.Write($"Valid options are {valid1}, {valid2}, and {valid3}: ");
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
                Console.Write($"Valid options are {valid1}, {valid2}, {valid3}, and {valid4}: ");
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

        /// <summary>
        /// Loops until the user enters a valid choice to the prompted question
        /// </summary>
        /// <returns>The user's choice</returns>
        public static int MakeChoice()
        {
            while(true)
            {
                int input = int.Parse(Console.ReadLine()!.Trim());
                if (input == 1 || input == 2 || input == 3)
                {
                    return input;
                } else
                {
                    Console.WriteLine("Invalid Entry.");
                }
            }
        }
    }
}
