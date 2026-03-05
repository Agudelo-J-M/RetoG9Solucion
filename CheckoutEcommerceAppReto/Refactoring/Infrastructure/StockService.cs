using Refactoring.Application.Interfaces;
using Refactoring.Domain;

namespace Refactoring.Infrastructure
{
    public class StockService: IStockService
    {
        public bool ValidateStock(Order order)
        {
            int stockPrueba = 3;

            Console.WriteLine("Validando stock...");

            if (order.Cantidad > stockPrueba)
            {
                Console.WriteLine("Stock insuficiente");
                return false;
            }

            return true;
        }
    }
}
