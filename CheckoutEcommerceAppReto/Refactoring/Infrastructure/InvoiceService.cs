using Refactoring.Application.Interfaces;
using Refactoring.Domain;

namespace Refactoring.Infrastructure
{
    public class InvoiceService : IInvoiceService
    {
        public void GenerateInvoice(Order order)
        {
            Console.WriteLine("Generando factura...");

            Console.WriteLine("----- FACTURA -----");
            Console.WriteLine($"Producto: {order.Producto}");
            Console.WriteLine($"Cantidad: {order.Cantidad}");
            Console.WriteLine($"Total: {order.TotalOrden:C}");
            Console.WriteLine("-------------------");
        }
    }
}
