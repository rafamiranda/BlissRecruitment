using BlissRecruitment.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace BlissRecruitment.Providers
{
    public class ShareProvider : IShareProvider
    {
        #region Constructor

        public ShareProvider(IConfiguration configuration)
        {
            IConfigurationSection smtpSection = configuration.GetSection("SmtpSettings");
            SmtpSettings = new SmtpSettings(smtpSection.GetValue<string>("SmtpServer"), smtpSection.GetValue<int>("SmtpPort"),
                smtpSection.GetValue<string>("EmailFrom"), smtpSection.GetValue<string>("Subject"), smtpSection.GetValue<string>("Message"));
        }

        #endregion

        #region Properties
        protected SmtpSettings SmtpSettings { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="emailAddress">email address</param>
        /// <param name="urlContent">url content</param>
        /// <returns>True if success</returns>
        public bool SendEmail(string emailAddress, string urlContent)
        {
            try
            {
                MailMessage message = new MailMessage(SmtpSettings.EmailFrom, emailAddress, SmtpSettings.Subject, $"{SmtpSettings.Message} - {urlContent}");
                System.Net.Mail.SmtpClient smtpClient = new SmtpClient
                {
                    Host = SmtpSettings.SmtpServer,
                    Port = SmtpSettings.SmtpPort
                };
                smtpClient.Send(message);

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}