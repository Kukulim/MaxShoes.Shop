﻿namespace MaxShoes.Shop.Application.Contracts.Infrastructure
{
    public class MailConfigSection
    {
        public string From { get; set; }

        public string MailgunKey { get; set; }

        public string Domain { get; set; }
    }
}