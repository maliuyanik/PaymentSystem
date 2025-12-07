namespace PaymentSystem;

class Program
{
    static void Main(string[] args)
    {
        ILogger logger = new ConsoleLogger();
        INetworkConnection network = new MockNetworkAdapter();
        
        var cardPayment = new CreditCardPayment("1234567890123456", "123", 5000, logger, network);
        cardPayment.ProcessPayment(1500);
            
    }
}