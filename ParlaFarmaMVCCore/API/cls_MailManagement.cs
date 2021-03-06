﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Mail;

namespace ParlaFarmaMVCCore.API
{
    public class cls_MailManagement
    {
        SmtpClient smtpClient = null;
        public MailMessage mail = new MailMessage();
        public List<cls_emailAccount> To { get; set; }
        public List<cls_emailAccount> CC { get; set; }
        public string Subject { get; set; }
        public List<string> Attachments { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public cls_MailManagement()
        {
            To = new List<cls_emailAccount>();
            CC = new List<cls_emailAccount>();
            Attachments = new List<string>();

            smtpClient = new SmtpClient("smtp.ionos.com", 587);

            //smtpClient.UseDefaultCredentials = false; // uncomment if you don't want to use the network credentials

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            
            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new System.Net.NetworkCredential("info@s811227068.onlinehome.us", "Info123!@#");
        }
        public string SendEmail()
        {
            try
            {
                //Setting From , To and CC
                mail.From = new MailAddress("info@parlapharma.com", "info@parlapharma.com");
                
                foreach (cls_emailAccount item in To)
                    mail.To.Add(new MailAddress(item.Address, item.DisplayName));
                foreach (cls_emailAccount item in CC)
                    mail.CC.Add(new MailAddress(item.Address, item.DisplayName));
                foreach (string item in Attachments)
                {
                    Attachment attachment = new Attachment(item);
                    mail.Attachments.Add(attachment);
                }
                mail.IsBodyHtml = IsBodyHtml;
                mail.Body = Body;
                mail.Subject = Subject;
                smtpClient.Send(mail);
                return "OK";
            }
            catch (Exception err)
            {
                return err.Message + "   " + err.InnerException;
            }
        }
        public string SendEmail(int i)
        {
            return null;
        }
    }
}
