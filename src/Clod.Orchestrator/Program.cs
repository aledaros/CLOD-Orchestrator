using Clod.Orchestrator;
using Gruppo3.ClientiDTO.Domain.Events;
using Clod.Orchestrator.Consumers;
using MassTransit;
using MacNuget.Warehouse.Events;

using IHost = Microsoft.Extensions.Hosting.IHost;
using Gruppo4.Microservizi.AppCore.Consumers.Customers;
using Gruppo4.Microservizi.AppCore.Consumers.Warehouse;
using Gruppo4.Microservizi.AppCore.Consumers.Products;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddMassTransit(x => {
            x.AddConsumer<CreateClientEventConsumer>();
            x.AddConsumer<NewRefillEventConsumer>();
            x.AddConsumer<UpdateClientEventConsumer>();
            x.AddConsumer<DeleteProductEventConsumer>();
            x.AddConsumer<UpdateProductEventConsumer>();
            x.AddConsumer<NewRefillEventConsumer>();
            x.AddConsumer<DeleteClientEventConsumer>();

            x.UsingRabbitMq((context, config) =>
            {
                config.Host("roedeer.rmq.cloudamqp.com", "vpeeygzh",
                  credential =>
                  {
                      credential.Username("vpeeygzh");
                      credential.Password("t0mDd3KRsJkXRV3DXzmCUfRWmDFbFu42");
                  });

                // Orders Endpoints 
                config.ReceiveEndpoint("gruppo4-orch-orders_create_client", e =>
                {
                    e.Consumer<CreateClientEventConsumer>();
                });
                config.ReceiveEndpoint("gruppo4-orch-orders_product_refill", e =>
                {
                    e.Consumer<NewRefillEventConsumer>();
                });

                config.ReceiveEndpoint("gruppo4-orch-orders_update_client", e =>
                {
                    e.Consumer<UpdateClientEventConsumer>(context);
                });

                config.ReceiveEndpoint("gruppo4-orch-orders_delete_product", e =>
                {
                    e.Consumer<DeleteProductEventConsumer>(context);
                });

                config.ReceiveEndpoint("gruppo4-orch-orders_new_product", e =>
                {
                    e.Consumer<NewProductEventConsumer>(context);
                });

                config.ReceiveEndpoint("gruppo4-orch-orders_update_product", e =>
                {
                    e.Consumer<UpdateProductEventConsumer>(context);
                });

                config.ReceiveEndpoint("gruppo4-orch-orders_delete_client", e =>
                {
                    e.Consumer<DeleteClientEventConsumer>(context);
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

                config.ConfigureEndpoints(context);
            });

        });
        services.AddMassTransitHostedService();
    })
    .Build();


await host.RunAsync();
