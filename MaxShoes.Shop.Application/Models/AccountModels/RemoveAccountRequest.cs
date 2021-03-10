namespace MaxShoes.Shop.Identity.Models.AccountModels
{
    public class RemoveAccountRequest
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}