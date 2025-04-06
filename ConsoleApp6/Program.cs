
public class Counter
{
    public delegate void ThresholdReachedHandler(int threshold);
    public event ThresholdReachedHandler ThresholdReached;
    private int count;
    private int threshold;
    public Counter(int threshold)
    {
        this.threshold = threshold;
    }
    public void Increment()
    {
        count++;
        if (count == threshold)
        {
            ThresholdReached?.Invoke(threshold);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var counter = new Counter(5);
        counter.ThresholdReached += Handler1;
        counter.ThresholdReached += Handler2;

        for (int i = 0; i < 7; i++)
        {
            counter.Increment();
            Console.WriteLine($"Counter incremented to {i + 1}");
        }
    }
    static void Handler1(int threshold)
    {
        Console.WriteLine($"Handler1: Threshold of {threshold} reached.");
    }

    static void Handler2(int threshold)
    {
        Console.WriteLine("Second handeler.");
    }
}

