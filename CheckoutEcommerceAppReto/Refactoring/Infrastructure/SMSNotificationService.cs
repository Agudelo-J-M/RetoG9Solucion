using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refactoring.Infrastructure
{
public class SMSNotificationService : IEmailService
{
    public void SendEmail(string to, string subject, string body)
    {
        Console.WriteLine("Enviando SMS al cliente...");
        // simular demora en el envío del SMS
        Thread.Sleep(500);
        Console.WriteLine("SMS enviado al número registrado con éxito.");
    }
}
}