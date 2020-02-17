using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Mail;

namespace ParlaFarmaMVCCore.API
{
    public class cls_MailManagement
    {
        SmtpClient smtpClient = new SmtpClient("mail.parlapharma.com", 587);
        public MailMessage mail = new MailMessage();
        public List<cls_emailAccount> To { get; set; }
        public List<cls_emailAccount> CC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public cls_MailManagement()
        {
            To = new List<cls_emailAccount>();
            CC = new List<cls_emailAccount>();
            smtpClient.Credentials = new System.Net.NetworkCredential("info@parlapharma.com", "qEgqNSOSs4kp");
            // smtpClient.UseDefaultCredentials = true; // uncomment if you don't want to use the network credentials
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.EnableSsl = true;
        }
        public bool SendEmail()
        {
            try
            {
                //Setting From , To and CC
                mail.From = new MailAddress("info@parlapharma.com", "info@parlapharma.com");
                foreach (cls_emailAccount item in To)
                    mail.To.Add(new MailAddress(item.Address, item.DisplayName));
                foreach (cls_emailAccount item in CC)
                    mail.CC.Add(new MailAddress(item.Address, item.DisplayName));
                mail.Body = Body;
                mail.Subject = Subject;
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
