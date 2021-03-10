using System.ComponentModel.DataAnnotations;

namespace MaxShoes.Shop.Application.Models.AccountModels
{
    public class ChangePasswordRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}