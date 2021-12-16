using Clod.Orchestrator.Consumers;
using MassTransit;
using IHost = Microsoft.Extensions.Hosting.IHost;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<ClientDeleteOrderEvent>();
            x.AddConsumer<ClientNewOrderEvent>();
            x.AddConsumer<ClientUpdateOrderEvent>();

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
                        e.ConfigureConsumer<ClientNewOrderEvent>(context);
                    });
                cfg.ReceiveEndpoint("Orchestrator-UpdateOrderEvent", e =>
                {
                    e.ConfigureConsumer<ClientUpdateOrderEvent>(context);
                });
                cfg.ReceiveEndpoint("Orchestrator-DeleteOrderEvent", e =>
                {
                    e.ConfigureConsumer<ClientDeleteOrderEvent>(context);
                });
            });
        });
        services.AddMassTransitHostedService(true);
    })
    .Build();

await host.RunAsync();
