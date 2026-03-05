using Refactoring.Domain;

namespace Refactoring.Application.Interfaces
{
    public interface IEmailService
    {
        void SendConfirmation(Order order);
    }
}
