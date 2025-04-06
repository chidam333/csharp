class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            using var client = new HttpClient();
            var url = "https://api.open-meteo.com/v1/forecast?latitude=13&longitude=80&current_weather=true";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Weather response: {content}");
            var task1 = Task.Run(async () =>
            {
                await Task.Delay(1000);
                return 10;
            });
            var task2 = Task.Run(async () =>
            {
                await Task.Delay(1500);
                return 20;
            });
            var task3 = Task.Run(async () =>
            {
                await Task.Delay(500);
                return 30;
                // return await Task.FromException<int>(new Exception("Simulated error"));
            });

            var results = await Task.WhenAll(task1, task2, task3);
            var sum = results[0] + results[1] + results[2];
            Console.WriteLine($"Sum of results: {sum}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}