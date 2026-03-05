using Refactoring.Application.Interfaces;
using Refactoring.Domain;

namespace Refactoring.Infrastructure
{
    public class PaymentService : IPaymentService
    {
        public bool ProcessPayment(Order order)
        {
            decimal limiteMontoTarjetaCredito = 10000;
            decimal limiteMontoPse = 10000;

            if (order.MedioPago == "tarjeta credito" && order.TotalOrden > limiteMontoTarjetaCredito)
            {
                Console.WriteLine("Pago rechazado por límite excedido.");
                return false;
            }

            if (order.MedioPago == "pse" && order.TotalOrden > limiteMontoPse)
            {
                Console.WriteLine("Pago rechazado por límite excedido.");
                return false;
            }

            return true;
        }
    }
}
