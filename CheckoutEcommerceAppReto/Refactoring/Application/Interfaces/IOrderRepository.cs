using Refactoring.Domain;

namespace Refactoring.Application.Interfaces
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
