using Clod.Orchestrator;
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
                config.ReceiveEndpoint("orders_create_client", e =>
                {
                    e.Consumer<CreateClientEventConsumer>(context);
                });
                config.ReceiveEndpoint("orders_delete_client", e =>
                {
                    e.Consumer<DeleteClientEventConsumer>(context);
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

                config.ReceiveEndpoint("orders_newrefill_product", e =>
                {
                    e.Consumer<NewRefillEventConsumer>(context);
                });
            }); 
        });
        services.AddMassTransitHostedService();
    })
    .Build();


await host.RunAsync();
