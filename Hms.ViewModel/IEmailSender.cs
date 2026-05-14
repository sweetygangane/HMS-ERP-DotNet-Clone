
namespace Hms.Utility
{
    public interface IEmailSender
    {
        void SenderEmailAsync(string email, string subject, string htmlMessage);
    }
}