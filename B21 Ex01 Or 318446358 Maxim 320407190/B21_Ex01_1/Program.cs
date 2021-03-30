using System;
using System.Text;

namespace B21_Ex01_1 
{
    public class Program
    {
        public static void Main()
        {
            BinaryMenuProgram();
        }

        public static void BinaryMenuProgram()
        {
            StringBuilder binaryString = new StringBuilder();

            Console.WriteLine(string.Format("Hello User, Please choose from the menu :{0}", System.Environment.NewLine));
            Console.WriteLine(string.Format("1: 1111011 ,1101110 ,1000000 .(Input example){0}2: 0010111 ,0110000 ,0011100 .(Input example)", System.Environment.NewLine));
            Console.WriteLine(string.Format("3: 1011111 ,1101111 ,0110011 .(Input example){0}4: Input from keyboard.{0}", System.Environment.NewLine));
            string userChoiceFromMenu = Console.ReadLine();
            while (userChoiceFromMenu != "1" && userChoiceFromMenu != "2" && userChoiceFromMenu != "3" && userChoiceFromMenu != "4")
            {
                Console.WriteLine("Wrong Input,please try again");
                userChoiceFromMenu = Console.ReadLine();
            }

            if (userChoiceFromMenu == "1")
            {
                binaryString.Append("111101111011101000000");
            }
            else if (userChoiceFromMenu == "2")
            {
                binaryString.Append("001011101100000011100");
            }
            else if (userChoiceFromMenu == "3")
            {
                binaryString.Append("101111111011110110011");
            }
            else if (userChoiceFromMenu == "4")
            {
                binaryString = getUserInput();
            }

            printBinaryStringStatistics(binaryString);
        }

        private static void printBinaryStringStatistics(StringBuilder i_BinaryString)
        {
            int zerosCount = 0;
            int onesCount = 0;
            double avgZeros = 0;
            double avgOnes = 0;
            int exponentCount = 0;
            int scallingUpNumberCount = 0;
            int[] allDecimalNumbersArray = new int[3];
            int maxNumber = 0;
            int minNumber = 0;
            StringBuilder decimalNumbersString = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                StringBuilder smallBinarySeriesString = new StringBuilder(7);

                for (int j = i * 7; j < (i * 7) + 7; j++)
                {
                    smallBinarySeriesString.Append(i_BinaryString[j].ToString());
                }

                int decimalNumber = binaryStringToDeciamlConverter(smallBinarySeriesString);
                zerosAndOnesCount(smallBinarySeriesString, ref zerosCount, ref onesCount);
                checkIfExponentOfTwo(ref exponentCount, smallBinarySeriesString);
                isScallingUp(ref scallingUpNumberCount, decimalNumber);
                allDecimalNumbersArray[i] = decimalNumber;
                string decimalString = string.Format("Binary: {0} --> Decimal: {1}{2} ", smallBinarySeriesString.ToString(), decimalNumber, System.Environment.NewLine);
                decimalNumbersString.Append(decimalString);
            }

            checkMinMaxNumbersInArray(ref minNumber, ref maxNumber, allDecimalNumbersArray);
            avgZeros = zerosCount / 3;
            avgOnes = onesCount / 3;
            string messageToUser = string.Format
(@"The average number of zero's is : {0}.
The average number of one's is : {1}.
The number of decimals in the power of two is : {2}.
The number of ascending sequences is : {3}.
The highest number is : {4}.
The lowest number is : {5}.
The numbers are:{7} {6}
        ", avgZeros, avgOnes, exponentCount, scallingUpNumberCount, maxNumber, minNumber, decimalNumbersString, System.Environment.NewLine);
            Console.WriteLine(messageToUser);
        }

