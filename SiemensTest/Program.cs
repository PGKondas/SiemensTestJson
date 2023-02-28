using System.Text.Json;

namespace SiemensTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            do{
                Console.WriteLine("Please provide a folder or a JSON with folder information");
                input = Console.ReadLine();

                DirData directory = null;
                while (Directory.Exists(input) == false)
                {
                    try
                    {
                        string text = File.ReadAllText(input);
                        directory = JsonSerializer.Deserialize<DirData>(text);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error occurred: {ex.Message}");
                    }
                    Console.WriteLine("Try again:");
                    input = Console.ReadLine();
                }

                if (directory == null)
                {
                    directory = new DirData(new DirectoryInfo(input));
                }
                directory.printoutExtensions();

                Console.WriteLine("\nSave to JSON? y/n");
                input = Console.ReadLine();
                HelpingFunctions.inputChecker(input);
                switch (input)
                {
                    case "y":
                    case "Y":
                        Console.WriteLine("Please provide JSON file location or where and how should the new JSON be named (use .json at the end).");
                        string json = JsonSerializer.Serialize(directory);
                        try
                        {
                            File.WriteAllText(Console.ReadLine(), json);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error occurred: {ex.Message}");
                        }
                        break;
                    case "n":
                    case "N":
                        Console.WriteLine("Understood. Information will not be saved.");
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Would you like to repeat this exercise? y/n ");
                input = Console.ReadLine();
                HelpingFunctions.inputChecker(input);
                Console.WriteLine();
            } while (input == "y" || input == "Y");
        }
    }
}