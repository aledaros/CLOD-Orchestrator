using Clod.Orchestrator;
using Clod.Orchestrator.Consumers;
using MassTransit;
using IHost = Microsoft.Extensions.Hosting.IHost;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddMassTransit(x => {

            //x.AddConsumer<CreateClientConsumer>();
            //x.AddConsumer<DeleteClientConsumer>();
            //x.AddConsumer<UpdateClientConsumer>();
            //x.AddConsumer<NewOrderConsumer>();
            //x.AddConsumer<DeleteOrderConsumer>();
            //x.AddConsumer<UpdateOrderConsumer>();

            x.UsingRabbitMq((context, config) =>
            {
                config.Host("roedeer.rmq.cloudamqp.com", "vpeeygzh",
                  credential => {
                      credential.Username("vpeeygzh");
                      credential.Password("t0mDd3KRsJkXRV3DXzmCUfRWmDFbFu42");
                  });
                config.ConfigureEndpoints(context);

                config.ReceiveEndpoint("gruppo2-orchestratore-CreateClientCommands", e =>
                {
                    e.Consumer<G2CreateClientConsumer>();

                });
                config.ReceiveEndpoint("gruppo2-orchestratore-UpdateClientCommands", e =>
                {
                    e.Consumer<G2UpdateClientConsumer>();

                });
                config.ReceiveEndpoint("gruppo2-orchestratore-DeleteClientCommands", e =>
                {
                    e.Consumer<G2DeleteClientConsumer>();

                });
                config.ReceiveEndpoint("gruppo2-orchestratore-CreateOrderCommands", e =>
                {
                    e.Consumer<G2CreateOrderConsumer>();

                });
                config.ReceiveEndpoint("gruppo2-orchestratore-UpdateOrderCommands", e =>
                {
                    e.Consumer<G2UpdateOrderConsumer>();

                });
                config.ReceiveEndpoint("gruppo2-orchestratore-DeleteOrderCommands", e =>
                {
                    e.Consumer<G2DeleteOrderConsumer>();

                });

            });
        });
        services.AddMassTransitHostedService();
    })
    .Build();

await host.RunAsync();
