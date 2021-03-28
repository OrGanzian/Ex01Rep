using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace B21_Ex01_3
{
    class Program
    {

        static public void Main()
        {
            SmartClockPrinter();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }



        static public int GetUserSizeInput()
        {
         
                Console.WriteLine("please enter the sand clock size");
                int userInput=0;
                bool valid = int.TryParse(Console.ReadLine(), out userInput);

                while (!valid || userInput < 1)
                {
                    Console.WriteLine("please enter the sand clock size");
                    valid = int.TryParse(Console.ReadLine(), out userInput);
                }

                return userInput;
            
        }

        static public void SmartClockPrinter()
        {
            int size = GetUserSizeInput();
            B21_Ex01_2.Program.RecursiveClockPrint(0, size, 1);



        }


    }




}
