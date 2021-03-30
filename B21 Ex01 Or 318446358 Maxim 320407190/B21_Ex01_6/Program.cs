using System;

namespace B21_Ex01_6
{
    public class Program
    {
        public static void Main()
        {
            numberStatistics();
        }

        private static void numberStatistics()
        {
            int number;

            Console.WriteLine("Hello User.{0}Please enter 6-digit positive integer (and then press enter): ", Environment.NewLine);
            getUserInput(out number);
            outputStatistics(number);
        }

        private static void getUserInput(out int io_Number) 
        {
            string stringNumber = Console.ReadLine();
            bool parsingFlag = int.TryParse(stringNumber, out io_Number);
            if (io_Number < 0 || stringNumber.Length != 6)
            {
                parsingFlag = false;
            }

            while (!parsingFlag)
            {
                Console.WriteLine("Wrong Input,please try again :");
                stringNumber = Console.ReadLine();
                parsingFlag = int.TryParse(stringNumber, out io_Number);
                if (io_Number < 0 || stringNumber.Length != 6)
                {
                    parsingFlag = false;
                }
            }
        }

        private static void outputStatistics(int i_Number) 
        {
            int maxNumber = 0;
            int minNumber = 0;
            int numbersDividedBy3 = 0;
            int numbersBiggerThanLastSignificant = 0;

            maxNumber = findMaxNumber(i_Number);
            minNumber = findMinNumber(i_Number);
            numbersDividedBy3 = howManyNumbersDividedBy3(i_Number);
            numbersBiggerThanLastSignificant = howManyBiggerThanLastSignificant(i_Number);
            string messageToUser = string.Format
(@"
The biggest number is : {0}.
The smallest number is : {1}.
The total count of numbers which divides by '3' is : {2}.
The total count of numbers which bigger than most right significant digit is : {3}.{4}
        ", maxNumber, minNumber, numbersDividedBy3, numbersBiggerThanLastSignificant, Environment.NewLine);
            Console.WriteLine(messageToUser);
        }

        private static int howManyBiggerThanLastSignificant(int i_Number)
        {
            int biggerThanLastSignificant = 0;
            int numberLength = integerCounter(i_Number);

            if (i_Number < 10)
            {
                return biggerThanLastSignificant;
            }

            int rightDigit = i_Number % 10;
            i_Number /= 10;

            for (int i = 0; i < numberLength; i++)
            {
                if ((i_Number % 10) > rightDigit)
                {
                    biggerThanLastSignificant++;
                }

                i_Number /= 10;
            }

            return biggerThanLastSignificant;
        }

        private static int integerCounter(int i_Number) 
        {
            int integerCounterNumber = 1;
            if (i_Number < 10)
            {
                return integerCounterNumber;
            }

            while (i_Number > 10)
            {
                integerCounterNumber++;
                i_Number /= 10;
            }

            return integerCounterNumber;
        }

        private static int howManyNumbersDividedBy3(int i_Number)
        {
            int divBy3 = 0;
            int numberLength = integerCounter(i_Number);

            if (i_Number < 10)
            {
                if (i_Number % 3 == 0)
                {
                    divBy3++;
                    return divBy3;
                }
            }

            for (int i = 0; i < numberLength; i++)
            {
                if ((i_Number % 10) % 3 == 0)
                {
                    divBy3++;
                }

                i_Number /= 10;
            }

            return divBy3;
        }

        private static int findMaxNumber(int i_Number) 
        {
            int maxNumber = 0;

            if (i_Number < 10)
            {
                return i_Number;
            }

            int right = i_Number % 10;
            int left = (i_Number / 10) % 10;
            if (right > left)
            {
                maxNumber = right;
            }
            else
            {
                maxNumber = left;
            }

            return (findMaxNumber(i_Number / 10) > maxNumber) ? findMaxNumber(i_Number / 10) : maxNumber;
        }

        private static int findMinNumber(int i_Number)
        {
            int minNumber = 0;

            if (i_Number < 10)
            {
                return i_Number;
            }

            int right = i_Number % 10;
            int left = (i_Number / 10) % 10;
            if (right < left)
            {
                minNumber = right;
            }
            else
            {
                minNumber = left;
            }

            return (findMinNumber(i_Number / 10) < minNumber) ? findMinNumber(i_Number / 10) : minNumber;
        }
    }
}
