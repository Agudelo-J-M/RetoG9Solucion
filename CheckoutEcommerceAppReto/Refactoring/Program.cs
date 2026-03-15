using Refactoring.Application;
using Refactoring.Application.Interfaces;
using Refactoring.Domain;
using Refactoring.Infrastructure;

namespace Refactoring
{
    public class Program
    {
        static void Main(string[] args)
        {


            IStockService stockService = new StockService();
            IPaymentService paymentService = new PaymentService();
            IPaymentService payPalPaymentService = new PayPalPaymentService();
            IInvoiceService invoiceService = new InvoiceService();
            IEmailService emailService = new EmailService();
            IEmailService smsNotificationService = new SMSNotificationService();
            IOrderRepository orderRepository = new OrderRepository();

            Console.WriteLine("=== CREAR NUEVA ORDEN ===");

            Console.Write("Nombre del cliente: ");
            string nombre = Console.ReadLine()!;

            Console.Write("Email del cliente: ");
            string email = Console.ReadLine()!;

            Console.Write("Producto: ");
            string producto = Console.ReadLine()!;

            Console.Write("Cantidad: ");
            int cantidad = int.Parse(Console.ReadLine()!);

            Console.Write("Medio de pago: ");
            string medioPago = Console.ReadLine()!;

            // Determine which payment service to use
            IPaymentService selectedPaymentService = medioPago.ToLower() == "paypal" ? payPalPaymentService : paymentService;

            // Determine which notification service to use
            IEmailService selectedEmailService = email.Contains("@") ? emailService : smsNotificationService;

            // Crear la orden
            Order order = new Order
            {
                NombreCliente = nombre,
                EmailCliente = email,
                Producto = producto,
                Cantidad = cantidad,
                MedioPago = medioPago
            };

            var checkout = new CheckoutService(
                            stockService,
                            selectedPaymentService,
                            invoiceService,
                            selectedEmailService,
                            orderRepository);

            checkout.ProcessOrder(order);

            Console.ReadLine();
        }
    }
}
