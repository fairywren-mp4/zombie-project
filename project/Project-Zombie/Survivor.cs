using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Zombie
{
    internal class Survivor
    {
        //Creates static variable
        private static int castSize;

        //create stats variables
        private string name;
        private int str;
        private int agi;
        private int per;
        private int com;
        private int inte;
        private int kin;
        private int end;
        private bool alive;

        public Survivor(int s, int a, int p, int c, int i, int k, int e, string n)
        {
            str = s;
            agi = a;
            per = p;
            com = c;
            inte = i;
            kin = k;
            end = e;
            name = n;
            alive = true;
            castSize++;
        }

        public override string ToString()
        {
            return ($"--{name}--\nSTR: {str}\nAGI: {agi}\nPER: {per}\nCOM: {com}\nINT: {inte}\nKIN: {kin}\nEND: {end}" );
        }

        public string getName()
        {
            return name;
        }

        public int getStr()
        {
            return str;
        }

        public int getPer()
        {
            return per;
        }

        public int getAgi()
        {
            return agi;
        }

        public int getCom()
        {
            return com;
        }

        public int getEnd()
        {
            return end;
        }

        public int getInt()
        {
            return inte;
        }

        public int getKin()
        {
            return kin;
        }

        public void changeEnd(int value)
        {
            if (end + value <= 20 || end - value >= 0)
            {
                end += value;
            } else if (value > 0)
            {
                end = 20;
            }
        }

        public void changeCom(int value)
        {
            if (com + value <= 20 || com - value >= 0)
            {
                com += value;
            } else if (value > 0)
            {
                com = 20;
            } else
            {
                com = 0;
            }
        }

        public void changeKin(int value)
        {
            if (kin + value <= 20 || kin - value >= 0)
            {
                kin += value;
            }
            else if (value > 0)
            {
                kin = 20;
            }
            else
            {
                kin = 0;
            }
        }

        public static void changeCastSize()
        {
            if (castSize < 10)
            {
                castSize++;
            }
        }

        public void Kill()
        {
            alive = false;
        }

        /// <summary>
        /// Returns the character's stat bonus based on their stat number
        /// </summary>
        /// <param name="stat">The stat being measured</param>
        /// <returns>The bonus the survivor gets</returns>
        public int getBonus(int stat)
        {
            if (stat == 1)
            {
                return -5;
            } else if (stat < 4)
            {
                return -4;
            } else if (stat < 6)
            {
                return -3;
            } else if (stat < 8)
            {
                return -2;
            } else if (stat < 10)
            {
                return -1;
            } else if (stat < 12)
            {
                return 0;
            } else if (stat < 14)
            {
                return 1;
            } else if (stat < 16)
            {
                return 2;
            } else if (stat < 18)
            {
                return 3;
            } else if (stat < 20)
            {
                return 4;
            } else
            {
                return 5;
            }
        }

        public static int getCastSize()
        {
            return castSize;
        }




    }
}
