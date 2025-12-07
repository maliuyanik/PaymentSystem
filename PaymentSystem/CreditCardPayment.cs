namespace PaymentSystem;

public class CreditCardPayment : BasePayment
{
    private string CardNumber { get; init; }
    private string Cvv { get; init; }
    private double Limit { get; init; }
    
    public CreditCardPayment(string cardNumber, string cvv, double limit, ILogger logger, INetworkConnection networkConnection) 
        : base(logger, networkConnection)
    {
        if (string.IsNullOrWhiteSpace(cardNumber))
        {
            _logger.Log($"Card Number cannot be null or empty. Input: {cardNumber}");
            throw new ArgumentNullException(nameof(cardNumber), "Card Number cannot be null or empty.");
        }

        if (string.IsNullOrWhiteSpace(cvv))        
        {
            _logger.Log($"CVV cannot be null or empty. Input: {cvv}");
            throw new ArgumentNullException(nameof(cvv), "CVV cannot be null or empty.");        
        }

        if (limit < 0)
        {
            _logger.Log($"Unacceptable limit: {limit}");
            throw new ArgumentException("Unacceptable limit:", nameof(limit));
        }
        CardNumber = cardNumber;
        Cvv = cvv;
        Limit = limit;
    }

    public string GetMaskedCardNumber()
    {
        if (string.IsNullOrEmpty(CardNumber) || CardNumber.Length != 16)
        {
            return "Invalid Card Number";
        }
        string lastFourDigits = CardNumber.Substring(CardNumber.Length - 4, 4);
        return $"**** **** **** {lastFourDigits}";
    }

    public override PaymentStatus ProcessPayment(double amount)
    {
        _logger.Log("Transaction ID:" + PaymentId);
        _logger.Log("Time:" + CreatedDate);
        _logger.Log("Processing credit card payment of" + amount + "for card" +  GetMaskedCardNumber());
        
        if (Limit < amount)
        {
            _logger.Log($"Insufficient balance: {Limit}");
            return PaymentStatus.InsufficientBalance;
        }

        if (amount <= 0)
        {
            _logger.Log($"Insufficient balance: {amount}");
            return PaymentStatus.InsufficientBalance;
        }
        _logger.Log("SUCCESS: Payment processed.");
        return PaymentStatus.Success;
    }
    
    
    
}