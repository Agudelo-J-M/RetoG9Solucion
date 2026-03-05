using Refactoring.Domain;

namespace Refactoring.Application.Interfaces
{
    public interface IInvoiceService
    {
        void GenerateInvoice(Order order);
    }
}
