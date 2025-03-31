using OldPhonePadToTextConverter.Model.Exception;
using OldPhonePadToTextConverter.Utility;

namespace OldPhonePadToTextConverterTests.Utility
{
    public class TextUtilityTests
    {
        #region Test Method

        #region ReverseString

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void ReverseString_InputIsNullOrEmpty_ShouldReturnNullOrEmpty(string stringToReverse)
        {
            // Arrange & Act
            var reversedString = TextUtility.ReverseString(stringToReverse);

            // Assert
            Assert.Equal(stringToReverse, reversedString);
        }

        [Theory]
        [InlineData("abc xyz", "zyx cba")]
        [InlineData("223 443 @@ ^&", "&^ @@ 344 322")]
        [InlineData("   asd 221 !@ A   ", "   A @! 122 dsa   ")]
        public void ReverseString_InputIsNotNullOrEmpty_ShouldReturnReversedString(string stringToReverse, string expectedString)
        {
            // Arrange & Act
            var reversedString = TextUtility.ReverseString(stringToReverse);

            // Assert
            Assert.Equal(expectedString, reversedString);
        }

        [Theory]
        [InlineData("bbabb")]
        [InlineData("asdfghjhgfdsa")]
        [InlineData("  AWD DWA  ")]
        public void ReverseString_InputIsPalindrome_ShouldNotReversedString(string stringToReverse)
        {
            // Arrange & Act
            var reversedString = TextUtility.ReverseString(stringToReverse);

            // Assert
            Assert.Equal(stringToReverse, reversedString);
        }

        #endregion

        #region OldPhonePad

        [Theory]
        [MemberData(nameof(GetInvalidPhoneNumberData))]
        public void OldPhonePad_InputIsNotValid_ShouldThrowServiceValidationException(string invalidInput)
        {
            // Arrange & Act
            var exception = Record.Exception(() => TextUtility.OldPhonePad(invalidInput));
            
            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ServiceValidationBadRequestException>(exception);
        }

        [Fact]
        public void OldPhonePad_InputContainsOnlyBackSpaces_ShouldReturnEmptyString()
        {
            // Arrange
            var input = "*****"; // "*" is considered as 'BackSpace'

            // Act
            var result = TextUtility.OldPhonePad(input);
            
            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void OldPhonePad_InputContainsMoreBackSpacesThanNumbers_ShouldReturnEmptyString()
        {
            // Arrange
            var input = "222 ***** 22 ****"; // "*" is considered as 'BackSpace'

            // Act
            var result = TextUtility.OldPhonePad(input);

            // Assert
            Assert.Empty(result);
        }

        [Theory]
        [InlineData("222222", "C")]
        [InlineData("4433555 555666 1 96667775553333", "HELLO&WORLD")]
        [InlineData("4444433333555555 555555666666 1111 9999966666677777775555553333333", "HELLO&WORLD")]
        [InlineData("4666 6663116 66677766444664", "GOOD'MORNING")]
        [InlineData("6 666 666 66", "MOON")]
        [InlineData("6666666 666666666 666666666 66666666", "MOON")]
        [InlineData("6666666**66 6666*666666 666666666****6666 666**6666666", "MOON")]
        public void OldPhonePad_InputIsValid_ShouldReturnProperMessage(string inputNumber, string expectedMessage)
        {
            // Arrange & Act
            var result = TextUtility.OldPhonePad(inputNumber);

            // Assert
            Assert.Equal(expectedMessage, result);
        }

        #endregion

        #endregion

        #region Test Helper Methods

        public static IEnumerable<object[]> GetInvalidPhoneNumberData()
        {
            yield return new object[] { null };
            yield return new object[] { "" };
            yield return new object[] { "1234567890" };
            yield return new object[] { "1234567890*#" };
            yield return new object[] { "1234567890*#1234567890*#" };
            yield return new object[] { "ABSKJHkjhaskdjh12345" };
            yield return new object[] { "$^&#98529345615297635" };
        }

        #endregion

    }
}
