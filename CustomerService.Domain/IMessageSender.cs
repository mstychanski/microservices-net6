using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Domain
{
    public interface IMessageSender
    {
        Task Send(string recipient, string content);
    }
}
