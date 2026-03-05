using Refactoring.Application.Interfaces;
using Refactoring.Domain;

namespace Refactoring.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
            Console.WriteLine("Guardando orden en la base de datos...");
            Console.WriteLine($"Orden guardada.");
        }
    }
}
