﻿using System.ComponentModel.DataAnnotations;

namespace GumAdvisor.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}