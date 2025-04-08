
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute : Attribute
{
    public string Description { get; set; }
    public RunnableAttribute() { Description = "This method is runnable"; }
}

// Sample class 1 with a runnable method
public class ExampleClass1
{
    [Runnable(Description = "This method says hello")]
    public void SayHello()
    {
        Console.WriteLine("Hello from ExampleClass1");
    }

    public void NotRunnableMethod()
    {
        Console.WriteLine("This method is not runnable");
    }

}

// Sample class 2 with a runnable method
public class ExampleClass2
{
    [Runnable(Description = "This method says greetings")]
    public void Greet()
    {
        Console.WriteLine("Greetings from ExampleClass2");
    }
    public void AnotherMethod()
    {
        Console.WriteLine("This is another method in ExampleClass2");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var runnableMethods = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                    .Where(m => m.GetCustomAttributes(typeof(RunnableAttribute), false).Any());

        foreach (var method in runnableMethods)
        {
            object instance = null;
            if (!method.IsStatic)
                instance = Activator.CreateInstance(method.DeclaringType);
            Console.WriteLine($"Invoking: {method.DeclaringType.FullName}.{method.Name}");
            var output = method.Invoke(instance, null);
            if (output != null)
                Console.WriteLine($"Output: {output}");
        }
    }
}