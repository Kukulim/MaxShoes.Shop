using MaxShoes.Shop.Application.Contracts.Infrastructure;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Infrastructure.Email
{
    public class MailgunEmailService : IEmailService
    {
        public MailgunEmailService(HttpClient mailgunHttpClient, MailConfigSection mailConfigSection)
        {
            this.mailgunHttpClient = mailgunHttpClient;
            this.mailConfigSection = mailConfigSection;
        }

        public HttpClient mailgunHttpClient { get; }
        public MailConfigSection mailConfigSection { get; }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            Dictionary<string, string> form = new Dictionary<string, string>
            {
                ["from"] = mailConfigSection.From,
                ["to"] = toEmail,
                ["subject"] = subject,
                ["html"] = content,
            };

            await mailgunHttpClient.PostAsync($"v3/{mailConfigSection.Domain}/messages", new FormUrlEncodedContent(form));

        }
    }
}