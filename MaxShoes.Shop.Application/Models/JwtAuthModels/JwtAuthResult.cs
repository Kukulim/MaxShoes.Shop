namespace MaxShoes.Shop.Identity.Models.JwtAuthModels
{
    public class JwtAuthResult
    {
        public string AccessToken { get; set; }

        public RefreshToken RefreshToken { get; set; }
    }
}