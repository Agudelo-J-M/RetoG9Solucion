using Refactoring.Application.Interfaces;
using Refactoring.Domain;

namespace Refactoring.Infrastructure
{
    public class EmailService : IEmailService
    {
        public void SendConfirmation(Order order)
        {
            Console.WriteLine("Enviando correo de confirmación...");

            Console.WriteLine($"Correo enviado a: {order.EmailCliente}");
            Console.WriteLine("Gracias por su compra.");
        }
    }
}
