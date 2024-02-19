using System.Net.Mail;
using System.Net;
using EduNgoWebsite.Models;
using Microsoft.Extensions.Options;
using Humanizer;

namespace EduNgoWebsite.Repository.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        //send mail to user
        public void SendEmail(string to, string subject, Volunteer body, string Name)
        {
            var fromAddress = new MailAddress(_emailSettings.FromAddress, _emailSettings.Username);

            var message = new MailMessage
            {
                From = fromAddress
            };
            message.To.Add(to);
            message.Subject = subject;
            //message.Body = body.Name;
            message.Body = $"Hi {body.Name}";
            message.Body += $"\n\n\nThanks for registering with us. We would reach out to you for next steps.";
            message.Body += $"\n\n\nThanks";
            message.Body += $"\nTeam";

            using (var smtpClient = new SmtpClient(_emailSettings.SmtpServer))
            {
                smtpClient.Port = _emailSettings.Port;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(_emailSettings.FromAddress, _emailSettings.Password);
                    smtpClient.Send(message);
            }
        }

        //send mail to us

        public void SendEmailToUs(string to, string subject, Volunteer body, string Name)
        {
            var fromAddress = new MailAddress(_emailSettings.FromAddress, _emailSettings.Username);

            var message = new MailMessage
            {
                From = fromAddress
            };
            message.To.Add(to);
            message.Subject = subject;
            //message.Body = body.Name;
            ///message.Body = $"Hi: {body.Name}";
            message.Body += $"\n\nYou have volunteer registration with below details.";
            message.Body += $"\n\n\nName: {body.Name}";
            message.Body += $"\nAge: {body.Age}";
            message.Body += $"\nGender: {body.Gender}";
            message.Body += $"\nMobile Number: {body.MobileNumber}";
            message.Body += $"\nEmail Address: {body.EmailAddress}";
            message.Body += $"\nAddress: {body.Address}";
            message.Body += $"\nCity: {body.City}";
            message.Body += $"\nState: {body.States.StateName}";
            message.Body += $"\nPIN Code: {body.PINCode}";
            message.Body += $"\n\n\nThanks";

            message.Bcc.Add("developer@worthum.com");

            using (var smtpClient = new SmtpClient(_emailSettings.SmtpServer))
            {
                smtpClient.Port = _emailSettings.Port;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(_emailSettings.FromAddress, _emailSettings.Password);
                smtpClient.Send(message);
            }
        }
    }
}
