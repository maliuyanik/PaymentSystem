namespace PaymentSystem;

public interface IPaymentProcessor
{
    PaymentStatus ProcessPayment(decimal amount);
}