using Domain.Command;
using Domain.CommandHandler;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workerservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumers(typeof(McBTestCommand).Assembly);
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(Configuration["Queue:Url"], h =>
                    {
                        h.Username(Configuration["Queue:Username"]);
                        h.Password(Configuration["Queue:Password"]);
                    });
                    cfg.ReceiveEndpoint(Configuration["Queue:QueueName"], e =>
                    {
                        e.ConfigureConsumer<McBTestCommandHandler>(context);
                    });
                });
            });
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddControllers();
            services.AddHostedService<MassTransitService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
