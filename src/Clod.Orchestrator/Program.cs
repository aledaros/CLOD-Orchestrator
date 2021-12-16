using Clod.Orchestrator;
using Clod.Orchestrator.Consumers;
using MassTransit;
using IHost = Microsoft.Extensions.Hosting.IHost;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, config) =>
            {
                config.Host("roedeer.rmq.cloudamqp.com", "vpeeygzh",
                  credential =>
                  {
                      credential.Username("vpeeygzh");
                      credential.Password("t0mDd3KRsJkXRV3DXzmCUfRWmDFbFu42");
                  });

                // Warehouse Endpoints 
                config.ReceiveEndpoint("gruppo1-orch-update-product-event", e =>
                {
                    e.Consumer<UpdateProductConsumer>();
                });

                config.ReceiveEndpoint("gruppo1-orch-new-product-event", e =>
                {
                    e.Consumer<NewProductConsumer>();
                });

                config.ReceiveEndpoint("gruppo1-orch-delete-product-event", e =>
                {
                    e.Consumer<DeleteProductConsumer>();
                });

                config.ReceiveEndpoint("gruppo1-orch-new-order-event", e =>
                {
                    e.Consumer<NewOrderConsumer>();
                });

                config.ReceiveEndpoint("gruppo1-orch-update-order-event", e =>
                {
                    e.Consumer<UpdateOrderConsumer>();
                });

                config.ReceiveEndpoint("gruppo1-orch-delete-order-event", e =>
                {
                    e.Consumer<DeleteOrderConsumer>();
                });

                config.ConfigureEndpoints(context);
              
                // Customers Endpoints
                config.ReceiveEndpoint("gruppo3-orch-NewOrderEvent", e =>
                    {
                        e.Consumer<ClientNewOrderEvent>();
                    });
                config.ReceiveEndpoint("gruppo3-orch-UpdateOrderEvent", e =>
                {
                    e.Consumer<ClientUpdateOrderEvent>();
                });
                config.ReceiveEndpoint("gruppo3-orch-DeleteOrderEvent", e =>
                {
                    e.Consumer<ClientDeleteOrderEvent>();
                });
            });

        });
        services.AddMassTransitHostedService();
    })
    .Build();

await host.RunAsync();
