using OldPhonePadToTextConverter.Utility;

namespace OldPhonePadToTextConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter text and press '#' to process:");

            var input = string.Empty;

            while (true)
            {
                var key = Console.ReadKey();

                if (key.KeyChar == '#')
                {
                    Console.WriteLine();
                    var message = TextUtility.OldPhonePad(input);
                    Console.WriteLine(message);
                    input = string.Empty;
                }
                else
                {
                    input += key.KeyChar;
                }
            }
        }
    }
}
