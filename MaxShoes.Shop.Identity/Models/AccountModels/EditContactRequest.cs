using MaxShoes.Shop.Identity.Models.UserModels;

namespace MaxShoes.Shop.Identity.Models.AccountModels
{
    public class EditContactRequest
    {
        public string Email { get; set; }

        public Contact Contact { get; set; }
    }
}