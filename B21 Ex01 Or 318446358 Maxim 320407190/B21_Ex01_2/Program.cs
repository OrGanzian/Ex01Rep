using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B21_Ex01_2
{
    public class Program
    {
        static public void Main()
        {
            RecursiveClockPrint(0, 7, 1);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }


        public static void RecursiveClockPrint(int i_NumOfSpaces, int i_NumOfStars, int i_IncrementValue)
        {

            if (i_NumOfSpaces < 0 && i_IncrementValue < 0)
            {
                return;
            }

            if (i_NumOfStars % 2 != 0)
            {
                printLine(i_NumOfSpaces, i_NumOfStars);
            }

            if (i_NumOfStars == 1)
            {
                i_IncrementValue = -1;
            }

            RecursiveClockPrint(i_NumOfSpaces + i_IncrementValue, i_NumOfStars - i_IncrementValue, i_IncrementValue);

        }

        public static void printLine(int i_Offset, int i_Stars)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < i_Offset; i++)
            {
                builder.Append(" ");
            }

            for (int i = 0; i < i_Stars; i++)
            {
                builder.Append("* ");
            }

            Console.WriteLine(builder);
        }

    }

}
