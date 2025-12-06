namespace PaymentSystem;

public interface IPaymentProcessor
{
    PaymentStatus ProcessPayment(double amount);
}