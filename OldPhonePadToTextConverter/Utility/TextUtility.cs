using OldPhonePadToTextConverter.Model.Exception;

namespace OldPhonePadToTextConverter.Utility
{
    public static class TextUtility
    {
        #region Public Methods

        public static string OldPhonePad(string input)
        {
            ValidatePhoneNumberInput(input);

            var numberToLetterDictionary = new Dictionary<char, List<char>>()
            {
                { '1', new List<char> { '&', '\'', '(' } },
                { '2', new List<char> { 'A', 'B', 'C' } },
                { '3', new List<char> { 'D', 'E', 'F' } },
                { '4', new List<char> { 'G', 'H', 'I' } },
                { '5', new List<char> { 'J', 'K', 'L' } },
                { '6', new List<char> { 'M', 'N', 'O' } },
                { '7', new List<char> { 'P', 'Q', 'R', 'S' } },
                { '8', new List<char> { 'T', 'U', 'V' } },
                { '9', new List<char> { 'W', 'X', 'Y', 'Z' } }
            };

            var message = string.Empty;
            var processedInput = ProcessOldPhoneNumberInput(input);

            for (var index = 0; index < processedInput.Length; index++)
            {
                var currentChar = processedInput[index];
                // We are initializing the character count as "0" because the lists are "0" index based.
                var characterCount = 0;

                if (currentChar == ' ')
                {
                    // We found a space. No need to calculate the frequencies of the numbers.
                    continue;
                }

                while (index + 1 < processedInput.Length && processedInput[index + 1] == currentChar)
                {
                    // We are calculating the frequency for the numbers to
                    // determine how many times a button is pressed.
                    characterCount++;
                    index++;
                }
                
                // The numbers rotate in a circle.
                // For example, if we press 4 times "2" the value will be "A" 
                // which is equals to pressing "2" only one time.
                // To determine this, we need this divisor. 
                var divisor = GetDivisor(currentChar);
                characterCount %= divisor;

                // Getting the "n-th" element from the list for the current number.
                var letter = numberToLetterDictionary[currentChar].ElementAt(characterCount);
                message += letter;
            }

            return message;
        }

        public static string ReverseString(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            var charArray = text.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }

        #endregion

        #region Private Methods

        private static int GetDivisor(char keyPadNumber)
        {
            // For the key pad number 7 and 9, there are 4 characters.
            // For this reason, the divisor is 4.
            // For the rest of the key pad numbers(2, 3, 4, 5, 6, 8), there are 3 characters.
            // For this reason, the divisor is 3.
            if (keyPadNumber is '7' or '9')
            {
                return 4;
            }
            else
            {
                return 3;
            }
        }

        private static string ProcessOldPhoneNumberInput(string currentNumbers)
        {
            var processedNumbers = string.Empty;
            var numbersStack = new Stack<char>();

            // "*" is considered as "Backspace".
            // If "*" is pressed, the last number is discarded if there is any.
            foreach (var number in currentNumbers)
            {
                if (number == '*')
                {
                    if (numbersStack.Count != 0)
                    {
                        // Stack is not empty. That means there is a number to discard.
                        // Discarding the last number as we do not need it as "BackSpace" was pressed.
                        _ = numbersStack.Pop();
                    }
                }
                else
                {
                    numbersStack.Push(number);
                }
            }

            while (numbersStack.Count != 0)
            {
                processedNumbers += numbersStack.Pop();
            }

            // We need to reverse the "processedNumbers" because when we were popping the numbers from the stack,
            // the numbers were merged in reversed order.
            // To get the original numbers string, we need to reverse that "processedNumbers" that we get from popping the stack.
            return ReverseString(processedNumbers);
        }

        private static void ValidatePhoneNumberInput(string currentNumbers)
        {
            // Only valid character are number from 1 to 9, space, * and #.
            if (string.IsNullOrEmpty(currentNumbers) || !currentNumbers.All(n => n is >= '1' and <= '9' or ' ' or '*' or '#'))
            {
                throw new ServiceValidationBadRequestException("Input should only contain numbers from '1' to '9', 'space', '*' or '#'");
            }
        }

        #endregion

    }
}
