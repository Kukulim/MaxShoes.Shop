using System.ComponentModel.DataAnnotations;

namespace MaxShoes.Shop.Application.Models.AccountModels
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}