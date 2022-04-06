using Domain.Command;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommandHandler
{
    public class McBTestCommandHandler : IConsumer<McBTestCommand>
    {
        public Task Consume(ConsumeContext<McBTestCommand> context)
        {
            throw new NotImplementedException();
        }
    }
}
