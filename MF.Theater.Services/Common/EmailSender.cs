using System.Diagnostics;

namespace MF.Theater.Services.Common
{
    public class EmailSender: IEmailSender
    {
        public void SendEmail(string email, string message)
        {
            Debug.WriteLine("Будет реализовано в следующей версии");
        }
    }
}