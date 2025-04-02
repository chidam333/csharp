Console.Write("Enter a positive integer: ");
var input = Console.ReadLine();
if (int.TryParse(input, out int number) && number >= 0)
{
    long factorial = 1;
    for (int i = 1; i <= number; i++)
        factorial *= i;
    Console.WriteLine($"\nFactorial of {number} is {factorial}");
}
else
{
    Console.WriteLine("Invalid input. Please enter a positive integer.");
}

Console.Write("\nPress Enter to exit...");
Console.Read();