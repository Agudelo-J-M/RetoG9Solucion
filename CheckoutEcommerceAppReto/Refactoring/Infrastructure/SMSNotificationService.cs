using Refactoring.Application.Interfaces;
using Refactoring.Domain;

namespace Refactoring.Infrastructure
{
public class SMSNotificationService : IEmailService
{
    public void SendEmail(Order order)
    {
        Console.WriteLine("Enviando SMS al cliente...");
        // simular demora en el envío del SMS
        Thread.Sleep(500);
        Console.WriteLine($"SMS enviado al número {order.EmailCliente} con éxito.");
    }
}
}