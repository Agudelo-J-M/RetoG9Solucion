using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refactoring.Infrastructure
{
public class PayPalPaymentService : IPaymentService
{
    private const decimal MaxApprovedAmount = 100.00m; // Ejemplo de límite para aprobación

    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine("Simulando Autenticación de PayPal...");
        // Simular demora en la autenticación
        Thread.Sleep(1000);
        Console.WriteLine("Autenticación de PayPal exitosa.");

        if (amount <= MaxApprovedAmount)
        {
            Console.WriteLine($"Pago de {amount:C} aprobado via PayPal.");
            return true;
        }
        else
        {
            Console.WriteLine($"Pago de {amount:C} rechazado via PayPal (excede el límite).");
            return false;
        }
    }
}
}