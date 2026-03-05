using Refactoring.Domain;

namespace Refactoring.Application.Interfaces
{
    public interface IStockService
    {
        bool ValidateStock(Order order);
    }
}
