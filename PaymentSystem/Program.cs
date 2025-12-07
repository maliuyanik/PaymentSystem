namespace PaymentSystem;

class Program
{
    static void Main(string[] args)
    {
        ILogger logger = new ConsoleLogger();
        INetworkConnection network = new MockNetworkAdapter();
        
        List<IPaymentProcessor> paymentQueue = 
        [
            new CreditCardPayment("1234567891234567", "123", 2000.0m, logger, network)
        ];
        
        Console.WriteLine("--- Batch Processing --- \n");
        foreach (IPaymentProcessor paymentProcessor in paymentQueue)
        {
            PaymentStatus result = paymentProcessor.ProcessPayment(100.0m);
            if (result != PaymentStatus.Success)
            {
                Console.WriteLine($"ATTENTION: Payment failed for {PaymentStatus.InsufficientBalance}");
            }
        }
        
    }
}