using EduNgoWebsite.Repository.Interface;

namespace EduNgoWebsite.Repository.Service
{
    public class EmailSettings : IEmailSettings
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string FromAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string ToAddress { get; set; }
    }
}
