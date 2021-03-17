namespace MaxShoes.Shop.Identity.Models.AccountModels
{
    public class RemoveAccountRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}