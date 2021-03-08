using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
}