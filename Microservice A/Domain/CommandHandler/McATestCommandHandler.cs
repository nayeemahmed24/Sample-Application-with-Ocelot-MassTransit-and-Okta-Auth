using Domain.Command;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommandHandler
{
    public class McATestCommandHandler : IConsumer<McATestCommand>
    {
        public Task Consume(ConsumeContext<McATestCommand> context)
        {
            throw new NotImplementedException();
        }
    }
}
