using Clod.Orchestrator.Consumers;
using MassTransit;
using IHost = Microsoft.Extensions.Hosting.IHost;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(x =>
        {
            //RabbitMQ
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(
                    Environment.GetEnvironmentVariable("HOST_RABBIT"),
                    Environment.GetEnvironmentVariable("VHOST_RABBIT"),
                    hst =>
                    {
                        hst.Username(Environment.GetEnvironmentVariable("USERNAME_RABBIT"));
                        hst.Password(Environment.GetEnvironmentVariable("PASSWORD_RABBIT"));
                    });
                //create
                cfg.ReceiveEndpoint("Orchestrator-NewOrderEvent", e =>
                    {
                        e.Consumer<ClientNewOrderEvent>();
                    });
                cfg.ReceiveEndpoint("Orchestrator-UpdateOrderEvent", e =>
                {
                    e.Consumer<ClientUpdateOrderEvent>();
                });
                cfg.ReceiveEndpoint("Orchestrator-DeleteOrderEvent", e =>
                {
                    e.Consumer<ClientDeleteOrderEvent>();
                });
            });
        });
        services.AddMassTransitHostedService(true);
    })
    .Build();

await host.RunAsync();
