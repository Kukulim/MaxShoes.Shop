using System;
using System.Collections.Generic;
using System.Text;

namespace MaxShoes.Shop.Application.Models.AccountModels
{
    public class PasswordResetRequest
    {
        public string UserEmail { get; set; }
        public string Token { get; set; }
    }
}
