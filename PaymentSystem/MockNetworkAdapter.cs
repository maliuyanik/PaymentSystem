namespace PaymentSystem;

public class MockNetworkAdapter : INetworkConnection
{
    public bool IsConnected()
    {
        return true;
    }
}