        private static void checkMinMaxNumbersInArray(ref int minNumber, ref int maxNumber, int[] allDecimalNumbersArray)
        {
            minNumber = allDecimalNumbersArray[0];
            maxNumber = allDecimalNumbersArray[0];
            for (int i = 0; i < allDecimalNumbersArray.Length - 1; i++)
            {
                if (allDecimalNumbersArray[i + 1] > allDecimalNumbersArray[i] && allDecimalNumbersArray[i + 1] > maxNumber)
                {
                    maxNumber = allDecimalNumbersArray[i + 1];
                }
                else if (allDecimalNumbersArray[i + 1] < minNumber)
                {
                    minNumber = allDecimalNumbersArray[i + 1];
                }
            }
        }

        private static void isScallingUp(ref int io_ScallingUpNumberCount, int i_DecimalNumber)
        {
            int rightNumber = 0;
            int leftNumber = 0;

            if (i_DecimalNumber < 10)
            {
                return;
            }
            else
            {
                while (i_DecimalNumber > 10)
                {
                    rightNumber = i_DecimalNumber % 10;
                    leftNumber = (i_DecimalNumber / 10) % 10;
                    if (rightNumber <= leftNumber)
                    {
                        return;
                    }
                    else
                    {
                        i_DecimalNumber /= 10;
                    }
                }

                io_ScallingUpNumberCount++;
            }
        }

        private static void checkIfExponentOfTwo(ref int io_ExponentCounter, StringBuilder i_SmallBinarySeriesString)
        {
            int oneCounter = 0;

            for (int i = 0; i < 7; i++)
            {
                if (i_SmallBinarySeriesString[i].ToString() == "1")
                {
                    oneCounter++;
                }
            }

            // If the number is a power of two, then only 1 bit will be set in its binary representation
            if (oneCounter == 1)
            {
                io_ExponentCounter++;
            }
        }

        private static void zerosAndOnesCount(StringBuilder i_SmallBinarySeriesString, ref int io_ZerosCount, ref int io_OnesCount)
        {
            for (int i = 0; i < 7; i++)
            {
                if (i_SmallBinarySeriesString[i].ToString() == "1")
                {
                    io_OnesCount++;
                }
                else
                {
                    io_ZerosCount++;
                }
            }
        }

        private static StringBuilder getUserInput()
        {
            StringBuilder stringResponse = new StringBuilder(21);
            bool correctBinaryNumber = true;

            for (int i = 0; i < 3; i++)
            {
                StringBuilder stringBinaryNumber = new StringBuilder(8);
                Console.WriteLine(string.Format("Enter {1} binary number:{0}", System.Environment.NewLine, i + 1));
                stringBinaryNumber.Append(Console.ReadLine());
                correctBinaryNumber = checkUserInput(stringBinaryNumber);
                if (correctBinaryNumber == true)
                {
                    stringResponse.Append(stringBinaryNumber);
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again");
                    i--;
                }
            }

            return stringResponse;
        }

        private static bool checkUserInput(StringBuilder i_UserInputString)
        {
            bool binaryValidation = true;

            binaryValidation = i_UserInputString.Length == 7;
            if (binaryValidation == true)
            {
                for (int i = 0; i < i_UserInputString.Length; i++)
                {
                    binaryValidation = (i_UserInputString[i].ToString() == "0") || (i_UserInputString[i].ToString() == "1");
                    if (binaryValidation != true)
                    {
                        break;
                    }
                }
            }

            return binaryValidation;
        }

        private static int binaryStringToDeciamlConverter(StringBuilder i_BinaryNumberSeries)
        {
            int lengthOfStringSequence = i_BinaryNumberSeries.Length;
            double binaryNumber = 0;
            lengthOfStringSequence -= 1;
            for (int i = 0; i < i_BinaryNumberSeries.Length; i++)
            {
                if (i_BinaryNumberSeries[i].ToString() == "1")
                {
                    binaryNumber += Math.Pow(2, lengthOfStringSequence);
                }

                lengthOfStringSequence--;
            }

            return (int)binaryNumber;
        }
    }
}