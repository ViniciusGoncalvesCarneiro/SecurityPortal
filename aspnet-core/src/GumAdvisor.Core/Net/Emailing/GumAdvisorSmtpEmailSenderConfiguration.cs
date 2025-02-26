﻿using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Security;

namespace GumAdvisor.Net.Emailing
{
    public class GumAdvisorSmtpEmailSenderConfiguration : SmtpEmailSenderConfiguration
    {
        public GumAdvisorSmtpEmailSenderConfiguration(ISettingManager settingManager) : base(settingManager)
        {

        }

        public override string Password => SimpleStringCipher.Instance.Decrypt(GetNotEmptySettingValue(EmailSettingNames.Smtp.Password));
    }
}