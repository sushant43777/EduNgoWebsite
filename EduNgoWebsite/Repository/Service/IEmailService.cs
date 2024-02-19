using EduNgoWebsite.Models;

namespace EduNgoWebsite.Repository.Service
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, Volunteer body, string Name);
        void SendEmailToUs(string to, string subject, Volunteer body, string Name);
    }
}
