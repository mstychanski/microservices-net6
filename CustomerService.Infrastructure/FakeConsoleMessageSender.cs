using CustomerService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Infrastructure
{
    public class FakeConsoleMessageSender : IMessageSender
    {
        public Task Send(string recipient, string content)
        {
            Console.WriteLine($"Sending to <{recipient}> {content}");

            return Task.CompletedTask;
            
        }
    }
}
