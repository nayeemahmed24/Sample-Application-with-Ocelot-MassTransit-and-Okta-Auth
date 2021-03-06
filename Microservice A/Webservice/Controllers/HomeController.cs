using Domain.Command;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceA.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IBus _bus;
        private readonly IConfiguration configuration;
        private readonly string queueName;
        public HomeController(IBus bus, IConfiguration configuration)
        {
            this._bus = bus;
            this.configuration = configuration;
            this.queueName = this.configuration.GetValue<string>("Queue:QueueName");
        }

        public async Task<IActionResult> TestMessage()
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri(this.queueName));
            await endpoint.Send(new McATestCommand()
            {
                WelcomeMessage = "Welcome from service A",
            });
            return this.Accepted();
        }
    }
}
