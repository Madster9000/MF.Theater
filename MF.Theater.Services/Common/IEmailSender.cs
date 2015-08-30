namespace MF.Theater.Services.Common
{
    public interface IEmailSender
    {
        void SendEmail(string email, string message);
    }
}