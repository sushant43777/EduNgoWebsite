namespace EduNgoWebsite.Repository.Interface
{
    public interface IEmailSettings
    {
        string SmtpServer { get; }
        int Port { get; }
        string FromAddress { get; }
        string Username { get; }
        string Password { get; }

        string ToAddress {  get; }
    }
}
