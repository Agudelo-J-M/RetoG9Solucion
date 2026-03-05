using Refactoring.Domain;

namespace Refactoring.Application.Interfaces
{
    public interface IPaymentService
    {
        bool ProcessPayment(Order order);
    }
}



