using System;

namespace B21_Ex01_3
{
    public class Program
    {
        public static void Main()
        {
            SmartClockPrinter();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        public static int GetUserSizeInput()
        {
            Console.WriteLine("please enter the sand clock size");
            int userInput = 0;
            bool valid = int.TryParse(Console.ReadLine(), out userInput);

            while (!valid || userInput < 1)
            {
                Console.WriteLine("please enter the sand clock size");
                valid = int.TryParse(Console.ReadLine(), out userInput);
            }

            return userInput;
        }

        public static void SmartClockPrinter()
        {
            int size = GetUserSizeInput();
            B21_Ex01_2.Program.RecursiveClockPrint(0, size, 1);
        }
    }
}
