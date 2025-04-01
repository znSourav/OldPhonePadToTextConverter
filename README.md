# Old Phone Pad to Text Converter

## Overview

This project is a console application that simulates an old mobile phone keypad to text converter. Users can enter a sequence of numbers(1-9), spaces, `*` (Backspace), and `#` (Send). The program processes the input based on old mobile keypad rules and outputs the corresponding text message.

## Features

- Converts numeric keypad inputs into text messages.
- Supports `*` for backspace functionality.
- Processes input upon pressing `#`.
- Includes validation to allow only valid characters (`1-9`, space, `*`, and `#`).
- Comprehensive unit tests for reliability.

## How It Works

1. Run the program.
2. Enter numbers (1-9) corresponding to a mobile keypad.
   
   **Key Mapping:**
   
   - `1`: `&`, `'`, `(`
   - `2`: `A`, `B`, `C`
   - `3`: `D`, `E`, `F`
   - `4`: `G`, `H`, `I`
   - `5`: `J`, `K`, `L`
   - `6`: `M`, `N`, `O`
   - `7`: `P`, `Q`, `R`, `S`
   - `8`: `T`, `U`, `V`
   - `9`: `W`, `X`, `Y`, `Z`
   
3. Use `*` to delete the last entered number.
4. Press `#` to process the input and generate the corresponding text message.
5. The processed text is displayed on the console.

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/znSourav/OldPhonePadToTextConverter.git
   ```
2. Open the solution in Visual Studio.
3. Build and run the project.

## File Structure

- `Program.cs`: Main entry point that handles user input.
- `TextUtility.cs`: Contains core logic for processing old phone pad input.
- `TextUtilityTests.cs`: Unit tests to validate functionality.

## Code Breakdown

### `Program.cs`

Handles user input and calls `TextUtility.OldPhonePad` for processing.

### `TextUtility.cs`

- `OldPhonePad(string input)`: Converts numeric input to text based on mobile key mapping.
- `ReverseString(string text)`: Reverses a string.
- `GetNumberOfCharactersAssociatedWithKey(char keyPadNumber)`: Determines character rotation logic for keys.
- `ProcessOldPhoneNumberInput(string currentNumbers)`: Handles backspaces and processes input.
- `ValidatePhoneNumberInput(string currentNumbers)`: Ensures input contains only valid characters.

### `TextUtilityTests.cs`

Unit tests using xUnit to ensure the correctness of `TextUtility` methods.

#### **ReverseString Tests:**

- Handles null, empty, and whitespace inputs.
- Verifies the correct reversal of non-palindromic strings.
- Ensures palindromic strings remain unchanged.

#### **OldPhonePad Tests:**

- Validates incorrect inputs and throws exceptions.
- Ensures correct message conversion for valid inputs.
- Handles cases with excessive backspaces.
- Checks conversion of numeric sequences to text.

### **Unit Test Methods**

#### **ReverseString Tests**

- `ReverseString_InputIsNullOrEmpty_ShouldReturnNullOrEmpty(string stringToReverse)`: Ensures null or empty input returns the same value.
- `ReverseString_InputIsNotNullOrEmpty_ShouldReturnReversedString(string stringToReverse, string expectedString)`: Tests correct reversal of non-palindromic strings.
- `ReverseString_InputIsPalindrome_ShouldNotReversedString(string stringToReverse)`: Ensures palindromic strings remain unchanged.

#### **OldPhonePad Tests**

- `OldPhonePad_InputIsNotValid_ShouldThrowServiceValidationException(string invalidInput)`: Ensures invalid input throws an exception.
- `OldPhonePad_InputContainsOnlyBackSpaces_ShouldReturnEmptyString()`: Ensures input with only backspaces returns an empty string.
- `OldPhonePad_InputContainsMoreBackSpacesThanNumbers_ShouldReturnEmptyString()`: Verifies excessive backspaces lead to an empty string.
- `OldPhonePad_InputIsValid_ShouldReturnProperMessage(string inputNumber, string expectedMessage)`: Validates conversion of numeric sequences to text messages.

### **Test Helper Methods**

- `GetInvalidPhoneNumberData()`: Provides invalid input cases for parameterized testing.

## Running Tests

To execute tests, run the following command:

```sh
 dotnet test
```

## Example Usage

```
Enter your input: 4433555 555666 1 96667775553333
Text message is: HELLO&WORLD
```

## Author

Sourav

