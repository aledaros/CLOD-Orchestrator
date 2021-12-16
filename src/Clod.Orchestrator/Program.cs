using Clod.Orchestrator;
using Clod.Orchestrator.Consumers;
using MassTransit;
using IHost = Microsoft.Extensions.Hosting.IHost;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddMassTransit(x => {
            x.UsingRabbitMq((context, config) =>
            {
                config.Host("roedeer.rmq.cloudamqp.com", "vpeeygzh",
                  credential => {
                      credential.Username("vpeeygzh");
                      credential.Password("t0mDd3KRsJkXRV3DXzmCUfRWmDFbFu42");
                  });
                config.ConfigureEndpoints(context);

                config.ReceiveEndpoint("gruppo2-CreateClientQueue", e =>
                {
                    e.Consumer<CreateClientConsumer>(context);

                });


                config.ReceiveEndpoint("gruppo2-DeleteClientQueue", e =>
                {
                    e.Consumer<DeleteClientConsumer>(context);

                });

                config.ReceiveEndpoint("gruppo2-UpdateClientQueue", e =>
                {
                    e.Consumer<UpdateClientConsumer>(context);

                });

                config.ReceiveEndpoint("gruppo2-NewOrderQueue", e =>
                {
                    e.Consumer<NewOrderConsumer>(context);

                });

                config.ReceiveEndpoint("gruppo2-DeleteOrderQueue", e =>
                {

                    e.Consumer<DeleteOrderConsumer>(context);

                });

                config.ReceiveEndpoint("gruppo2-UpdateOrderQueue", e =>
                {
                    e.Consumer<UpdateOrderEvent>(context);

                });
            });
        });
        services.AddMassTransitHostedService();
    })
    .Build();

await host.RunAsync();
