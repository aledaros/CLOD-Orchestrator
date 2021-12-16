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

                config.ReceiveEndpoint("CreateClientCommands", e =>
                {
                    e.Consumer<CreateClientConsumer>();

                });
                config.ReceiveEndpoint("UpdateClientCommands", e =>
                {
                    e.Consumer<UpdateClientConsumer>();

                });
                config.ReceiveEndpoint("DeleteClientCommands", e =>
                {
                    e.Consumer<DeleteClientConsumer>();

                });
                config.ReceiveEndpoint("CreateOrderCommands", e =>
                {
                    e.Consumer<CreateOrderConsumer>();

                });
                config.ReceiveEndpoint("UpdateOrderCommands", e =>
                {
                    e.Consumer<UpdateOrderConsumer>();

                });
                config.ReceiveEndpoint("DeleteOrderCommands", e =>
                {
                    e.Consumer<DeleteOrderConsumer>();

                });

            });
        });
        services.AddMassTransitHostedService();
    })
    .Build();

await host.RunAsync();
