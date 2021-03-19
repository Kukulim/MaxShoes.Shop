using MaxShoes.Shop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Contracts.Presistance
{
    public interface INotificationRepository :IAsyncRepository<Notification>
    {
        Task<List<Notification>> GetAllCurrentUserAsync(string id);
    }
}