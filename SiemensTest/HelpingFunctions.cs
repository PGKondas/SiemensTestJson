using System.Runtime.CompilerServices;

namespace SiemensTest
{
    internal class HelpingFunctions
    {
        public static void inputChecker(string input) {
            while ((input != "n" && input != "N") && (input != "y" && input != "Y")) {
                Console.WriteLine("Unrecognized input, try again.");
                input = Console.ReadLine();
            }
        }
    }
}
