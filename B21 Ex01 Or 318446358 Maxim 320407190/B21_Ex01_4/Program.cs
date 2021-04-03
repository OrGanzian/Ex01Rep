using System;

namespace B21_Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            stringAnalysisOutput();
        }

        private static void stringAnalysisOutput()
        {
            string userInput = getUserInput();
            bool palindromeFlag = isPalindrome(userInput);
            string messageOutput = string.Empty;

            if (isInputNumeric(userInput))
            {
                bool dividesBy4 = isDivBy4(userInput);
                messageOutput = string.Format(
@"String from User is: {0}
Is string is a palindrome: {1}
Is number is divisible by 4: {2}
The string contains numbers only",
                    userInput,
                    palindromeFlag,
                    dividesBy4);
            }

            if (isEnglishInput(userInput))
            {
                int uppercaseCounter = uppercaseCount(userInput);
                messageOutput = string.Format(
@"String from User is: {0}
Is string is a palindrome: {1}
Number of English uppercase characters: {2}
The string contains english characters only",
                    userInput,
                    palindromeFlag, 
                    uppercaseCounter);
            }

            Console.WriteLine(messageOutput);
        }

        private static string getUserInput()
        {
            Console.WriteLine(
                "Enter 10 numbers or 10 English characters (and then press enter):");
            while (true)
            {
                string inputString = System.Console.ReadLine();

                if (checkInput(inputString) == false)
                {
                    Console.WriteLine("Invalid string. Enter 10 numbers or 10 English characters (and then press enter):");
                    continue;
                }
                else if (checkInput(inputString) == true)
                {
                    return inputString;
                }
            }
        }

        private static bool checkInput(string i_InputString)
        {
            bool inputValidationFlag = true;

            if (i_InputString.Length != 10)
            {
                inputValidationFlag = false;
            }
            else if (!isEnglishInput(i_InputString) && !isInputNumeric(i_InputString))
            {
                inputValidationFlag = false;
            }

            return inputValidationFlag;
        }

        private static bool isInputNumeric(string i_InputString)
        {
            //// Using Long to cover all 0-9999999999 options
            bool numericFlag = long.TryParse(i_InputString, out long numericOutput);

            return numericFlag;
        }

        private static bool isEnglishInput(string i_InputString)
        {
            bool conditionFlag = true;

            for (int i = 0; i < i_InputString.Length; i++)
            {
                if (!char.IsLetter(i_InputString[i]))
                {
                    conditionFlag = false;
                }
            }

            return conditionFlag;
        }

        private static bool isDivBy4(string i_InputString)
        {
            bool divFlag = true;

            //// Using Long to cover all 0-9999999999 options
            long.TryParse(i_InputString, out long parsedString);
            if (parsedString % 4 != 0)
            {
                divFlag = false;
            }

            return divFlag;
        }

        private static int uppercaseCount(string i_InputString)
        {
            int uppercaseCount = 0;

            for (int i = 0; i < i_InputString.Length; i++)
            {
                if (char.IsUpper(i_InputString[i]))
                {
                    uppercaseCount++;
                }
            }

            return uppercaseCount;
        }
    
    private static bool isPalindrome(string i_UserInput)
        {
            if (i_UserInput.Length <= 1)
            {
                return true;
            }
            else
            {
                if (i_UserInput[0] != i_UserInput[i_UserInput.Length - 1])
                {
                    return false;
                }
                else
                {
                    return isPalindrome(i_UserInput.Substring(1, i_UserInput.Length - 2));
                }
            }
        }
    }
}
