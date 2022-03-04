using Clod.Orchestrator;
using MassTransit;
using IHost = Microsoft.Extensions.Hosting.IHost;
using Clod.Orchestrator.Consumers.Warehouse;
using Clod.Orchestrator.Consumers.Products;
using Clod.Orchestrator.Consumers.Client;
using Clod.Orchestrator.Consumers.Order;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddMassTransit(x => {

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
                    e.Consumer<NewClientEventConsumer>();
                });
                config.ReceiveEndpoint("gruppo4-orch-orders_product_refill", e =>
                {
                    e.Consumer<NewRefillEventConsumer>();
                });

                config.ReceiveEndpoint("gruppo4-orch-orders_update_client", e =>
                {
                    e.Consumer<UpdateClientEventConsumer>();
                });

                config.ReceiveEndpoint("gruppo4-orch-orders_delete_product", e =>
                {
                    e.Consumer<DeleteProductEventConsumer>();
                });

                config.ReceiveEndpoint("gruppo4-orch-orders_new_product", e =>
                {
                    e.Consumer<NewProductEventConsumer>();
                });

                config.ReceiveEndpoint("gruppo4-orch-orders_update_product", e =>
                {
                    e.Consumer<UpdateProductEventConsumer>();
                });

                config.ReceiveEndpoint("gruppo4-orch-orders_delete_client", e =>
                {
                    e.Consumer<DeleteClientEventConsumer>();
                });

                // Warehouse Endpoints 
                config.ReceiveEndpoint("gruppo1-orch-update-product-event", e =>
                {
                    e.Consumer<UpdateProductEventConsumer>();
                });

                config.ReceiveEndpoint("gruppo1-orch-new-product-event", e =>
                {
                    e.Consumer<NewProductEventConsumer>();
                });

                config.ReceiveEndpoint("gruppo1-orch-delete-product-event", e =>
                {
                    e.Consumer<DeleteProductEventConsumer>();
                });

                config.ReceiveEndpoint("gruppo1-orch-new-order-event", e =>
                {
                    e.Consumer<NewOrdersEventConsumer>();
                });

                config.ReceiveEndpoint("gruppo1-orch-update-order-event", e =>
                {
                    e.Consumer<UpdateOrdersEventConsumer>();
                });

                config.ReceiveEndpoint("gruppo1-orch-delete-order-event", e =>
                {
                    e.Consumer<DeleteOrdersEventConsumer>();
                });
              
                // Customers Endpoints
                config.ReceiveEndpoint("gruppo3-orch-NewOrderEvent", e =>
                {
                    e.Consumer<NewOrdersEventConsumer>();
                });
              
                config.ReceiveEndpoint("gruppo3-orch-UpdateOrderEvent", e =>
                {
                    e.Consumer<UpdateOrdersEventConsumer>();
                });
                config.ReceiveEndpoint("gruppo3-orch-DeleteOrderEvent", e =>
                {
                    e.Consumer<DeleteOrdersEventConsumer>();
                });
                
                // Products Endpoints
                config.ReceiveEndpoint("gruppo2-orchestratore-CreateClientCommands", e =>
                {
                    e.Consumer<NewClientEventConsumer>();

                });
                config.ReceiveEndpoint("gruppo2-orchestratore-UpdateClientCommands", e =>
                {
                    e.Consumer<UpdateClientEventConsumer>();

                });
                config.ReceiveEndpoint("gruppo2-orchestratore-DeleteClientCommands", e =>
                {
                    e.Consumer<DeleteClientEventConsumer>();

                });
                config.ReceiveEndpoint("gruppo2-orchestratore-CreateOrderCommands", e =>
                {
                    e.Consumer<NewOrdersEventConsumer>();

                });
                config.ReceiveEndpoint("gruppo2-orchestratore-UpdateOrderCommands", e =>
                {
                    e.Consumer<UpdateOrdersEventConsumer>();

                });
              
                config.ReceiveEndpoint("gruppo2-orchestratore-DeleteOrderCommands", e =>
                {
                    e.Consumer<DeleteOrdersEventConsumer>();

                });
                config.ConfigureEndpoints(context);
            });

        });
        services.AddMassTransitHostedService();
    })
    .Build();


await host.RunAsync();
