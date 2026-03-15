using Refactoring.Application.Interfaces;
using Refactoring.Domain;

namespace Refactoring.Infrastructure
{
    public class PayPalPaymentService : IPaymentService
    {
        private const decimal MaxApprovedAmount = 10000; // Ejemplo de límite para aprobación

        public bool ProcessPayment(Order order)
        {
            Console.WriteLine("Simulando Autenticación de PayPal...");
            // Simular demora en la autenticación
            Thread.Sleep(1000);
            Console.WriteLine("Autenticación de PayPal exitosa.");

            if (order.TotalOrden <= MaxApprovedAmount)
            {
                Console.WriteLine($"Pago de {order.TotalOrden:c} aprobado via PayPal.");
                return true;
            }
            else
            {
                Console.WriteLine($"Pago de {order.TotalOrden:c} rechazado via PayPal (excede el límite).");
                return false;
            }
        }
    }
}