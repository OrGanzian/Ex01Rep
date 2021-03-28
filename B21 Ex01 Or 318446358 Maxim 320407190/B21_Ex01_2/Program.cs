using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B21_Ex01_2
{
    class Program
    {
        static public void Main()
        {
            RecursiveClockPrint(0, 5, 1);
            Console.ReadLine();
        }


        public static void RecursiveClockPrint(int offset, int stars, int inc)
        {

            if (offset < 0 && inc < 0)
            {
                return;
            }


            printLine(offset, stars);

            if (stars == 1)
            {
                inc = -1;
            }

            RecursiveClockPrint(offset + inc, stars - inc, inc);

        }

        public static void printLine(int offset, int stars)
        {
            for (int i = 0; i < offset; i++)
            {
                Console.Write(" ");

            }
               
            // Print stars with a space 
            for (int i = 0; i < stars; i++)
            {
                Console.Write("* ");

            }
            // Print a new line 
            Console.WriteLine();
        }
    }
}
