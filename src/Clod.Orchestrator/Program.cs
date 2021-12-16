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

                config.ReceiveEndpoint("update-product-event", e =>
                {
                    e.Consumer<UpdateProductConsumer>();
                });

                config.ReceiveEndpoint("new-product-event", e =>
                {
                    e.Consumer<NewProductConsumer>();
                });

                config.ReceiveEndpoint("delete-product-event", e =>
                {
                    e.Consumer<DeleteProductConsumer>();
                });

                config.ReceiveEndpoint("update-order-event", e =>
                {
                    e.Consumer<UpdateOrderConsumer>();
                });

                config.ReceiveEndpoint("new-order-event", e =>
                {
                    e.Consumer<NewOrderConsumer>();
                });

                config.ReceiveEndpoint("delete-order-event", e =>
                {
                    e.Consumer<DeleteOrderConsumer>();
                });

                config.ConfigureEndpoints(context);
            });
            
        });
        services.AddMassTransitHostedService();
    })
    .Build();

await host.RunAsync();
