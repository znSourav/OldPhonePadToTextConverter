using OldPhonePadToTextConverter.Utility;

namespace OldPhonePadToTextConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Instructions:");
            Console.WriteLine("-> Valid numbers are from '1' to '9'");
            Console.WriteLine("-> '*' is considered as 'BackSpace'");
            Console.WriteLine("-> '#' is considered as 'Send' button");
            Console.WriteLine("-> Pressing '#' will generate the result");
            Console.WriteLine("Enter your input: ");

            var input = string.Empty;

            while (true)
            {
                var key = Console.ReadKey();

                if (key.KeyChar == '#')
                {
                    Console.WriteLine();
                    try
                    {
                        var message = TextUtility.OldPhonePad(input);
                        Console.WriteLine($"Text message is: {message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                    finally
                    {
                        input = string.Empty;
                        Console.WriteLine("\nEnter your input: ");
                    }
                }
                else
                {
                    input += key.KeyChar;
                }
            }
        }
    }
}
