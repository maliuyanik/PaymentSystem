namespace PaymentSystem;

public static class PaymentStatusExtentions
{
    public static string GetMessage(this PaymentStatus status)
    {
        return status switch
        {
            PaymentStatus.Success => "Transaction Successful",
            PaymentStatus.InsufficientBalance => "Declined: Balance or Limit not enough",
            PaymentStatus.NetworkError => "Failed: Connection time out",
            _ => "Unknown Error"
        };
    }
}