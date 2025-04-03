class Program
{
    static void Main()
    {
        try
        {
            string inputFilePath = @"C:\Users\chida\OneDrive\Documents\code-win\presidio-tasks\csharp\ConsoleApp5\input.txt";
            string outputFilePath = @"C:\Users\chida\OneDrive\Documents\code-win\presidio-tasks\csharp\ConsoleApp5\output.txt";
            string text = File.ReadAllText(inputFilePath);
            int lineCount = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Length;
            int wordCount = text.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
            string output = $"Lines: {lineCount}\nWords: {wordCount}";
            File.WriteAllText(outputFilePath, output);

            Console.WriteLine("Processing complete. Results written to output.txt");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Input file not found: " + ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine("An I/O error occurred: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
