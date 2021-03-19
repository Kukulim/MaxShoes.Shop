using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Presistance.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {

        }

        async Task<List<Notification>> INotificationRepository.GetAllCurrentUserAsync(string id)
        {
            return await context.Notifications.Where(n => n.UserId == id).ToListAsync();
        }
    }
}
