using Refactoring.Application.Interfaces;
using Refactoring.Domain;

namespace Refactoring.Application
{
    public class CheckoutService
    {
        private readonly IStockService _stockService;
        private readonly IPaymentService _paymentService;
        private readonly IInvoiceService _invoiceService;
        private readonly IEmailService _emailService;
        private readonly IOrderRepository _orderRepository;

        public CheckoutService(
            IStockService stockService,
            IPaymentService paymentService,
            IInvoiceService invoiceService,
            IEmailService emailService,
            IOrderRepository orderRepository)
        {
            _stockService = stockService;
            _paymentService = paymentService;
            _invoiceService = invoiceService;
            _emailService = emailService;
            _orderRepository = orderRepository;
        }

        public void ProcessOrder(Order order)
        {
            Console.WriteLine("=== INICIANDO CHECKOUT ===");

            if (!_stockService.ValidateStock(order))
                return;

            if (!_paymentService.ProcessPayment(order))
                return;

            _invoiceService.GenerateInvoice(order);
            _emailService.SendConfirmation(order);
            _orderRepository.Save(order);

            Console.WriteLine("=== CHECKOUT FINALIZADO ===");
        }
    }
}
