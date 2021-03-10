using System.ComponentModel.DataAnnotations;

namespace MaxShoes.Shop.Identity.Models.AccountModels
{
    public class RegisterRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}