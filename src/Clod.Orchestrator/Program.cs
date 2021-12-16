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

                config.ReceiveEndpoint("orch-warehouse-update-product-event", e =>
                {
                    e.Consumer<UpdateProductConsumer>();
                });

                config.ReceiveEndpoint("orch-warehouse-new-product-event", e =>
                {
                    e.Consumer<NewProductConsumer>();
                });

                config.ReceiveEndpoint("orch-warehouse-delete-product-event", e =>
                {
                    e.Consumer<DeleteProductConsumer>();
                });

                config.ReceiveEndpoint("orch-warehouse-new-order-event", e =>
                {
                    e.Consumer<NewOrderConsumer>();
                });

                config.ReceiveEndpoint("orch-warehouse-update-order-event", e =>
                {
                    e.Consumer<UpdateOrderConsumer>();
                });

                config.ReceiveEndpoint("orch-warehouse-delete-order-event", e =>
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
