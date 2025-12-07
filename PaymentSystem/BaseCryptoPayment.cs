using System.Text.RegularExpressions;

namespace PaymentSystem;
public abstract class BaseCryptoPayment : BasePayment
{
    public string WalletAddress { get; init; }
    protected abstract Regex AddressValidator { get; }
    
    protected BaseCryptoPayment(string walletAddress, ILogger logger, INetworkConnection networkConnection)
        : base(logger, networkConnection)
    {
        if (string.IsNullOrWhiteSpace(walletAddress))
        {
            _logger.Log($"Invalid wallet address: {walletAddress}");
            throw new ArgumentNullException(nameof(walletAddress));
        }

        if (!AddressValidator.IsMatch(walletAddress))
        {
            _logger.Log($"Invalid wallet address: {walletAddress}");
            throw new ArgumentException($"Invalid wallet address: {walletAddress}");
        }
        WalletAddress = walletAddress;
    }
}