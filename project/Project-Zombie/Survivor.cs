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

        public static int getCastSize()
        {
            return castSize;
        }




    }
}
