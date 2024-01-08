using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.ExternalServices.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmail(string email);
    }
}
