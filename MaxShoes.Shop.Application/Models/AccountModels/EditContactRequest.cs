﻿

using MaxShoes.Shop.Application.Models.UserModels;

namespace MaxShoes.Shop.Application.Models.AccountModels
{
    public class EditContactRequest
    {
        public string Email { get; set; }

        public Contact Contact { get; set; }
    }
}