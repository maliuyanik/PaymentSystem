namespace PaymentSystem;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG]: {DateTimeOffset.UtcNow} {message}");
    }
}