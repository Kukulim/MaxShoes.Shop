namespace MaxShoes.Shop.Application.Models.AccountModels
{
    public class ConfirmEmailTokenRequest
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
