using System.Reflection.Metadata.Ecma335;

namespace PaymentSystem;

public abstract class BasePayment : IPaymentProcessor
{
    public abstract PaymentStatus ProcessPayment(double amount);
    private readonly Guid _paymentId;
    protected DateTimeOffset CreatedDate { get; init; } = DateTimeOffset.UtcNow;
    protected readonly ILogger _logger;
    protected readonly INetworkConnection _networkConnection;
    public BasePayment(ILogger logger, INetworkConnection networkConnection)
    {
        _logger = logger;
        _networkConnection = networkConnection;
        _paymentId = Guid.CreateVersion7();
    }
    
    public Guid PaymentId => _paymentId;
}