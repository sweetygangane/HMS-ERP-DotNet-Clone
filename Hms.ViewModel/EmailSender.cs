using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SenderEmailAsync(string email,string subject,string htmlMessage)
        {
            return Task.CompletedTask;
        }

        void IEmailSender.SenderEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
