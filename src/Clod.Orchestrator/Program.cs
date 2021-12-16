using Clod.Orchestrator;
using Gruppo3.ClientiDTO.Domain.Events;
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
                  credential => {
                      credential.Username("vpeeygzh");
                      credential.Password("t0mDd3KRsJkXRV3DXzmCUfRWmDFbFu42");
                  });


                config.ConfigureEndpoints(context);


                config.ReceiveEndpoint("orders_create_client", e =>
                {
                    e.Consumer<CreateClientEventConsumer>();
                });
                config.ReceiveEndpoint("orders_product_refill", e =>
                {
                    e.Consumer<NewRefillEventConsumer>();
                });

                config.ReceiveEndpoint("orders_update_client", e =>
                {
                    e.Consumer<UpdateClientEventConsumer>(context);
                });

                config.ReceiveEndpoint("orders_delete_product", e =>
                {
                    e.Consumer<DeleteProductEventConsumer>(context);
                });

                config.ReceiveEndpoint("orders_new_product", e =>
                {
                    e.Consumer<NewProductEventConsumer>(context);
                });

                config.ReceiveEndpoint("orders_update_product", e =>
                {
                    e.Consumer<UpdateProductEventConsumer>(context);
                });

                config.ReceiveEndpoint("orders_delete_client", e =>
                {
                    e.Consumer<DeleteClientEventConsumer>(context);
                });

            }); 
        });
        services.AddMassTransitHostedService();
    })
    .Build();


await host.RunAsync();
